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
                Console.WriteLine("2. Delete student");
                Console.WriteLine("3. Remove sale");
                Console.WriteLine("4. Show all sales");
                Console.WriteLine("5. Show sales by history range");
                Console.WriteLine("6. Show product by price range");
                Console.WriteLine("7. Showing sales on a given date");
                Console.WriteLine("8. Show sale information by ID");

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
                        Console.WriteLine("Added student");
                        break;
                    case 2:
                        Console.WriteLine("Deleted student");
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("There is no such option! Please enter number 0-9");
                        break;
                }

            } while (option != 0);
        }
    }
}
