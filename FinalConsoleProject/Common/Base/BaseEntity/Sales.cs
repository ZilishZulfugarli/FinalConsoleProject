using FinalConsoleProject.Common.Base.BaseID;
using FinalConsoleProject.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalConsoleProject.Common.Base.BaseEntity
{
    internal class Sales
    {
        public Sales(string name, int amount, SaleID saleID, DateTime time, List<SaleItem> saleitem)
        {
            Name = name;
            Amount = amount;
           
            
        }
        public string Name { get; set; }

        public int Amount { get; set; }
        
        public SaleID Id { get; set; }  

        public DateTime Date { get; set; }

        public List<SaleItem> SaleItems { get; set; }
        
    }
}
