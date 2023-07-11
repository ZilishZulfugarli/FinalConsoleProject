using FinalConsoleProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalConsoleProject.SubMenu
{
    public class ProductSubMenuHelper : MarketService
    {
        public static void ProductSubMenu()
        {
            Console.Clear();
            int option;
            do
            {
                Console.WriteLine("1. Add new product");
                Console.WriteLine("2. Edit on product");
                Console.WriteLine("3. Remove product");
                Console.WriteLine("4. Show all products");
                Console.WriteLine("5. Show products for categories");
                Console.WriteLine("6. Show products by price range ");
                Console.WriteLine("7. Search products by name");
                Console.WriteLine("0. Go back");


                Console.WriteLine("-----------");
                Console.WriteLine("Enter option:");

                while (!int.TryParse(Console.ReadLine(), out option))
                {
                    Console.WriteLine("Invalid number!");
                    Console.WriteLine("-----------");
                    Console.WriteLine("Enter option:");
                }

                switch (option)
                {
                    case 1:
                        MenuService.AddNewProduct();
                        break;
                    case 2:
                        MenuService.UptadeProduct();
                        break;

                    case 3:
                        MenuService.MenuDeleteProduct();
                        break;

                    case 4:
                        MenuService.ShowProduct();
                        break;
                    case 5:
                        MenuService.FindByCategory();
                        break;
                        case 6:
                            MenuService.MenuFindByPriceRange();
                        break;
                    case 7:
                        MenuService.MenuFindByName();
                        break;
                            

                    case 0:
                        break;
                    default:
                        Console.WriteLine("There is no such option! Please enter number 0-7");
                        break;
                }

            } while (option != 0);
        }
    }
}
