﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel;

namespace BiblioTECH.Models.Branch
{
    public class EditBranchModel
    {
        public int BranchId { get; set; }
        public string Name { get; set; }

        public string Address { get; set; }

        public string Telephone { get; set; }

        public string Description { get; set; }

        [DisplayName("Imagine")]

        public IFormFile Image { get; set; }
    }
}

