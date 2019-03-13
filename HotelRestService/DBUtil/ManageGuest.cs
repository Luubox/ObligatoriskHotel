using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using CorrectLibrary;

namespace HotelRestService.DBUtil
{
    /// <summary>
    /// CRUD/REST funktionalitet til lokaldb
    /// </summary>
    public class ManageGuest
    {
        /// <summary>
        /// Strengen der giver placering og forbindelsen til databasen.
        /// </summary>
        private string connectionString = "";

        /// <summary>
        /// Metode til at returnere alle data i databasen.
        /// (GET /api/Guest/)
        /// </summary>
        /// <returns>Liste af guests</returns>
        public List<Guest> GetAllGuest()
        {
            string querystring = "SELECT * from DemoGuest";

            List<Guest> guestList = new List<Guest>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    querystring, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Guest guest = new Guest();
                        guest.Guest_No = reader.GetInt32(0);
                        guest.Guest_Name = reader.GetString(1);
                        guest.Guest_Address = reader.GetString(2);
                        guestList.Add(guest);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }

            return guestList;
        }
        
        /// <summary>
        /// Metode til at returnere et enkelt datasæt ud fra id.
        /// (GET /API/GUEST/ID)
        /// </summary>
        /// <param name="guestNr">ID/Guest_No</param>
        /// <returns>Den ønskede Guest</returns>
        public Guest GetGuestFromId(int guestNr)
        {
            string querystring = String.Format("SELECT * from DemoGuest WHERE Guest_No = {0}", guestNr);
            Guest guest = new Guest();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    querystring, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        guest.Guest_No = reader.GetInt32(0);
                        guest.Guest_Name = reader.GetString(1);
                        guest.Guest_Address = reader.GetString(2);
                    }
                }
                finally
                {
                    reader.Close();
                }
            }
            return guest;
        }
        
        /// <summary>
        /// Opretter en række i databasen med den medsendte data.
        /// (POST /API/GUEST/)
        /// </summary>
        /// <param name="guest">Data der skal oprettes</param>
        /// <returns></returns>
        public bool CreateGuest(Guest guest)
        {
            string querystring = String.Format("INSERT INTO DemoGuest VALUES({0}, {1}, {2}", guest.Guest_No, guest.Guest_Name, guest.Guest_Address);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    querystring, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }
        
        /// <summary>
        /// Opdaterer data i tabellen ud fra id.
        /// (PUT /API/GUEST/ID)
        /// </summary>
        /// <param name="guest">Ny data</param>
        /// <param name="guestNr">ID</param>
        /// <returns></returns>
        public bool UpdateGuest(Guest guest, int guestNr)
        {
            string querystring = String.Format("UPDATE DemoGuest SET Guest_No = {0}, Name = {1}, Address = {2}", guest.Guest_No, guest.Guest_Name, guest.Guest_Address);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    querystring, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }
        
        /// <summary>
        /// Sletter data i tabellen ud fra id.
        /// (DELETE /API/GUEST/ID)
        /// </summary>
        /// <param name="guestNr">ID</param>
        /// <returns></returns>
        public bool DeleteGuest(int guestNr)
        {
            string querystring = String.Format("DELETE FROM DemoGuest WHERE Guest_No = {0}", guestNr);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    querystring, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }
    }
}