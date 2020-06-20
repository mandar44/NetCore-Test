using System;
using System.Collections.Generic;

namespace Proj_3_Github_Test.datamodels
{
    public partial class Order_Item_Details
    {
        public long Order_Item_ID { get; set; }
        public long? Order_ID { get; set; }
        public int? Item_ID { get; set; }
        public decimal? Rate { get; set; }
        public int? Created_By { get; set; }
        public DateTime? Created_Date { get; set; }

        public virtual Item_Master Item_ { get; set; }
        public virtual Order_Master Order_ { get; set; }
    }
}
