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
        //TODO PASTE PASSWORD HER
        public static string Pw = " ";

        //Nikolajs
        public string ConnectionString = $"Data Source=nikolajdbserver.database.windows.net;Initial Catalog=NikolajDB;User ID=nikolajlogin;Password={Pw};Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        //Johans
        //public string ConnectionString = $"Data Source=johan4391server.database.windows.net;Initial Catalog=JohanDB;User ID=joha4391;Password={Pw};Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public List<Facilities> GetAllFacilities()
        {
            string querystring = "SELECT * from DemoFacilities";

            List<Facilities> facilitiesList = new List<Facilities>();

            using (SqlConnection connection = new SqlConnection(ConnectionString))
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

            using (SqlConnection connection = new SqlConnection(ConnectionString))
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
            string querystring = $"INSERT INTO DemoFacilities (Hotel_No, Swimmingpool, Tabletennis, Pooltable, Bar) " +
                                 $"VALUES ({facilities.HotelNr}, {Convert.ToInt16(facilities.Swimmingpool)}, {Convert.ToInt16(facilities.Tabletennis)}, {Convert.ToInt16(facilities.Pooltable)}, {Convert.ToInt16(facilities.Bar)})";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
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
                $"UPDATE DemoFacilities " +
                $"SET Swimmingpool = {Convert.ToInt16(facilities.Swimmingpool)}, Tabletennis = {Convert.ToInt16(facilities.Tabletennis)}, Pooltable = {Convert.ToInt16(facilities.Pooltable)}, Bar = {Convert.ToInt16(facilities.Bar)} " +
                $"WHERE Hotel_No = {hotelNr}";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                SqlCommand command = new SqlCommand(
                    querystring, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            return true;
        }

        public bool DeleteFacilities(int hotelNr)
        {
            string querystring = $"DELETE FROM DemoFacilities WHERE Hotel_No = {hotelNr}";

            using (SqlConnection connection = new SqlConnection(ConnectionString))
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