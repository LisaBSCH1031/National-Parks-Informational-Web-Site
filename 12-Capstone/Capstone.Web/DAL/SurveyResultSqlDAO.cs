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

        public IList<SurveyResultVM> GetAllParkNamesWithSurvey ()
        {
            List<SurveyResultVM> parks = new List<SurveyResultVM>();
            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = @"select survey_result.parkcode, parkname, count(survey_result.parkcode) as Count from survey_result
join park on park.parkcode = survey_result.parkcode group by survey_result.parkCode, parkname";


                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        SurveyResultVM vm = RowToObject1(reader);
                        parks.Add(vm);
                    }
                }
            }
            catch (SqlException)
            {
                throw;
            }
            return parks;
        }
        private SurveyResultVM RowToObject1(SqlDataReader reader)
        {
            SurveyResultVM vm = new SurveyResultVM()
            {
                ParkCode = Convert.ToString(reader["parkcode"]),
                ParkName = Convert.ToString(reader["parkname"]),
                CountOfSurveys = Convert.ToInt32(reader["Count"]),
            };
            return vm;
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
    }
}
