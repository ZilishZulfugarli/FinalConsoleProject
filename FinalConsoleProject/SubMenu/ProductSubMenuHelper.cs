using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalConsoleProject.SubMenu
{
    public class ProductSubMenuHelper
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
                        Console.WriteLine("Added employee");
                        break;
                    case 2:
                        Console.WriteLine("Deleted employee");
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
