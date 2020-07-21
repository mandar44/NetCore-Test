using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Proj_3_Github_Test.Models
{
    public class BookModel
    {
        public int ID { get; set; }

        [Display(Name ="Enter Title")]
        [Required(ErrorMessage = "Please enter Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter Author")]
        public string Author { get; set; }

        //[Required(ErrorMessage ="Select File")]
        //public IFormFile BookImage { get; set; }


    }
}
