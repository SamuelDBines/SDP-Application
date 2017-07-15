using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachTravellingSystems 
{
    class Driver : User 
    {
        private string username;
        private string password;
        private string firstname;
        private string lastname;
        public string email { get; set; }
        public string mobile { get; set; }
        public string address { get; set; }

        string User.username
        {
            get
            {
                return username;
            }

            set
            {
                username = value;
            }
        }

        string User.password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        string User.firstname
        {
            get
            {
                return firstname;
            }

            set
            {
                firstname = value;
            }
        }

        string User.lastname
        {
            get
            {
                return lastname;
            }

            set
            {
                lastname = value;
            }
        }
        string User.viewUsername(string user)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM Driver where username =@user", Program.cnn);
            execute.Parameters.AddWithValue("@user", user);
            Program.cnn.Open();
            try
            {
                using (SqlDataReader reader = execute.ExecuteReader())
                {

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            username = reader["username"].ToString();
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
            return username;
        }
        String User.getPassword(String user)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM Driver where username =@user", Program.cnn);
            execute.Parameters.AddWithValue("@user", user);
            Program.cnn.Open();
            try
            {
                using (SqlDataReader reader = execute.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        password = reader["password"].ToString();

                    }
                }
            }
            catch
            {
                Program.cnn.Close();
                return "CTS-Invalid";
            }
            Program.cnn.Close();
            return password;
        }
        String User.getFirstName(String user)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM Driver where username =@user", Program.cnn);
            execute.Parameters.AddWithValue("@user", user);
            Program.cnn.Open();
            try
            {
                using (SqlDataReader reader = execute.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["username"].ToString());
                        firstname = reader["firstname"].ToString();
                    }
                }
            }
            catch
            {
                Program.cnn.Close();
                return "CTS-Invalid";
            }
            Program.cnn.Close();
            return username;
        }
        String User.getLastName(String user)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM Driver where username =@user", Program.cnn);
            execute.Parameters.AddWithValue("@user", user);
            Program.cnn.Open();
            try
            {
                using (SqlDataReader reader = execute.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["username"].ToString());
                        lastname = reader["lastname"].ToString();
                    }
                }
            }
            catch
            {
                Program.cnn.Close();
                return "CTS-Invalid";
            }
            Program.cnn.Close();
            return username;
        }
        String User.getEmail(String user)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM Driver where username =@user", Program.cnn);
            execute.Parameters.AddWithValue("@user", user);
            Program.cnn.Open();
            try
            {
                using (SqlDataReader reader = execute.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader["username"].ToString());
                        email = reader["email"].ToString();
                    }
                }
            }
            catch
            {
                Program.cnn.Close();
                return "CTS-Invalid";
            }
            Program.cnn.Close();
            return username;
        }

        bool User.isStaff()
        {
            return true;
        }

        public string getMobile(string user)
        {
            throw new NotImplementedException();
        }

        public string getAddress(string user)
        {
            throw new NotImplementedException();
        }
    }
}
