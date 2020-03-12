using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class WeatherSqlDAO : IWeatherDAO
    {
        private readonly string connectionString;
        public WeatherSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Weather GetWeather(string id)
        {
            Weather wthr = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "select * from weather join park on weather.parkCode = park.parkCode where weather.parkcode = @id";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        wthr = RowToObject(reader);
                    }
                }
            }
            catch
            {
                throw;
            }
            return wthr;
        }

        public IList<Weather> GetWeatherDays(string id)
        {
            Weather wthr = null;
            List<Weather> output = new List<Weather>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "select * from weather join park on weather.parkCode = park.parkCode where weather.parkcode = @id";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        wthr = RowToObject(reader);
                        output.Add(wthr);
                    }
                }
            }
            catch
            {
                throw;
            }
            return output;
        }



        private Weather RowToObject(SqlDataReader reader)
        {
            Weather wthr = new Weather()
            {
                ParkCode = Convert.ToString(reader["parkcode"]),
                FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]),
                Low =  Convert.ToInt32(reader["low"]),
                High = Convert.ToInt32(reader["high"]),
                Forecast = Convert.ToString(reader["forecast"]),
            };
            return wthr;
        }


    }
}
