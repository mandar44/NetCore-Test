using System;
using System.Collections.Generic;

namespace Proj_3_Github_Test.datamodels
{
    public partial class Order_Master
    {
        public Order_Master()
        {
            Order_Item_Details = new HashSet<Order_Item_Details>();
        }

        public long Order_ID { get; set; }
        public DateTime? Order_Date { get; set; }
        public int? Customer_ID { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Email_ID { get; set; }
        public int? Created_By { get; set; }
        public DateTime? Created_Date { get; set; }

        public virtual User_Master Created_ByNavigation { get; set; }
        public virtual User_Master Customer_ { get; set; }
        public virtual ICollection<Order_Item_Details> Order_Item_Details { get; set; }
    }
}
