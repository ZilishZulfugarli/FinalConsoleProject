using FinalConsoleProject.Common.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalConsoleProject.Common.Enum;
using FinalConsoleProject.Common.Base.BaseEntity;
using ConsoleTables;
using System.Globalization;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using System.ComponentModel.Design;
using System.Text.RegularExpressions;

namespace FinalConsoleProject.Service
{
    public class MenuService
    {
        private static MarketService marketService = new();

        #region Menu Sale Methods
        public static void MenuAddNewProduct()
        {
            try
            {
                Console.WriteLine("Enter product's name:");
                string name = Console.ReadLine().Trim();
                

                Console.WriteLine("Enter products's price:");
                decimal price = Convert.ToDecimal(Console.ReadLine().Trim());


                var table = new ConsoleTable("Categories");

                foreach (var item in Enum.GetValues(typeof(Categories)))
                {
                    table.AddRow(item);
                    //----ADD ALL CATEGORIES TO TABLE----
                }

                table.Write();

                Console.WriteLine("Enter product's category:");

                string category = Console.ReadLine().Trim();
                bool regex = Regex.IsMatch(category, @"^[a-zA-Z, 0-5]+$");
                if (regex != true)
                {
                    throw new Exception("Please enter only letter");
                }


                Console.WriteLine("Enter product's stock number:");
                int number = Convert.ToInt32(Console.ReadLine().Trim());

                marketService.AddProduct(name, price, number, category);

                foreach (var item in marketService.Product)
                {
                    Console.WriteLine($"Added {name} with Id -> {item.Id}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Hava some problems!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuUptadeProduct()
        {
            try
            {
                Console.WriteLine("Enter product ID:");
                int Id = Convert.ToInt32(Console.ReadLine().Trim());

                Console.WriteLine("Enter product name:");
                string name = Console.ReadLine().Trim();
                
                Console.WriteLine("Enter product price:");
                decimal price = Convert.ToDecimal(Console.ReadLine().Trim());

                var table = new ConsoleTable("Categories");

                foreach (var item in Enum.GetValues(typeof(Categories)))
                {
                    table.AddRow(item);
                }

                table.Write();

                Console.WriteLine("Enter product's category:");
                string category = Console.ReadLine().Trim();
                bool regex = Regex.IsMatch(category, @"^[a-zA-Z, 0-5]+$");
                if (regex != true)
                {
                    throw new Exception("Please enter only letter");
                }

                Console.WriteLine("Enter product number:");
                int number = Convert.ToInt32(Console.ReadLine().Trim());


                marketService.UptadeProduct(Id, name, price, number, category);

                Console.WriteLine($"Successfully product uptaded with ID -> {Id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Have some problems!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuDeleteProduct()
        {
            try
            {
                Console.WriteLine("Enter product ID:");
                int ProductId = Convert.ToInt32(Console.ReadLine().Trim());

                marketService.DeleteProduct(ProductId);

                Console.WriteLine($"Successfully deleted product with id -> {ProductId}");

            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuShowAllProduct()
        {
            try
            {
                var products = marketService.ShowAllProducts();

                var table = new ConsoleTable("Product Name", "Product Price", "Product Categories", "Product Number", "Product Id");
                //----BUILD A TABLE----
                if (products.Count == 0)
                {
                   throw new Exception("No products yet");
                    
                }

                foreach (var product in products)
                {
                    table.AddRow(product.Name, product.Price + " AZN", product.Categories, product.StockNumber, product.Id);
                }

                table.Write();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuFindByCategory()
        {
            try
            {
                Console.WriteLine("Enter category:");
                string category = Console.ReadLine().Trim();
                bool regex = Regex.IsMatch(category, @"^[a-zA-Z, 0-5]+$");
                if (regex != true)
                {
                    throw new Exception("Please enter only letter");
                }

                marketService.ShowProductsByCategory(category);
            }
            catch (Exception ex)
            {
                Console.WriteLine("There is not category you write");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuFindByPriceRange()
        {
            try
            {
                Console.WriteLine("Enter starting price:");
                int startprice = Convert.ToInt32(Console.ReadLine().Trim());

                Console.WriteLine("Enter ending price:");
                int endprice = Convert.ToInt32(Console.ReadLine().Trim());

                marketService.FindByPriceRange(startprice, endprice);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Have some problem!");
                Console.WriteLine(ex.Message);
            }

        }

        public static void MenuFindByName()
        {
            try
            {
                Console.WriteLine("Enter product name:");
                string name = Console.ReadLine().Trim();
                

                if (string.IsNullOrEmpty(name))
                {
                    throw new Exception("Got an error!");
                }


                marketService.FindProductByName(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Have some error!");
                Console.WriteLine(ex.Message);
            }
        }

        #endregion

        #region Menu Sale Methods
        public static void MenuAddSale()
        {
            try
            {
                Console.WriteLine("Enter how much product you buy:");
                int SaleItemNumber = Convert.ToInt32(Console.ReadLine());
                
                marketService.AddSale(SaleItemNumber);
                
                Console.WriteLine($"Added sale with ID: ");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }

        }

        public static void MenuReturnSaleItem()
        {
            try
            {
                Console.WriteLine("Enter Sale ID:");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter Sale Item ID:");
                int SaleItemID = Convert.ToInt32(Console.ReadLine());


                Console.WriteLine("Enter number how much you want reverse:");
                int reversenumber = Convert.ToInt32(Console.ReadLine());

                var table = new ConsoleTable("Id", "Product's name");

                var products = marketService.ShowAllProducts();

                foreach (var item in products)
                {
                    table.AddRow(item.Id, item.Name);
                }

                marketService.ReturnSaleİtem(id, SaleItemID, reversenumber);

                if (products.Count == 0)
                {
                    throw new Exception("No products yet");
                    
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("xxxxxxxxxxxxxxxxxx");
                Console.WriteLine("Have some problems");
                Console.WriteLine("xxxxxxxxxxxxxxxxxx");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuDeleteById()
        {
            try
            {
                Console.WriteLine("Enter Id number:");
                int id = Convert.ToInt32(Console.ReadLine());

                marketService.DeleteSaleById(id);

                Console.WriteLine($"Succesffully deleted sale with Id -> {id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("xxxxxxxxxxxxxxxxxx");
                Console.WriteLine("Have some problem!");
                Console.WriteLine("xxxxxxxxxxxxxxxxxx");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuShowAllSales()
        {
            try
            {

                var sales = marketService.ShowAllSales();


                if (sales.Count == 0)
                {
                    throw new Exception("No sale's yet");
                }

                var res = sales.GroupBy(x => x.Id).Select(y => y.First()).ToList();
                
                var table = new ConsoleTable("Sale's id", "Sale's date", "Saleitem's id",
                    "Saleitem's price", "Saleitem's name", "Product's stock");

                var table2 = new ConsoleTable($"Total Amount of Sale with ID: ");


                foreach (var item in sales)
                {

                    foreach (var saleItem in item.SaleItems)
                    {
                        var product = saleItem.Products;

                        table.AddRow(item.Id, item.Date, product.Id, saleItem.EndPrice, product.Name, product.StockNumber);
                    }

                    table2.AddRow("ID " + item.Id + "->" + " " + item.Amount + " " + "AZN");
                }

                Console.WriteLine();

                table.Write();
                table2.Write();
            }

            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuShowByDateRange()
        {
            try
            {
                Console.WriteLine("Enter start date:  (MM/dd/yyyy HH:mm:ss)");
                DateTime date1 = Convert.ToDateTime(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.WriteLine("Enter end date:  (MM/dd/yyyy HH:mm:ss)");
                DateTime date2 = Convert.ToDateTime(Console.ReadLine(), CultureInfo.InvariantCulture);

                marketService.ShowSaleByDateRange(date1, date2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("xxxxxxxxxxxxxxxxxx");
                Console.WriteLine("Have some problem:(");
                Console.WriteLine("xxxxxxxxxxxxxxxxxx");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuShowSaleByPriceRange()
        {
            try
            {
                Console.WriteLine("Enter start price:");
                decimal startprice = Convert.ToDecimal(Console.ReadLine());

                Console.WriteLine("Enter end price:");
                decimal endprice = Convert.ToDecimal(Console.ReadLine());

                marketService.ShowSaleByPriceRange(startprice, endprice);
            }
            catch (Exception ex)
            {
                Console.WriteLine("xxxxxxxxxxxxxxxxxx");
                Console.WriteLine("Have some problem:(");
                Console.WriteLine("xxxxxxxxxxxxxxxxxx");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuShowSaleByDate()
        {
            try
            {
                Console.WriteLine("Enter date for search:  (MM/dd/yyyy HH:mm:ss)");
                DateTime date = Convert.ToDateTime(Console.ReadLine(), CultureInfo.InvariantCulture);

                marketService.ShowSaleByDate(date);
            }
            catch (Exception ex)
            {
                Console.WriteLine("xxxxxxxxxxxxxxxxxx");
                Console.WriteLine("Have some problem:(");
                Console.WriteLine("xxxxxxxxxxxxxxxxxx");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuShowSaleById()
        {
            try
            {

                Console.WriteLine("Enter Id for search:");
                int id = Convert.ToInt32(Console.ReadLine());

                marketService.ShowSaleById(id);
            }
            catch (Exception ex)
            {
                Console.WriteLine("xxxxxxxxxxxxxxxxxx");
                Console.WriteLine("Have some problem:(");
                Console.WriteLine("xxxxxxxxxxxxxxxxxx");
                Console.WriteLine(ex.Message);
            }
        }
    }
}

#endregion

