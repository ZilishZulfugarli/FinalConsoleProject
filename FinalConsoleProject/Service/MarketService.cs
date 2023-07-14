using ConsoleTables;
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

        public List<Sales> Sale;

        public List<SaleItem> SaleItem;



        public MarketService()
        {
            Product = new List<Products>();
            Sale = new List<Sales>();
            SaleItem = new List<SaleItem>();
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

                StockNumber = number,

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

            pro.StockNumber = number;


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

                var products = find_list.GroupBy(x => x.Name).Select(x => x.First()).ToList();
                var table = new ConsoleTable("Product Name", "Product Price", "Product Categories", "Product Number", "Product Id");
                foreach (var items in products)
                {


                    table.AddRow(items.Name, items.Price, items.Categories, items.StockNumber, items.Id);




                }

                table.Write();




            }

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


            var table = new ConsoleTable("Product Name", "Product Price", "Product Categories", "Product Number", "Product Id");


            foreach (var product in pro)
            {
                table.AddRow(product.Name, product.Price, product.Categories, product.StockNumber, product.Id);
            }

            table.Write();
        }

        public void FindProductByName(string name)
        {
            var pro = Product.FindAll(x => x.Name.Trim().ToLower() == name).ToList();

            var table = new ConsoleTable("Product Name", "Product Price", "Product Categories", "Product Number", "Product Id");


            foreach (var product in pro)
            {
                table.AddRow(product.Name, product.Price, product.Categories, product.StockNumber, product.Id);
            }

            table.Write();

        }

        // Sale methods:
        public void AddSale(int listsale, int id, int salenumber)
        {
            var list = listsale;

            

            var sale = Product.FirstOrDefault(x => x.Id == id);

            if (salenumber > sale.StockNumber)
            {
                throw new Exception($"Haven't enough {sale.Name} in stock ");
            }

            if (salenumber < 0)
            {
                Console.WriteLine("Number must be bigger than 0!");
            }

            if (id < 0)
            {
                Console.WriteLine("Id is wrong!");
            }

            sale.StockNumber -= salenumber;

            if (sale.Id == id)
            {
                var newsaleItem = new SaleItem
                {
                    SaleNumber = salenumber,

                    Products = (Products)sale,





                };
                SaleItem.Add(newsaleItem);



                var newsale = new Sales

                {


                    Amount = (int)(salenumber * newsaleItem.Products.Price),

                    Id = id,

                    Date = DateTime.Now.AddMinutes(1),



                };
                Sale.Add(newsale);

                
            }
   
            
        //    var newsaleItem = new SaleItem
        //    {
        //        SaleNumber = salenumber,

        //        Products = (Products)sale,

                



        //};
        //    SaleItem.Add(newsaleItem);



        //    var newsale = new Sales

        //    {


        //        Amount = (int)(salenumber * newsaleItem.Products.Price),

        //        Id = id,

        //        Date = DateTime.Now.AddMinutes(1),
                


        //};
        //    Sale.Add(newsale);

        //    return newsale.Id;


        }

        public List<Sales> ShowAllSales()
        {
            
            return Sale;
        }

        //public void DeleteSaleByName(string name, int reversenumber)
        //{
        //    var salebyname = Product.FirstOrDefault(x => x.Name != name);

        //    var salename = SaleItem.FirstOrDefault (x => x.Products.Name != name); 

        //    var sale = Product.Where(x => x.Name != name).ToList();

        //    if (salebyname == null)
        //    {
        //        Console.WriteLine("Got an error!");
        //    }

        //    salebyname.StockNumber += reversenumber;

        //    salename.SaleNumber -= reversenumber;

        //    foreach (var item in Sale)
        //    {
        //        foreach (var item2 in SaleItem)
        //        {
        //            item.Amount += (int)item2.Products.Price * reversenumber;
        //        }
        //    }

            

        //    var table = new ConsoleTable("Sale Id", "Product Name", "Sale Amount", "Sale Date");
        //    foreach (var item in sale)
        //    {
        //        foreach (var item2 in Sale)
        //        {
        //            table.AddRow(item.Id, item.Name, item2.Amount, item2.Date);

        //        }
        //    }
        //    table.Write();

            
        //}

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

            var table = new ConsoleTable("Sale Id", "Product Name", "Sale Amount", "Sale Date");

            foreach (var salebypricerange in pricerange)
            {
                foreach (var sale in SaleItem)
                {
                    table.AddRow(salebypricerange.Id, sale.Products.Name, salebypricerange.Amount, salebypricerange.Date);
                }
            }
            table.Write();
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
