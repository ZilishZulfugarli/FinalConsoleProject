using FinalConsoleProject.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalConsoleProject.Common.Enum;
using FinalConsoleProject.Common.Base.BaseEntity;
using ConsoleTables;

namespace FinalConsoleProject.Service
{
    public class MenuService
    {
        private static MarketService marketService = new();

        public static void AddNewProduct()
        {
            try
            {
                Console.WriteLine("Enter product's name:");
                string name = Console.ReadLine();

                Console.WriteLine("Enter products's price:");
                decimal price = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Enter product's category:");
                string category = Console.ReadLine();

                Console.WriteLine("Enter product's stock number:");
                int number = Convert.ToInt32(Console.ReadLine());

                int productId = marketService.AddProduct(name, price, number, category);

                Console.WriteLine($"Added {name} with ID: {productId}");
            }
            catch
            {

            }

            /*public static void ShowProduct()
    {
        try
        {
            var products = marketService.GetProduct();

            var table = new ConsoleTable("Product Name", "Product Price", "Product Categories", "Product Number", "Product Id");

            if (products.Count == null)
            {
                Console.WriteLine("No products yet");
                return;
            }

            foreach (var product in products)
            {
                table.AddRow(product.Name, product.Price, product.Categories, product.Number, product.Id);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Oops! Got an error!");
            Console.WriteLine(ex.Message);
        }*/
        }
    }
}


    
