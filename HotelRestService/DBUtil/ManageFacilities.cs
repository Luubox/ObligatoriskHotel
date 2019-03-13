using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using CorrectLibrary;

namespace HotelRestService.DBUtil
{
    public class ManageFacilities
    {
        //TODO Indsæt connection string fra opgaven her
        public string connectionString = "";

        public List<Facilities> GetAllFacilities()
        {
            string querystring = "SELECT * from DemoFacilities";

            List<Facilities> facilitiesList = new List<Facilities>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    querystring, connection);
                connection.Open();
                SqlDataReader rdr = command.ExecuteReader();
                try
                {
                    while (rdr.Read())
                    {
                        Facilities f = new Facilities();
                        f.HotelNr = rdr.GetInt32(0);
                        f.Swimmingpool = rdr.GetBoolean(1);
                        f.Tabletennis = rdr.GetBoolean(2);
                        f.Pooltable = rdr.GetBoolean(3);
                        f.Bar = rdr.GetBoolean(4);
                        facilitiesList.Add(f);
                    }
                }
                finally
                {
                    rdr.Close();
                }
            }

            return facilitiesList;

        }

        public Facilities GetFacilitiesFromId(int hotelNr)
        {
            string querystring = $"SELECT * from DemoFacilities WHERE Hotel_No = {hotelNr}";
            Facilities f = new Facilities();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    querystring, connection);
                connection.Open();
                SqlDataReader rdr = command.ExecuteReader();
                try
                {
                    while (rdr.Read())
                    {
                        f.HotelNr = rdr.GetInt32(0);
                        f.Swimmingpool = rdr.GetBoolean(1);
                        f.Tabletennis = rdr.GetBoolean(2);
                        f.Pooltable = rdr.GetBoolean(3);
                        f.Bar = rdr.GetBoolean(4);
                    }
                }
                finally
                {
                    rdr.Close();
                }
            }
            return f;
        }

        public bool CreateFacilities(Facilities facilities)
        {
            string querystring = $"INSERT INTO DemoFacilities VALUES {facilities.HotelNr}, {facilities.Swimmingpool}, {facilities.Tabletennis}, {facilities.Pooltable}, {facilities.Bar}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(querystring, connection);
                connection.Open();
                cmd.ExecuteNonQuery();
            }
            return true;
        }

        public bool UpdateFacilities(Facilities facilities, int hotelNr)
        {
            string querystring =
                $"UPDATE DemoFacilities SET Swimmingpool = {facilities.Swimmingpool}, Tabletennis = {facilities.Tabletennis}, Pooltable = {facilities.Pooltable}, Bar = {facilities.Bar}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    querystring, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;        }

        public bool DeleteFacilities(int hotelNr)
        {
            string querystring = $"DELETE FROM DemoFacilities WHERE Hotel_No = {hotelNr}";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(
                    querystring, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;        }
    }
}