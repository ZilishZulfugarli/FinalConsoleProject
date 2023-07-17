using FinalConsoleProject.Common.Base.BaseID;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalConsoleProject.Common.Base.BaseEntity
{
    public class SaleItem : BaseId
    {
        private static  int count;
        public SaleItem() 
        {
            Id = count;
            count++;           
        }

        public decimal EndPrice { get; set; }
        public Products Products { get; set; }
        public int SaleNumber { get; set; }

        
    }
}
