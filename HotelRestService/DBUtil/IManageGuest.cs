using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelModels;

namespace DemoHotelDB.DBUtil
{
    public interface IManageGuest
    {
        /// <summary>
        /// henter alle gæster fra databasen
        /// </summary>
        /// <returns>Liste af gæster</returns>
        List<Guest> GetAllGuest();

        /// <summary>
        /// Henter en specifik gæst fra database 
        /// </summary>
        /// <param name="guestNr">Udpeger den gæst der ønskes fra databasen</param>
        /// <returns>Den fundne gæst eller null hvis gæsten ikke findes</returns>
        Guest GetGuestFromId(int guestNr);

        /// <summary>
        /// Indsætter en ny gæst i databasen
        /// </summary>
        /// <param name="guest">Gæsten der skal indsættes</param>
        /// <returns>Sand hvis der er gået godt ellers falsk</returns>
        bool CreateGuest(Guest guest);

        /// <summary>
        /// Opdaterer en gæst i databasen
        /// </summary>
        /// <param name="guest">De nye værdier til gæsten</param>
        /// <param name="guestNr">Nummer på den gæst der skal opdateres</param>
        /// <returns>Sand hvis der er gået godt ellers falsk</returns>
        bool UpdateGuest(Guest guest, int guestNr);

        /// <summary>
        /// Sletter en gæst fra databasen
        /// </summary>
        /// <param name="guestNr">Nummer på den gæst der skal slettes</param>
        /// <returns>Den gæst der er slettet fra databasen, returnere null hvis gæsten ikke findes</returns>
        bool DeleteGuest(int guestNr);

    }
}