﻿using FinalConsoleProject.Common.Base.BaseID;
using FinalConsoleProject.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalConsoleProject.Common.Base.BaseEntity
{
    
    public class Products : BaseId
    {
        private static int count;
        public Products()
        {
            Id = count;
            count++;
        }

        public string Name { get; set; }
        public int StockNumber { get; set; }
        public decimal Price { get; set; }
        public Categories Categories { get; set; }



    }
}
