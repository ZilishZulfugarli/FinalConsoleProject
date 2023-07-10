using FinalConsoleProject.Common.Base.BaseEntity;
using FinalConsoleProject.Common.Base.BaseID;
using FinalConsoleProject.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinalConsoleProject.Service
{
    public class MarketService
    {
        public List<Products> Product;
        

        public MarketService()
        {
            Product = new List<Products>();
        }

        public List<Products> GetProduct()
        {
            return Product;
        }

        public int AddProduct(string name, decimal price, int number, string category)
        {
            if (string.IsNullOrEmpty(name))
                throw new FormatException ("Name is empty!");

            if (number < 0)
                throw new FormatException("Number less than 0!");

            if (price < 0)
                throw new FormatException("Price little than zero!");

            bool isSuccelfull = Enum.TryParse(typeof(Categories), category, true, out object parsedCategories);

            if (!isSuccelfull) 
            {
                throw new FormatException("Category is empty!");
            }
            
            var newProducts = new Products
            {
                Name = name,
                
                Price = price,
                Categories = (Categories)parsedCategories
            };

            Product.Add(newProducts);
            return newProducts.Id;



       }

        
    }
}
