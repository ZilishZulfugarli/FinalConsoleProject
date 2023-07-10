using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalConsoleProject.Common.Base.BaseID
{
    public class SaleItemID
    {
        public SaleItemID(int count)
        {
            ID = count;
            count++;
        }

        private int count = 0;
        public int ID { get; set; }
    }
}
