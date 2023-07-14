﻿using FinalConsoleProject.Common.Enum;
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
                string name = Console.ReadLine().Trim();

                Console.WriteLine("Enter products's price:");
                decimal price = Convert.ToDecimal(Console.ReadLine().Trim());



                var table = new ConsoleTable("Categories");

                foreach (var item in Enum.GetValues(typeof(Categories)))
                {
                    table.AddRow(item);
                }

                table.Write();

                Console.WriteLine("Enter product's category:");

                string category = Console.ReadLine().Trim();

                Console.WriteLine("Enter product's stock number:");
                int number = Convert.ToInt32(Console.ReadLine().Trim());

                marketService.AddProduct(name, price, number, category);

                foreach (var item in marketService.Product)
                {
                    Console.WriteLine($"Added {name} with Id : {item.Id}");
                }
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
                int Id = Convert.ToInt32(Console.ReadLine().Trim());

                Console.WriteLine("Enter product name:");
                string name = Console.ReadLine().Trim();

                Console.WriteLine("Enter product price:");
                decimal price = Convert.ToDecimal(Console.ReadLine().Trim());

                Console.WriteLine("Enter product number:");
                int number = Convert.ToInt32(Console.ReadLine().Trim());


                marketService.UptadeProduct(Id, name, price, number);

                Console.WriteLine($"Successfully product uptaded by ID: {Id}");


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
                    table.AddRow(product.Name, product.Price + "AZN", product.Categories, product.StockNumber, product.Id);
                }

                table.Write();

            }

            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }


        }

        public static void FindByCategory()
        {
            try
            {
                Console.WriteLine("Enter category:");
                string category = Console.ReadLine().Trim();

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
        //----------------------------------------------------------------------------------------------------------------------------
        //Sale methods
        public static void MenuAddSale()
        {

            try
            {
                Console.WriteLine("Please enter products count:");
                int listnumber = Convert.ToInt32(Console.ReadLine());


                for (int i = 1; i <= listnumber; i++)
                {
                    Console.WriteLine("Please enter product ID:");
                    int Id = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Enter product amount:");
                    int SaleNumber = Convert.ToInt32(Console.ReadLine());

                    marketService.AddSale(listnumber, Id, SaleNumber);
                    
                }

                Console.WriteLine($"Added sale with ID");

                



            }
            catch (Exception ex)
            {
                Console.WriteLine("Got an error!");
                Console.WriteLine(ex.Message);

            }


        }

        public static void MenuShowAllSales()
        {
            try
            {
                var products = marketService.ShowAllSales();

                foreach (var items in marketService.Sale)
                {
                    var table = new ConsoleTable($"Sale Id: {items.Id}", "Product Name", "Sale Amount", "Sale Date", "Product Price", "Last stock number");



                    if (products.Count == 0)
                    {
                        Console.WriteLine("No products yet");
                        return;
                    }

                    foreach (var item in products)
                    {
                        foreach (var product in marketService.Product)
                        {
                            if (item.Id == product.Id)
                            {
                                table.AddRow(" ", product.Name, item.Amount + " AZN", item.Date, product.Price, product.StockNumber);
                            }
                        }
                    }

                    table.Write();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Oops! Got an error!");
                Console.WriteLine(ex.Message);
            }


        }

        //public static void MenuDeleteSaleByName()
        //{
        //    Console.WriteLine("Enter name for search:");
        //    string name = Console.ReadLine();

        //    Console.WriteLine("Enter number how much you want reverse:");
        //    int reversenumber = Convert.ToInt32(Console.ReadLine());

        //    marketService.DeleteSaleByName(name, reversenumber);
        //}

        public static void MenuDeleteById()
        {
            try
            {
                Console.WriteLine("Enter Id number:");
                int id = Convert.ToInt32(Console.ReadLine());

                marketService.DeleteSaleById(id);

                Console.WriteLine($"Succesffully deleted sale with Id: {id}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Have some problem!");
                Console.WriteLine(ex.Message);
            }
        }

        public static void MenuShowByDateRange()
        {
            try
            {
                Console.WriteLine("Enter start date:  (MM/dd/yyyy)");
                DateTime date1 = Convert.ToDateTime(Console.ReadLine());

                Console.WriteLine("Enter end date:  (MM/dd/yyyy)");
                DateTime date2 = Convert.ToDateTime(Console.ReadLine());
                marketService.ShowSaleByDateRange(date1, date2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Have some problem:(");
                Console.WriteLine(ex.Message);
            }




        }

        public static void MenuShowSaleByPriceRange()
        {
            Console.WriteLine("Enter start price:");
            decimal startprice = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter end price:");
            decimal endprice = Convert.ToInt32(Console.ReadLine());

            marketService.ShowSaleByPriceRange(startprice, endprice);
        }
        public static void MenuShowSaleByDate()
        {
            Console.WriteLine("Enter date for search:  (MM/dd/yyyy)");
            DateTime date = Convert.ToDateTime(Console.ReadLine());

            marketService.ShowSaleByDate(date);
        }

        public static void MenuShowSaleById()
        {
            Console.WriteLine("Enter Id for search:");
            int id = Convert.ToInt32(Console.ReadLine());

            marketService.ShowSaleById(id);
        }
    }
}



