using ConsoleTables;
using FinalConsoleProject.Common.Base.BaseEntity;
using FinalConsoleProject.Common.Base.BaseID;
using FinalConsoleProject.Common.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FinalConsoleProject.Service
{
    public class MarketService
    {
        public List<Products> Product;

        public List<Sales> Sale;

        public List<SaleItem> SaleItem;


        public MarketService()
        {
            Product = new List<Products>();
            Sale = new List<Sales>();
            SaleItem = new List<SaleItem>();
        }


        public void AddProduct(string name, decimal price, int number, string category)
        {

            var list = Product.Find(x => x.Name.Equals(name) && x.Price.Equals(price));

            if (list == null)
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

                    StockNumber = number,

                    Categories = (Categories)parsedCategories
                };

                Product.Add(newProducts);



                Console.WriteLine(newProducts.Id);
            }
            else
            {
                list.StockNumber += number;

            }



        }
        public void UptadeProduct(int id, string name, decimal price, int number, string category)
        {
            var pro = Product.FirstOrDefault(x => x.Id == id);
            if (pro == null)
            { Console.WriteLine("There is not product!"); }
            bool isSuccelfull = Enum.TryParse(typeof(Categories), category, true, out object parsedCategories);

            if (!isSuccelfull)
            {
                throw new FormatException("Category is empty!");
            }
            pro.Name = name;

            pro.Price = price;

            pro.StockNumber = number;

            pro.Categories = (Categories)parsedCategories;


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

        public void ShowProductsByCategory(string category)
        {
            var find_list = new List<Products>();
            foreach (var item in Enum.GetValues(typeof(Categories)))
            {
                var find = Product.FindAll(item => item.Categories.ToString().ToLower().Equals(category.ToLower()));
                find_list.AddRange(find);
            }
            var products = find_list.GroupBy(x => x.Name).Select(x => x.First()).ToList();
            var table = new ConsoleTable("Product Name", "Product Price", "Product Categories", "Product Number", "Product Id");
            foreach (var items in products)
            {

                table.AddRow(items.Name, items.Price, items.Categories, items.StockNumber, items.Id);

            }

            table.Write();
        }

        public void FindByPriceRange(decimal startprice, decimal endprice)
        {
            if (startprice < 0)
            {
                throw new Exception("Please enter price 0-9999999");

            }

            if (endprice < 0)
            {
                throw new Exception("Please enter price 0-9999999");
            }

            if (startprice > endprice)
            {
                throw new Exception("Starting price must less than ending price");
            }

            var pro = Product.Where(x => x.Price >= startprice && x.Price <= endprice).ToList();

            if (pro == null)
            {
                throw new Exception("There aren't any product for this price range:)");
            }


            var table = new ConsoleTable("Product Name", "Product Price", "Product Categories", "Product Number", "Product Id");


            foreach (var product in pro)
            {
                table.AddRow(product.Name, product.Price, product.Categories, product.StockNumber, product.Id);
            }

            table.Write();
        }

        public void FindProductByName(string name)
        {
            var pro = Product.Find(x => x.Name.Trim().ToLower() == name.ToLower());

            if (pro == null)
            {
                throw new Exception("There isn't product with this name:(");
                return;

            }

            var table = new ConsoleTable("Product Name", "Product Price", "Product Categories", "Product Number", "Product Id");

            table.AddRow(pro.Name, pro.Price, pro.Categories, pro.StockNumber, pro.Id);


            table.Write();

        }




        // Sale methods:
        int Count = 0;
        public void AddSale()
        {
            Sales sale = new Sales();
            sale.Id = Count++;
            sale.SaleItems = new List<SaleItem>();
            ConsoleKeyInfo key = default(ConsoleKeyInfo);
            int i = 1;

            do
            {
                SaleItem item = new SaleItem();

                Console.WriteLine("Enter product ID:");
                int productID = Convert.ToInt32(Console.ReadLine());
                Products product = Product.Find(x => x.Id == productID);
                if (product != null)
                {
                    Console.WriteLine("Enter product count:");
                    string productCount = Console.ReadLine();
                    int saleitemCount = Convert.ToInt32(productCount);

                    while (saleitemCount == 0)
                    {
                        Console.WriteLine("Product number must bigger than 0!");
                        productCount = Console.ReadLine();
                        saleitemCount = Convert.ToInt32(productCount);
                    }

                    item.Id = i;
                    item.Products = product;
                    if (product.StockNumber == 0)
                    {
                        Console.WriteLine("There is not enough product in stock");
                        continue;
                    }
                    else if (product.StockNumber >= saleitemCount)
                    {
                        item.SaleNumber = saleitemCount;
                        product.StockNumber -= saleitemCount;
                        sale.Amount += product.Price * item.SaleNumber;
                        sale.SaleItems.Add(item);
                        Console.WriteLine(product.Name);
                    }
                    else
                    {
                        Console.WriteLine("Error");
                        Console.WriteLine("Error");
                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            item.SaleNumber = product.StockNumber;
                            product.StockNumber = 0;
                            i++;
                            sale.Amount += product.Price * item.SaleNumber;
                            sale.SaleItems.Add(item);
                            Console.WriteLine(product.Name);
                        }
                        else
                        {
                            Console.WriteLine("This product is not sold");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Product is not available");
                    continue;
                }
                Console.WriteLine("Click the \"Space\" button to stop process and any other button to contiue");
                key = Console.ReadKey();
            }
            while (key.Key != ConsoleKey.Spacebar);

            sale.Date = DateTime.Now;

            if (sale.SaleItems.Count > 0)
            {
                Sale.Add(sale);

                Console.WriteLine("Sale Added");
            }
            else { Console.WriteLine("No sale added!"); }
        }



        //public int AddSale()
        //{
        //    var list = new List<SaleItem>();

        //    try
        //    {
        //        var newsale = new Sales
        //        {
        //            SaleItems = list,
        //            Date = DateTime.UtcNow
        //        };

        //    Again:
        //        int option;
        //        int Amount = 0;
        //        var list2 = Product.Find(x => x.StockNumber == x.StockNumber);



        //        Console.WriteLine("Please Enter Product's ID:");
        //        int Id = Convert.ToInt32(Console.ReadLine());

        //        Console.WriteLine("Please Enter Product Count:");
        //        int Count = Convert.ToInt32(Console.ReadLine());


        //        if (Count > list2.StockNumber)
        //        {
        //            throw new Exception("There is no enough product in stock");
        //        }
        //        if (Count <= 0)
        //        {
        //            throw new Exception("Please enter count more than 0!");
        //        }

        //        var saleitem = new SaleItem
        //        {
        //            Products = list2,

        //            SaleNumber = Count
        //        };

        //        newsale.Amount = Count * saleitem.Products.Price;

        //        SaleItem.Add(saleitem);

        //        list.Add(saleitem);

        //        decimal EndAmount = 0;

        //        for (int i = 0; i < list.Count; i++)
        //        {
        //            Amount += list[i].SaleNumber;
        //        }

        //        list2.StockNumber -= saleitem.SaleNumber;

        //        Console.WriteLine($"If you want to continue to add sale");

        //        Console.WriteLine("1 - Yes");
        //        Console.WriteLine("2 - No");

        //        int option1 = Convert.ToInt32(Console.ReadLine());

        //        switch (option1)
        //        {
        //            case 1:
        //                goto Again;

        //            case 2:
        //                goto End;

        //            default:
        //                break;
        //        }
        //    End:
        //        Sale.Add(newsale);
        //        return Sale.Count;
        //    }

        //    catch(Exception ex)
        //    {
        //        Console.WriteLine("Error!");
        //        Console.WriteLine(ex.Message);
        //    }
        //    return SaleItem.Count;
        //}



        public List<Sales> ShowAllSales()
        {

            return Sale;
        }

        public void DeleteSaleByName(int id, string name, int reversenumber)
        {

            var sale = Sale.FirstOrDefault(x => x.Id == id);


            if (id != sale.Id)
            {
                throw new Exception("Invalid Id number!");
            }

            if (sale == null)
            {
                throw new Exception("Please enter Sale Id");
            }

            var salebyname = Product.FirstOrDefault(x => x.Name == name);

            if (name == null)
            {
                Console.WriteLine("Please enter Product's Name or Id");
            }

            if (salebyname == null)
            {
                Console.WriteLine("Got an error!");
            }

            foreach (var item in SaleItem)
            {
                
                
                    foreach (var item2 in Sale)
                    {
                        item2.Amount -= (int)item.Products.Price * reversenumber;
                        item.SaleNumber -= reversenumber;
                    }
                if (item.SaleNumber < reversenumber)
                {
                    throw new Exception("Error");

                }
            }
            salebyname.StockNumber += reversenumber;
        }

        public void DeleteSaleById(int id)
        {
            var deletedsale = Sale.FirstOrDefault(x => x.Id == id);
            if (deletedsale == null)
            { throw new Exception($"There is not product for {id} ID "); }

            Sale = Sale.Where(x => x.Id != id).ToList();
            


        }

        public void ShowSaleByDateRange(DateTime date1, DateTime date2)
        {

            var daterange = Sale.FindAll(x => x.Date >= date1 && x.Date <= date2).ToList();



            var table = new ConsoleTable("Product Id", "Product Amount", "Product Date");

            if (daterange.Count == 0)
            {
                Console.WriteLine("No products yet");
                return;
            }

            foreach (var product in daterange)
            {
                table.AddRow(product.Id, product.Amount + "AZN", product.Date);
            }

            table.Write();
        }

        public void ShowSaleByPriceRange(decimal price1, decimal price2)
        {
            var pricerange = Sale.FindAll(x => x.Amount > price1 && x.Amount < price2);



            //var table = new ConsoleTable("Sale Id", "Product Name", "Sale Amount", "Sale Date");

            //foreach (var salebypricerange in pricerange)
            //{
            //    foreach (var sale in SaleItem)
            //    {
            //        table.AddRow(salebypricerange.Id, sale.Products.Name, salebypricerange.Amount, salebypricerange.Date);
            //    }
            //}
            //table.Write();
        }

        public void ShowSaleByDate(DateTime date)
        {
            var bydate = Sale.FindAll(x => x.Date == date).ToList();

            var table = new ConsoleTable("Product Id", "Product Amount", "Product Date");

            if (bydate.Count == 0)
            {
                Console.WriteLine("No products yet");
                return;
            }

            foreach (var product in bydate)
            {
                table.AddRow(product.Id, product.Amount + "AZN", product.Date);
            }

            table.Write();


        }

        public void ShowSaleById(int id)
        {
            var salebyid = Sale.FindAll(x => x.Id == id).ToList();

            var table = new ConsoleTable("Sale Id", "Product Name", "Sale Amount", "Sale Date");

            if (salebyid.Count == 0)
            {
                Console.WriteLine("No products yet");
                return;
            }

            foreach (var sale in salebyid)
            {
                foreach (var product in SaleItem)
                {
                    table.AddRow(sale.Id, product.Products.Name, sale.Amount + " AZN", sale.Date);
                }
            }

            table.Write();
        }
    }
}
