using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRestService.Controllers;
using System.Web;
using CorrectLibrary;

namespace HotelApp
{
    class Program
    {
        static void Main(string[] args)
        {
            FacilitiesController ctrl = new FacilitiesController();

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
                    Facilities f = new Facilities();

                    Console.WriteLine("Indtast Hotel Nr:");
                    f.HotelNr = int.Parse(Console.ReadLine());
                    Console.WriteLine("Swimmingpool? true/false");
                    f.Swimmingpool = bool.Parse(Console.ReadLine());
                    Console.WriteLine("Tabletennis true/false?");
                    f.Tabletennis = bool.Parse(Console.ReadLine());
                    Console.WriteLine("Pooltable? true/false");
                    f.Pooltable = bool.Parse(Console.ReadLine());
                    Console.WriteLine("Bar? true/false");
                    f.Bar = bool.Parse(Console.ReadLine());

                    ctrl.Post(f);

                    Console.WriteLine(f.ToString());
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
