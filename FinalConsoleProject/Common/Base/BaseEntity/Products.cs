using FinalConsoleProject.Common.Base.BaseID;
using FinalConsoleProject.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalConsoleProject.Common.Base.BaseEntity
{
    /*-ad
  - qiymet
  - kateqoriyasi (enum)
  - say
  - kodu  var
    */
    public class Products
    {
        public Products(string name, decimal price, Categories category, ProductID productID)
        {
            Name = name;
            Price = price;
            Categories categories = category;
            ProductID count = productID;

        }

        public string Name { get; set; }

        public decimal Price { get; set; }
        public Categories Categories { get; set; }
        public ProductID Id { get; set; }


    }
}
