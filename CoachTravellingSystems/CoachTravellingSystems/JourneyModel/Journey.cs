using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachTravellingSystems
{
    class Journey
    {
        private String tripCode { get; set; }
        private String destination { get; set; }
        public String price { get; set; }
        public String tripTime { get; set; }
        private String image { get; set; }
        private String review { get; set; }
        private String date { get; set; }
        
        public void addToTrips(String name, String price, String image, String review)
        {
            Program.cnn.Open();
            try
            {
                string query = "INSERT INTO trips (username,password,firstname,lastname) VALUES ('" + name + "','" + price + "','" + image + "','" + review + "')";
                SqlCommand execute = new SqlCommand(query, Program.cnn);
                execute.ExecuteNonQuery();
            } catch
            {

            }
            Program.cnn.Close();
        }
        public string viewTripCode(string tripcode)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM trips where tripCode=@tripcode", Program.cnn);
            execute.Parameters.AddWithValue("@tripcode", tripcode);
            Program.cnn.Open();
            try
            {

                using (SqlDataReader reader = execute.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            tripCode = reader["tripcode"].ToString();
                        }
                    }
                    else
                    {
                        Program.cnn.Close();
                        return "CTS-Invalid";
                    }
                }

            }
            catch
            {
                Program.cnn.Close();
                return "CTS-Invalid";
            }
            Program.cnn.Close();
            return tripCode;
        }
        public string viewDestination(string destination)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM trips where destination=@destination", Program.cnn);
            execute.Parameters.AddWithValue("@destination", destination);
            Program.cnn.Open();
            try
            {

                using (SqlDataReader reader = execute.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                           tripCode = reader["tripCode"].ToString();
                        }
                    }
                    else
                    {
                        Program.cnn.Close();
                        return "CTS-Invalid";
                    }
                }

            }
            catch
            {
                Program.cnn.Close();
                return "CTS-Invalid";
            }
            Program.cnn.Close();
            return tripCode;
        }
        public String getDestination(String tripcode)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM trips where tripCode=@tripcode", Program.cnn);
            execute.Parameters.AddWithValue("@tripcode", tripcode);
            Program.cnn.Open();
            try
            {
                using (SqlDataReader reader = execute.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        destination = reader["destination"].ToString();

                    }
                }
            }
            catch
            {
                Program.cnn.Close();
                return "CTS-Invalid";
            }
            Program.cnn.Close();
            return destination;
        }
        public String getPrice(String tripcode)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM trips where tripCode =@tripcode", Program.cnn);
            execute.Parameters.AddWithValue("@tripcode", tripcode);
            Program.cnn.Open();
            try
            {
                using (SqlDataReader reader = execute.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        price = reader["price"].ToString();

                    }
                }
            }
            catch
            {
                Program.cnn.Close();
                return "CTS-Invalid";
            }
            Program.cnn.Close();
            return price;
        }
        public String getTripTime(String tripcode)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM trips where tripCode =@tripcode", Program.cnn);
            execute.Parameters.AddWithValue("@tripcode", tripcode);
            Program.cnn.Open();
            try
            {
                using (SqlDataReader reader = execute.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tripTime = reader["tripTime"].ToString();

                    }
                }
            }
            catch
            {
                Program.cnn.Close();
                return "CTS-Invalid";
            }
            Program.cnn.Close();
            return tripTime;
        }
        public String getDate(String tripcode)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM trips where tripCode =@tripcode", Program.cnn);
            execute.Parameters.AddWithValue("@tripcode", tripcode);
            Program.cnn.Open();
            try
            {
                using (SqlDataReader reader = execute.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        date = reader["date"].ToString();

                    }
                }
            }
            catch
            {
                Program.cnn.Close();
                return "CTS-Invalid";
            }
            Program.cnn.Close();
            return date;
        }
        public String getReview(String tripcode)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM trips where tripCode =@tripcode", Program.cnn);
            execute.Parameters.AddWithValue("@tripcode", tripcode);
            Program.cnn.Open();
            try
            {
                using (SqlDataReader reader = execute.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        review = reader["review"].ToString();

                    }
                }
            }
            catch
            {
                Program.cnn.Close();
                return "CTS-Invalid";
            }
            Program.cnn.Close();
            return review;
        }
    }
}
