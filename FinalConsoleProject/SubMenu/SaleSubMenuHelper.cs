using FinalConsoleProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalConsoleProject.SubMenu
{
    public class SaleSubMenuHelper
    {
        public static void SaleSubMenu()
        {
            Console.Clear();
            int option;
            do
            {
                Console.WriteLine("1. Add new sale");
                Console.WriteLine("2. Show all sales");
                Console.WriteLine("3. Reverse product from sale");

                Console.WriteLine("4. Delete sale by Id");
                Console.WriteLine("5. Show sale by date range");
                Console.WriteLine("6. Show sale by date");
                Console.WriteLine("7. Show sale by ID");

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
                        MenuService.MenuAddSale();
                        break;
                    case 2:
                        MenuService.MenuShowAllSales();
                        break;
                    case 3:
                        MenuService.MenuDeleteSaleByName();
                        break;
                    case 4:
                        MenuService.MenuDeleteById();
                        break;
                    case 5:
                        MenuService.MenuShowByDateRange();
                        break;
                    case 6:
                        MenuService.MenuShowSaleByDate();
                        break;
                    case 7:
                        MenuService.MenuShowSaleById();
                        break;
                    case 8:
                        MenuService.MenuShowSaleById();
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("There is no such option! Please enter number 0-8");
                        break;
                }

            } while (option != 0);
        }
    }
}
