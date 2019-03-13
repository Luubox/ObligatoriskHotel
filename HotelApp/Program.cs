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
        static FacilitiesController ctrl = new FacilitiesController();

        static void Main(string[] args)
        {

            string menuString =
                "---------- HotelRESTService ----------\n" +
                "1. CREATE\n" +
                "2. READ\n" +
                "3. UPDATE\n" +
                "4. DELETE\n" +
                "0. Afslut\n" +
                "Vælg et nummer: ";

            Console.WriteLine(menuString);
            int choice = int.Parse(Console.ReadLine());
            Console.Clear();
            while (choice != 0)
            {
                switch (choice)
                {
                    case 1:
                        CreateFacility();
                        break;
                    case 2:
                        ReadFacility();
                        break;
                    case 3:
                        UpdateFacility();
                        break;
                    case 4:
                        DeleteFacility();
                        break;
                    default:
                        Console.WriteLine("Prøv igen.");
                        break;
                }
                Console.WriteLine(menuString);

                choice = int.Parse(Console.ReadLine());
                Console.Clear();
            }
        }

        private static void DeleteFacility()
        {
            Console.WriteLine("Indtast Hotel Nr:");
            int id = int.Parse(Console.ReadLine());

            ctrl.Delete(id);
        }

        private static void UpdateFacility()
        {
            Facilities f = new Facilities();

            Console.WriteLine("Indtast Hotel Nr:");
            int id = int.Parse(Console.ReadLine());
            f.HotelNr = id;
            Console.WriteLine("Swimmingpool? true/false");
            f.Swimmingpool = bool.Parse(Console.ReadLine());
            Console.WriteLine("Tabletennis true/false?");
            f.Tabletennis = bool.Parse(Console.ReadLine());
            Console.WriteLine("Pooltable? true/false");
            f.Pooltable = bool.Parse(Console.ReadLine());
            Console.WriteLine("Bar? true/false");
            f.Bar = bool.Parse(Console.ReadLine());

            ctrl.Put(id, f);

            ctrl.Get(f.HotelNr);
        }

        private static void ReadFacility()
        {
            Console.WriteLine("Vil du se et hotel, tast et tal, vil du se dem alle tast 0: ");
            int id = int.Parse(Console.ReadLine());

            if (id == 0) ctrl.Get().ForEach(Console.WriteLine);
            
            else Console.WriteLine(ctrl.Get(id));
        }

        private static void CreateFacility()
        {
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

            ctrl.Get(f.HotelNr);
        }
    }
}
