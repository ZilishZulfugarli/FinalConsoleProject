using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalConsoleProject.Common.Base.BaseID
{
    public class ProductID
    {

        public ProductID(int id) 
        {
            ID = count;
            count++;
        }
        private int count = 0;
        public int ID = 0;
    }
}
