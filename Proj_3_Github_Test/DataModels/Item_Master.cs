using System;
using System.Collections.Generic;

namespace Proj_3_Github_Test.datamodels
{
    public partial class Item_Master
    {
        public Item_Master()
        {
            Order_Item_Details = new HashSet<Order_Item_Details>();
        }

        public int Item_ID { get; set; }
        public string Item_Name { get; set; }
        public decimal? Rate { get; set; }
        public int? Created_By { get; set; }
        public DateTime? Created_Date { get; set; }
        public int? Updated_By { get; set; }
        public DateTime? Updated_Date { get; set; }

        public virtual ICollection<Order_Item_Details> Order_Item_Details { get; set; }
    }
}
