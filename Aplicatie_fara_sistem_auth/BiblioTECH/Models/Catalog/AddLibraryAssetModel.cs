using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel;
using TechData.Models;

namespace BiblioTECH.Models.LibraryAssetModel
{
    public class AddLibraryAssetModel
    {
        [DisplayName("Cateogrie")]

        public string Category { get; set; }

        [DisplayName("Titlu")]
        public string Title { get; set; }
        [DisplayName("An")]
        public string Year { get; set; } // Just store as an int for BC
        public string Status { get; set; }

        [DisplayName("Cost")]
        public string Cost { get; set; }

        [DisplayName("Imagine")]
        public IFormFile Image { get; set; }

        [DisplayName("Numar copii")]
        public int NumberOfCopies { get; set; }

        [DisplayName("Locatie")]
        public string Location { get; set; }

        public IEnumerable<string> Branches { get; set; }


        //books

        [DisplayName("ISBN #")]
        public string ISBN { get; set; }
        [DisplayName("Autor")]
        public string Author { get; set; }

        [DisplayName("Index Dewey")]
        public string DeweyIndex { get; set; }



        //video
        [DisplayName("Director")]
        public string Director { get; set; }
    }


}
