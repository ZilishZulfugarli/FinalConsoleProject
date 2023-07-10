using FinalConsoleProject.SubMenu;

namespace FinalConsoleProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int option;
            Console.WriteLine("Welcome to market system :)");

            do
            {
                Console.WriteLine("1. To operate on products");
                Console.WriteLine("2. Preperate on sales");
                Console.WriteLine("0. Exit");

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
                        ProductSubMenuHelper.ProductSubMenu();
                       break;
                    case 2:
                        SaleSubMenuHelper.SaleSubMenu();
                        break;
                    case 0:
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.WriteLine("No such option! Please enter option 0-2");
                        break;
                }

            } while (option != 0);
        }
    }
}