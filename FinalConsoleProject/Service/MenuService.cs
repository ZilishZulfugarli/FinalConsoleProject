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

                Console.WriteLine("------------------------------------------------------");

                foreach (var item in Enum.GetValues(typeof(Categories)))
                {
                    Console.WriteLine(item);
                }

                Console.WriteLine("------------------------------------------------------");

                string category = Console.ReadLine();

                Console.WriteLine("Enter product's stock number:");
                int number = Convert.ToInt32(Console.ReadLine());

                int productId = marketService.AddProduct(name, price, number, category);

                Console.WriteLine($"Added {name} with ID: {productId}");
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Oops! Hava some problems!");
                Console.WriteLine(ex.Message);
            }

            

           
        }
        public static void UptadeProduct() 
        {
            try
            {
                Console.WriteLine("Enter product ID:");
                int Id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter product name:");
                string name = Console.ReadLine() ;

                Console.WriteLine("Enter product price:");
                decimal price = Convert.ToDecimal(Console.ReadLine()) ;

                Console.WriteLine("Enter product number:");
                int number = Convert.ToInt32(Console.ReadLine()) ;

               
                marketService.UptadeProduct(Id, name, price, number);

                Console.WriteLine($"Successfully product uptaded by ID: {Id}");


            }
            catch (Exception ex)
            { 
             throw new Exception("Have some problems!");
                Console.WriteLine(ex.Message);
            }
        }
        public static void MenuDeleteProduct()
        {
            try
            {
                Console.WriteLine("Enter product ID:");
                int ProductId = Convert.ToInt32(Console.ReadLine());

                marketService.DeleteProduct(ProductId);

                Console.WriteLine($"Successfully deleted product with id - {ProductId}");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }
            public static void ShowProduct()
            {
                try
                {
                    var products = marketService.ShowAllProducts();

                    var table = new ConsoleTable("Product Name", "Product Price", "Product Categories", "Product Number", "Product Id");

                    if (products.Count == 0)
                    {
                        Console.WriteLine("No products yet");
                        return;
                    }

                    foreach (var product in products)
                    {
                        table.AddRow(product.Name, product.Price, product.Categories, product.Number, product.Id);
                    }

                table.Write();
            }
                catch (Exception ex)
                {
                    Console.WriteLine("Oops! Got an error!");
                    Console.WriteLine(ex.Message);
                }

            
            }
        }
    }


    
