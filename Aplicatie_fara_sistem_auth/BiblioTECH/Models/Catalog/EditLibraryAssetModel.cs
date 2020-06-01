using Microsoft.AspNetCore.Http;
using System.ComponentModel;
using TechData.Models;

namespace BiblioTECH.Models.Catalog
{
    public class EditLibraryAssetModel
    {
        public int AssetId { get; set; }
        public string Title { get; set; }

        public string Type { get; set; }
        public int Year { get; set; }
        public float Cost { get; set; }
        public string Status { get; set; }

        [DisplayName("Imagine")]
        public IFormFile Image { get; set; }

        public string AuthorOrDirector { get; set; }

        public LibraryBranch CurrentLocation { get; set; }
        public string Isbn { get; set; }
        public string Dewey { get; set; }




    }
}
