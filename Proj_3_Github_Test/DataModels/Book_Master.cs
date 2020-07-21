using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proj_3_Github_Test.datamodels
{
    public partial class Book_Master
    {
        public int Book_ID { get; set; }

        [Display(Name = "Enter Title")]
        [Required(ErrorMessage = "Please enter Title")]
        public string Book_Name { get; set; }
        public int? Author_ID { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Created_Date { get; set; }
        public string Language { get; set; }

        [Required(ErrorMessage = "Select File")]
        [NotMapped]
        public IFormFile BookImage { get; set; }

        public string BookImagePath { get; set; }
    }
}
