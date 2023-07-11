using FinalConsoleProject.Common.Base.BaseEntity;
using FinalConsoleProject.Common.Base.BaseID;
using FinalConsoleProject.Common.Enum;
using System;
using System.Collections;
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

      
        public int AddProduct(string name, decimal price, int number, string category)
        {
            if (string.IsNullOrEmpty(name))
                throw new FormatException("Name is empty!");

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

                Number = number,

                Categories = (Categories)parsedCategories
            };

            Product.Add(newProducts);
            return newProducts.Id;



        }
        public void UptadeProduct(int id, string name, decimal price, int number)
        {
            var pro = Product.FirstOrDefault(x => x.Id == id);
            if (pro == null)
            { Console.WriteLine("There is not product!"); }

            pro.Name = name;

            pro.Price = price;

            pro.Number = number;


        }
        public void DeleteProduct(int ProductId)
        {
            var pro = Product.FirstOrDefault(x => x.Id == ProductId);
            if (pro == null)
            { throw new Exception($"There is not product for {ProductId} ID "); }

            Product = (List<Products>)Product.Where(x => x.Id != ProductId).ToList();
        }

        public List<Products> ShowAllProducts()
        {
            return Product;

        }
    }
}
