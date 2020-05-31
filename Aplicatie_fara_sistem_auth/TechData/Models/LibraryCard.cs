using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechData.Models
{
    public class LibraryCard
    {
        public int Id { get; set; }

        [Display(Name = "Overdue Fees")] public float Fees { get; set; }

        [Display(Name = "Card Issued Date")] public DateTime Created { get; set; }

        [Display(Name = "Materials on Loan")] public virtual IEnumerable<Checkout> Checkouts { get; set; }
    }
}
