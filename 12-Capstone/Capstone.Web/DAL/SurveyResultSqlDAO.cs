using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public class SurveyResultSqlDAO : ISurveyResultDAO
    {
        private readonly string connectionString;
        public SurveyResultSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public IList<Survey> GetSurveys(string id)
        {
            List<Survey> output = new List<Survey>();

            Survey surv = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "select * from dbo.survey_result where parkcode = @id ";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        surv = RowToObject(reader);
                        output.Add(surv);
                    }
                }
            }
            catch
            {
                throw;
            }
            return output;
        }


        private Survey RowToObject(SqlDataReader reader)
        {
            Survey surv = new Survey()
            {
                SurveyID = Convert.ToInt32(reader["surveyID"]),
                ParkCode = Convert.ToString(reader["parkCode"]),
                EmailAddress = Convert.ToString(reader["emailAddress"]),
                State = Convert.ToString(reader["state"]),
                ActivityLevel = Convert.ToString(reader["activityLevel"]),
            };
            return surv;
        }

        public void AddSurvey(ParkSurveyVM parkSurveyVM)
        {
            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = @"INSERT survey_result (parkCode, emailAddress, State, activityLevel)
VALUES (@parkCode, @emailAddress, @state, @activityLevel)";


                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command

                    cmd.Parameters.AddWithValue("@parkCode", parkSurveyVM.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", parkSurveyVM.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", parkSurveyVM.State);
                    cmd.Parameters.AddWithValue("@activityLevel", parkSurveyVM.ActivityLevel);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return;

        }
    }
}
