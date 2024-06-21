using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatlerWaldorfCorp.EcommerceInventory.Model;

namespace StatlerWaldorfCorp.EcommerceInventory.Repository
{
    public interface ISKUStatusRepository
    {
        SKUStatus Get(int sku);    
        SKUStatus Add(SKUStatus status); 
    }
}