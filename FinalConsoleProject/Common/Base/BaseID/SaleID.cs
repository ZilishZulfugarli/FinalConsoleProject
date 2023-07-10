using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalConsoleProject.Common.Base.BaseID
{
    public class SaleID
    {

        public SaleID(int id) 
        {
            Id = count;
            count++;
        }

        private int count = 0;
        public int Id { get; set; }
    }
    
}
