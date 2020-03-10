using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class ParksSqlDAO : IParksDAO
    {

        private readonly string connectionString;
        public ParksSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IList<Park> GetAllParks()
        {
            List<Park> output = new List<Park>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = "SELECT * FROM dbo.park";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        Park park = RowToObject(reader);
                        output.Add(park);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }

            return output;
        }

        public Park GetPark(string id)
        {
            Park park = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "select * from dbo.park where parkcode = @id ";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        park = RowToObject(reader);
                    }
                }
            }
            catch
            {
                throw;
            }
            return park;
        }

        private Park RowToObject(SqlDataReader reader)
        {
            Park post = new Park()
            {
                ParkCode = Convert.ToString(reader["parkcode"]),
                ParkName = Convert.ToString(reader["parkname"]),
                State = Convert.ToString(reader["state"]),
                Acreage = Convert.ToInt32(reader["Acreage"]),
                ElevationInFeet = Convert.ToInt32(reader["ElevationInFeet"]),
                MilesOfTrail = Convert.ToDouble(reader["MilesOfTrail"]),
                NumberOfCampsites = Convert.ToInt32(reader["NumberOfCampsites"]),
                Climate = Convert.ToString(reader["Climate"]),
                YearFounded = Convert.ToInt32(reader["YearFounded"]),
                AnnualVisitorCount = Convert.ToInt32(reader["AnnualVisitorCount"]),
                InspirationalQuote = Convert.ToString(reader["InspirationalQuote"]),
                InspirationalQuoteSource = Convert.ToString(reader["InspirationalQuoteSource"]),
                ParkDescription = Convert.ToString(reader["ParkDescription"]),
                EntryFee = Convert.ToInt32(reader["EntryFee"]),
                NumberOfAnimalSpecies = Convert.ToInt32(reader["NumberOfAnimalSpecies"]),
            };
            return post;
        }

    }
}
