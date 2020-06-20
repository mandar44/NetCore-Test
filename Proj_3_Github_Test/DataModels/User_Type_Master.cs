using System;
using System.Collections.Generic;

namespace Proj_3_Github_Test.datamodels
{
    public partial class User_Type_Master
    {
        public User_Type_Master()
        {
            User_Master = new HashSet<User_Master>();
        }

        public int User_Type_ID { get; set; }
        public string User_Type { get; set; }
        public bool? Active { get; set; }

        public virtual ICollection<User_Master> User_Master { get; set; }
    }
}
