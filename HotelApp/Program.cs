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
            string choice = Console.ReadLine();

            switch (choice)
            {
                //TODO gad ikke finde ud af hvorfor det ikke virkede, så deeeet
                case "c":
                    //client.Create();
                    break;
                case "r":
                    //client.Read();
                    break;
                case "u":
                    //client.Update();
                    break;
                case "d":
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
