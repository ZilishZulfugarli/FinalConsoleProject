﻿using FinalConsoleProject.Common.Base.BaseID;
using FinalConsoleProject.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalConsoleProject.Common.Base.BaseEntity
{
    internal class Sales : BaseId
    {
        private static int count;

        public Sales()
        {
            Id = count;
            count++;
        }





        public int Amount { get; set; }


        public DateTime Date { get; set; }

        public List<SaleItem> SaleItems { get; set; }


    }
}
