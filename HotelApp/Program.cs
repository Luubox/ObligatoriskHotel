using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string menuString =
                "---------- HotelRESTService ----------\n" +
                "1. CREATE\n" +
                "2. READ\n" +
                "3. UPDATE\n" +
                "4. DELETE\n" +
                "Vælg et nummer: ";

            Console.WriteLine(menuString);
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (choice)
            {
                case 1:


                    break;
                case 2:
                    //client.Read();
                    break;
                case 3:
                    //client.Update();
                    break;
                case 4:
                    //client.Delete();
                    break;
                default:
                    Console.WriteLine("Prøv igen.");
                    break;
            }

            Console.ReadLine();
        }
    }
}
