using System;
using System.Collections.Generic;

namespace Proj_3_Github_Test.datamodels
{
    public partial class Book_Master
    {
        public int Book_ID { get; set; }
        public string Book_Name { get; set; }
        public int? Author_ID { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public DateTime? Created_Date { get; set; }
        public string Language { get; set; }
    }
}
