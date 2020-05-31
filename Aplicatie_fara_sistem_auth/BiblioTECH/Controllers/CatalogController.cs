using BiblioTECH.Models.Catalog;
using BiblioTECH.Models.CheckoutModel;
using BiblioTECH.Models.LibraryAssetModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.IO;
using System.Linq;
using TechData.Interfaces;
using TechData.Models;

namespace BiblioTECH.Controllers
{
    [Authorize]
    public class CatalogController : Controller
    {
        private readonly ILibraryAssetService _assetsService;
        private readonly ICheckoutService _checkoutsService;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILibraryBranchService _branchService;
        private readonly IBookService _bookService;
        private readonly IVideoService _videoService;
        public CatalogController(ILibraryAssetService assetsService, ICheckoutService checkoutsService, IWebHostEnvironment hostEnvironment, ILibraryBranchService branchService, IBookService bookService, IVideoService videoService)
        {
            _assetsService = assetsService;
            _checkoutsService = checkoutsService;
            _hostingEnvironment = hostEnvironment;
            _branchService = branchService;
            _bookService = bookService;
            _videoService = videoService;

        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewData["BranchesNames"] = _branchService.GetAll()
        .Select(n => new SelectListItem
        {
            Value = n.Id.ToString(),
            Text = n.Name.ToString()
        }).ToList();
            var model = new AddLibraryAssetModel
            {
                Branches = _branchService.GetAll().Select(a => a.Name)

            };
            return View(model);
        }

        [HttpPost]
        public IActionResult PlaceAdd(AddLibraryAssetModel model)
        {
            //Atasam imaginea
            string uniqueFileName = null;
            string imageUrl = null;
            if (model.Image != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images/Assets");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                imageUrl = Path.Combine("/images/Assets/", uniqueFileName);
            }


            //Cream obiectul

            if (model.Category == "1")
            {
                var newAsset = new Book
                {
                    //  Id = _assetsService.setCorrectAssetId(),
                    Title = model.Title,
                    Year = int.Parse(model.Year),
                    Cost = float.Parse(model.Cost),
                    ImageUrl = imageUrl,
                    ISBN = model.ISBN,
                    Author = model.Author,
                    DeweyIndex = model.DeweyIndex,
                    Location = _branchService.SetLibraryBranch(int.Parse(model.Location))
                };
                _assetsService.Add(newAsset);
            }
            else if (model.Category == "2")
            {
                var newAsset = new Video
                {
                    Title = model.Title,
                    Year = int.Parse(model.Year),
                    Cost = float.Parse(model.Cost),
                    ImageUrl = imageUrl,
                    Director = model.Director

                };
                _assetsService.Add(newAsset);
            }
            //Trebuie adaugate si alte feluri de asset-uri



            //Facem redirect spre Index dupa ce creem asset-ul
            return RedirectToAction("Index");

        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            //Trebuie customizat
            return View();
        }

        //[HttpPost] trebe implementate Delete-ul pentru a putea fi post
        public IActionResult PlaceDelete(int id)
        {
            _assetsService.Delete(id);
            return RedirectToAction("Index");
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index()
        {
            var assetModels = _assetsService.GetAll();

            var listingResult = assetModels
                .Select(a => new AssetIndexListingModel
                {
                    Id = a.Id,
                    ImageUrl = a.ImageUrl,
                    AuthorOrDirector = _assetsService.GetAuthorOrDirector(a.Id),
                    Dewey = _assetsService.GetDeweyIndex(a.Id),
                    CopiesAvailable = _checkoutsService.GetNumberOfCopies(a.Id), // Remove
                    Title = _assetsService.GetTitle(a.Id),
                    Type = _assetsService.GetType(a.Id),
                    NumberOfCopies = _checkoutsService.GetNumberOfCopies(a.Id)
                }).ToList();

            var model = new AssetIndexModel
            {
                Assets = listingResult
            };

            return View(model);
        }



        [HttpGet]
        [AllowAnonymous]
        public IActionResult Detail(int id)
        {
            var asset = _assetsService.Get(id);

            var currentHolds = _checkoutsService.GetCurrentHolds(id).Select(a => new AssetHoldModel
            {
                HoldPlaced = _checkoutsService.GetCurrentHoldPlaced(a.Id),
                PatronName = _checkoutsService.GetCurrentHoldPatron(a.Id)
            });

            var model = new AssetDetailModel
            {
                AssetId = id,
                Title = asset.Title,
                Type = _assetsService.GetType(id),
                Year = asset.Year,
                Cost = asset.Cost,
                Status = asset.Status.Name,
                ImageUrl = asset.ImageUrl,
                AuthorOrDirector = _assetsService.GetAuthorOrDirector(id),
                CurrentLocation = _assetsService.GetCurrentLocation(id)?.Name,
                Dewey = _assetsService.GetDeweyIndex(id),
                CheckoutHistory = _checkoutsService.GetCheckoutHistory(id),
                CurrentAssociatedLibraryCard = _assetsService.GetLibraryCardByAssetId(id),
                Isbn = _assetsService.GetIsbn(id),
                LatestCheckout = _checkoutsService.GetLatestCheckout(id),
                CurrentHolds = currentHolds,
                PatronName = _checkoutsService.GetCurrentPatron(id)
            };

            return View(model);
        }




        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["BranchesNames"] = _branchService.GetAll()
        .Select(n => new SelectListItem
        {
            Value = n.Id.ToString(),
            Text = n.Name.ToString()
        }).ToList();
            var asset = _assetsService.Get(id);
            var model = new EditLibraryAssetModel
            {
                AssetId = id,
                Title = asset.Title,
                Type = _assetsService.GetType(id),
                Year = asset.Year,
                Cost = asset.Cost,
                Status = asset.Status.Name,
                AuthorOrDirector = _assetsService.GetAuthorOrDirector(id),
                CurrentLocation = _assetsService.GetCurrentLocation(id)?.Name,
                Dewey = _assetsService.GetDeweyIndex(id),
                Isbn = _assetsService.GetIsbn(id)
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult PlaceEdit(EditLibraryAssetModel model)
        {
            //Atasam imaginea
            string uniqueFileName = null;
            string imageUrl = null;
            if (model.Image != null)
            {
                string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images/Assets");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                model.Image.CopyTo(new FileStream(filePath, FileMode.Create));
                imageUrl = Path.Combine("/images/Assets/", uniqueFileName);
            }
            if (model.Type == "1")
            {
                var editedBook = _bookService.Get(model.AssetId);
                editedBook.Title = model.Title;
                editedBook.Year = model.Year;
                editedBook.Cost = model.Cost;
                editedBook.ImageUrl = imageUrl;
                editedBook.ISBN = model.Isbn;
                editedBook.Author = model.AuthorOrDirector;
                editedBook.DeweyIndex = model.Dewey;
                editedBook.Location = _branchService.SetLibraryBranch(int.Parse(model.CurrentLocation));
                _bookService.Edit(editedBook);
            }
            else if (model.Type == "2")
            {
                var editedVideo = _videoService.Get(model.AssetId);
                editedVideo.Title = model.Title;
                editedVideo.Year = model.Year;
                editedVideo.Cost = model.Cost;
                editedVideo.ImageUrl = imageUrl;
                editedVideo.Director = model.AuthorOrDirector;
                _videoService.Edit(editedVideo);
            }


            //Cream obiectul


            //Trebuie adaugate si alte feluri de asset-uri


            //Facem redirect spre Index dupa ce creem asset-ul
            return RedirectToAction("Index");

        }




        [HttpGet]
        public IActionResult Checkout(int id)
        {
            var asset = _assetsService.Get(id);

            var model = new CheckoutModel
            {
                AssetId = id,
                ImageUrl = asset.ImageUrl,
                Title = asset.Title,
                LibraryCardId = "",
                IsCheckedOut = _checkoutsService.IsCheckedOut(id)
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult PlaceCheckout(int assetId, int libraryCardId)
        {
            _checkoutsService.CheckoutItem(assetId, libraryCardId);
            return RedirectToAction("Detail", new { id = assetId });
        }



        [HttpGet]
        public IActionResult Hold(int id)
        {
            var asset = _assetsService.Get(id);

            var model = new CheckoutModel
            {
                AssetId = id,
                ImageUrl = asset.ImageUrl,
                Title = asset.Title,
                LibraryCardId = "",
                HoldCount = _checkoutsService.GetCurrentHolds(id).Count()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult PlaceHold(int assetId, int libraryCardId)
        {
            _checkoutsService.PlaceHold(assetId, libraryCardId);
            return RedirectToAction("Detail", new { id = assetId });
        }





        [HttpGet]
        public IActionResult CheckIn(int id)
        {
            _checkoutsService.CheckInItem(id);
            return RedirectToAction("Detail", new { id });
        }




        [HttpGet]
        public IActionResult MarkLost(int id)
        {
            _checkoutsService.MarkLost(id);
            return RedirectToAction("Detail", new { id });
        }

        [HttpGet]
        public IActionResult MarkFound(int id)
        {
            _checkoutsService.MarkFound(id);
            return RedirectToAction("Detail", new { id });
        }




    }
}
