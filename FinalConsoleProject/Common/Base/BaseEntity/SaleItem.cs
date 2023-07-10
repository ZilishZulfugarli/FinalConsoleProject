using FinalConsoleProject.Common.Base.BaseID;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalConsoleProject.Common.Base.BaseEntity
{
    public class SaleItem
    {

        public SaleItem(SaleItemID id, Products products, int count)
        {
            SaleItemID Id = id;
            Products Products = products;
            Count = count;

        }
        public SaleItemID Id { get; set; }

        public Products Products { get; set; }

        public int Count { get; set; }


    }
}
