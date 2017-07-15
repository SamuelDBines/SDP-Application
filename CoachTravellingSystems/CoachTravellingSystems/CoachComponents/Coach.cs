using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachTravellingSystems
{
    class Coach
    {
        private int coachNumber;
        private int numberOfSeats;
        private List<Driver> driver { get; set; }
        private bool service { get; set; }
        private bool toilets { get; set; }
        public List<Seats> seats { get; set; }
        public int viewCoachNumber(int coachNumber)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM Coach where coachNumber =@coachNumber", Program.cnn);
            execute.Parameters.AddWithValue("@coachNumber", coachNumber);
            Program.cnn.Open();
            try
            {

                using (SqlDataReader reader = execute.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            coachNumber = int.Parse(reader["coachNumber"].ToString());
                        }
                    }
                    else
                    {
                        Program.cnn.Close();
                        return -1;
                    }
                }
            }
            catch
            {
                Program.cnn.Close();
                return -1;
            }
            Program.cnn.Close();
            return coachNumber;
        }
        public int getNumberOfSeats(int coachNumber)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM Coach where coachNumber =@coachNumber", Program.cnn);
            execute.Parameters.AddWithValue("@coachNumber", coachNumber);
            Program.cnn.Open();
            try
            {

                using (SqlDataReader reader = execute.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        numberOfSeats = int.Parse(reader["numberOfSeats"].ToString());
                    }
                  
                }
            }
            catch
            {
                Program.cnn.Close();
                return -1;
            }
            Program.cnn.Close();
            return coachNumber;
        }
        public bool getService(int coachNumber)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM Coach where coachNumber =@coachNumber", Program.cnn);
            execute.Parameters.AddWithValue("@coachNumber", coachNumber);
            Program.cnn.Open();
            try
            {

                using (SqlDataReader reader = execute.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        if (reader["service"].ToString() == "true")
                            service = true;
                        else
                            service = false;
                    }

                }
            }
            catch
            {
                Program.cnn.Close();
                return false;
            }
            Program.cnn.Close();
            return service;
        }
        public bool getToilets(int coachNumber)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM Coach where coachNumber =@coachNumber", Program.cnn);
            execute.Parameters.AddWithValue("@coachNumber", coachNumber);
            Program.cnn.Open();
            try
            {

                using (SqlDataReader reader = execute.ExecuteReader())
                {

                    while (reader.Read())
                    {
                        if (reader["toilets"].ToString() == "true")
                            toilets = true;
                        else
                            service = false;
                    }

                }
            }
            catch
            {
                Program.cnn.Close();
                return false;
            }
            Program.cnn.Close();
            return toilets;
        }
    }
    
}
