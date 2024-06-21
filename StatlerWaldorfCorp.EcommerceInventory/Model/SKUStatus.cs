using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatlerWaldorfCorp.EcommerceInventory.Model
{
    public class SKUStatus
    {
        public int SKU { get; set; }
        public int QtyOnHand { get; set;}
        public int QtyOnHold { get; set;}
        public int QtyAvail { get; set;}
        public int QtyBackOrdered { get; set;}
    }
}