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
        private static int count;
        public SaleItem() 
        {
            Id = count;
            count++;
        }

        private decimal EndPrice = 0;
        

        public Products Products { get; set; }

        public int Count { get; set; }

        internal static object ToDictionary()
        {
            throw new NotImplementedException();
        }

        internal static object FirstOrDefault(Func<object, bool> value)
        {
            throw new NotImplementedException();
        }
    }
}
