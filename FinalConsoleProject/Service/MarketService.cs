using ConsoleTables;
using FinalConsoleProject.Abstract;
using FinalConsoleProject.Common.Base.BaseEntity;
using FinalConsoleProject.Common.Base.BaseID;
using FinalConsoleProject.Common.Enum;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FinalConsoleProject.Service
{
    //INHERIT MARKETSERVICE FROM THE IMARKETABLE CLASS
    public class MarketService : IMarketable
    {
        public List<Products> Product;

        public List<Sales> Sale;

        public List<SaleItem> SaleItem;


        public MarketService()
        {
            Product = new List<Products>();
            Sale = new List<Sales>();
            SaleItem = new List<SaleItem>();
            //----NEW LISTS OPENED----
        }

        #region Product
        public void AddProduct(string name, decimal price, int number, string category)
        {
            //----ADD NEW PRODUCTS -> NAME, PRODUCT ID, PRICE, STOCK NUMBER, CATEGORY ----

            var list = Product.Find(x => x.Name.Equals(name) && x.Price.Equals(price));
            //----IF WE ADD A NEW PRODUCT WITH THE SAME NAME AND PRICE AS AN IN-STOCK PRODUCT, ONLY THE STOCK QUANTITY INCREASES ----

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
            //----EDIT OR UPTADE PRODUCT'S NAME, PRICE, STOCK NUMBER, CATEGORY WITH PRODUCT ID---- 
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
            //----DELETE PRODUCT WITH PRODUCT'S ID----
            var pro = Product.FirstOrDefault(x => x.Id == ProductId);
            if (pro == null)
            { throw new Exception($"There is not product for {ProductId} ID "); }

            Product = (List<Products>)Product.Where(x => x.Id != ProductId).ToList();
        }

        public List<Products> ShowAllProducts()
        {
            //----SHOW ALL PRODUCTS WHICH ADDED IN SYSTEM----
            return Product;
        }

        public void ShowProductsByCategory(string category)
        {
            //----FIND AND SHOW PRODUCTS WITH PRODUCT'S CATEGORY----
            var find_list = new List<Products>();
            foreach (var item in Enum.GetValues(typeof(Categories)))
            {
                var find = Product.FindAll(item => item.Categories.ToString().ToLower().Equals(category.ToLower()));
                find_list.AddRange(find);
                //----WE FIND CATEGORIES WHICH BASED IN ENUM----

                if(find == null)
                {
                    throw new Exception("Please enter category!");
                }
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
            //----FIND PRODUCT OR PRODUCTS WITH PRODUCTS PRICE. WE GIVE THE PRICE RANGE (START AND END PRICES) THEN FIND AND SHOW US PRODUCTS----
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
            //----IF START PRICE BIGGER OR EQUAL THE PRICE AND END PRICE LESS OR EQUAL PRICE IT FIND AND LIST THE PRODUCTS----
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
            //----FIND PRODUCT WITH NAME----
            var pro = Product.Find(x => x.Name.Trim().ToLower() == name.ToLower());

            if (pro == null)
            {
                throw new Exception("There isn't product with this name:(");
            }

            var table = new ConsoleTable("Product Name", "Product Price", "Product Categories", "Product Number", "Product Id");

            table.AddRow(pro.Name, pro.Price, pro.Categories, pro.StockNumber, pro.Id);


            table.Write();

        }

        #endregion



        #region Sale

        public int AddSale(int SaleItemNumber)
        {
            //----ADD NEW SALE----
            SaleItem = new();

            for (int i = 0; i < SaleItemNumber; i++)
            {
            start:

                Console.WriteLine("Enter Product ID:");

                int Id = Convert.ToInt32(Console.ReadLine().Trim());

                Console.WriteLine("Enter saleitem's number:");

                int salenumber = Convert.ToInt32(Console.ReadLine().Trim());

                var res = Product.Find(x => x.Id == Id);

                if (Id < 0)
                {
                    Console.WriteLine("Product's id is less than 0");
                }

                var find = Product.FirstOrDefault(x => x.Id == Id);

                if (find == null)
                {
                    Console.WriteLine("Produt's not found");
                    goto start;
                }

                if (salenumber > find.StockNumber)
                {
                    throw new Exception("Stock is less than 0");
                }

                var newSaleItem = new SaleItem
                {
                    SaleNumber = salenumber,

                    EndPrice = find.Price * salenumber,

                    Products = find
                };

                newSaleItem.Products.StockNumber -= salenumber;

                if (find.StockNumber == 0)
                {
                    Console.WriteLine("Wrong!");
                }

                SaleItem.Add(newSaleItem);
            }

            decimal sum = SaleItem.Sum(x => x.SaleNumber * x.Products.Price);

            var newSale = new Sales
            {
                Amount = sum,

                SaleItems = SaleItem,

                Date = DateTime.Now
            };

            Sale.Add(newSale);

            return newSale.Id;
        }

        public void ReturnSaleİtem(int id, int SaleItemID, int reversenumber)
        {
            //----RETURN THE PRODUCT TO SALE WITH SALE ID AND SALE ITEM ID----
            var SaleId = Sale.FirstOrDefault(x => x.Id == id);
                        
            if (SaleId == null)
            {
                throw new Exception("Sale not found");
            }
            
            var saleItem = SaleId.SaleItems.Find(item => item.Id == SaleItemID);

            if (saleItem == null)
            {
                throw new Exception("Sale item not found");
            }

            if (reversenumber > saleItem.SaleNumber)
            {
                throw new Exception("Quantity to remove exceeds the available quantity");
            }

            if (saleItem.SaleNumber == 0)
            {
                SaleId.SaleItems.Remove(saleItem);
            }

            saleItem.Products.StockNumber += reversenumber;

            saleItem.EndPrice -= reversenumber * saleItem.Products.Price;

            saleItem.SaleNumber -= reversenumber;

            SaleId.Amount -= saleItem.EndPrice;
        }

        public void DeleteSaleById(int id)
        {
            //----DELETE SALE FROM SYSTEM WITH ID----
            var deletedsale = Sale.FirstOrDefault(x => x.Id == id);
            if (deletedsale == null)
            {
                throw new Exception($"There is not product for {id} ID ");
            }

            Sale = Sale.Where(x => x.Id != id).ToList();
        }

        public List<Sales> ShowAllSales()
        {
            //----SHOWS ALL SALES IN TABLE----

            return Sale;
        }

        public void ShowSaleByDateRange(DateTime date1, DateTime date2)
        {
            //----SHOW ALL SALES WITH DATE RANGE----
            var daterange = Sale.FindAll(x => x.Date >= date1 && x.Date <= date2).ToList();

            var table = new ConsoleTable("Sale Id", "Sale Amount", "Sale Count", "Sale Date");

            if (daterange.Count == 0)
            {
                Console.WriteLine("No products yet");
                return;
            }

            foreach (var product in daterange)
            {
                foreach (var saleitem in SaleItem)
                    table.AddRow(product.Id, product.Amount + "AZN", saleitem.Products.StockNumber, product.Date);
            }

            table.Write();
        }

        public void ShowSaleByPriceRange(decimal price1, decimal price2)
        {
            //----SHOW ALL SALES WITH PRICE RANGE----
            var pricerange = Sale.FindAll(x => x.Amount >= price1 && x.Amount <= price2).ToList();

            if (pricerange == null)
            {
                throw new Exception("Please enter start and end prices!");
            }

            var table = new ConsoleTable("Sale Id", "Sale Amount", "Sale Count", "Sale Date");

            if (pricerange.Count == 0)
            {
                Console.WriteLine("No products yet");
                return;
            }

            foreach (var product in pricerange)
            {
                foreach (var saleitem in SaleItem)
                    table.AddRow(product.Id, product.Amount + "AZN", saleitem.Products.StockNumber, product.Date);
            }

            table.Write();
        }

        public void ShowSaleByDate(DateTime date)
        {
            //----SHOW ALL SALES WITH ONLY ONE DATE----
            var bydate = Sale.FindAll(x =>
            x.Date.Year == date.Year
            &&
            x.Date.Month == date.Month
            &&
            x.Date.Day == date.Day
            &&
            x.Date.Hour == date.Hour
            &&
            x.Date.Minute == date.Minute
            &&
            x.Date.Second == date.Second).ToList();

            var table = new ConsoleTable("Sale Id", "Sale Amount", "Sale Count", "Sale Date");

            if (bydate.Count == 0)
            {
                Console.WriteLine("No products yet");
                return;
            }

            foreach (var product in bydate)
            {
                foreach (var saleitem in SaleItem)
                    table.AddRow(product.Id, product.Amount + "AZN", saleitem.Products.StockNumber, product.Date);
            }

            table.Write();
        }

        public void ShowSaleById(int id)
        {
            //----SHOW SALES BY ID----
            var salebyid = Sale.FindAll(x => x.Id == id).ToList();

            var table = new ConsoleTable("Sale Id", "Sale Amount", "Product Name", "Product Sale Number", "Sale Date");

            if (salebyid.Count == 0)
            {
                Console.WriteLine("No products yet");
                return;
            }

            foreach (var sale in salebyid)
            {
                foreach (var product in SaleItem)
                {
                    table.AddRow(sale.Id, sale.Amount + " AZN", product.Products.Name, product.SaleNumber, sale.Date);
                }
            }

            table.Write();
        }
    }
}

#endregion
