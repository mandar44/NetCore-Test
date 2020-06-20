using System;
using System.Collections.Generic;

namespace Proj_3_Github_Test.datamodels
{
    public partial class User_Master
    {
        public User_Master()
        {
            Order_MasterCreated_ByNavigation = new HashSet<Order_Master>();
            Order_MasterCustomer_ = new HashSet<Order_Master>();
        }

        public int User_ID { get; set; }
        public string User_Name { get; set; }
        public string Password { get; set; }
        public int? User_Type_ID { get; set; }
        public bool? Active { get; set; }

        public virtual User_Type_Master User_Type_ { get; set; }
        public virtual ICollection<Order_Master> Order_MasterCreated_ByNavigation { get; set; }
        public virtual ICollection<Order_Master> Order_MasterCustomer_ { get; set; }
    }
}
