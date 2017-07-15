using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoachTravellingSystems
{
    class Ticket
    {
        public int ticketID;
        public string holderName;
        public string tripcode;
        public string paid;
        public Ticket()
        {
            SqlCommand execute = new SqlCommand("Select Count(*) From Ticket", Program.cnn);
            Program.cnn.Open();
            try
            {
                Int32 count = (Int32)execute.ExecuteScalar();
                Program.ticketCount = count +1;
            }
            catch
            {

            }
            Program.cnn.Close();
        }
        public string getPaid(int ticketId)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM Ticket where ticketID =@id", Program.cnn);
            execute.Parameters.AddWithValue("@id", ticketId);
            Program.cnn.Open();
            try
            {
                using (SqlDataReader reader = execute.ExecuteReader())
                {
                   
                        while (reader.Read())
                        {
                            paid= reader["paid"].ToString();
                        }
                   
                }
            }
            catch
            {
                Program.cnn.Close();
                return "CTS-Invalid";
            }
            Program.cnn.Close();
            return paid;
        }
        public int viewTicketID(int ticketID)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM Ticket where ticketID =@ticketID", Program.cnn);
            execute.Parameters.AddWithValue("@ticketID", ticketID);
            Program.cnn.Open();
            try
            {

                using (SqlDataReader reader = execute.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ticketID = int.Parse(reader["ticketID"].ToString());
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
            return ticketID;
        }
        public string viewTicketHolder(int ticketID)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM Ticket where ticketID =@ticketId", Program.cnn);
            execute.Parameters.AddWithValue("@ticketId", ticketID);
            Program.cnn.Open();
            try
            {
                using (SqlDataReader reader = execute.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        holderName = reader["holderName"].ToString();
                    }
                }
            }
            catch
            {
                Program.cnn.Close();
                return "CTS-Invalid";
            }
            Program.cnn.Close();
            return holderName;
        }
        public string viewTripCode(int ticketID)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM Ticket where ticketID =@ticketId", Program.cnn);
            execute.Parameters.AddWithValue("@ticketId", ticketID);
            Program.cnn.Open();
            try
            {
                using (SqlDataReader reader = execute.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tripcode = reader["tripCode"].ToString();
                    }
                }
            }
            catch
            {
                Program.cnn.Close();
                return "CTS-Invalid";
            }
            Program.cnn.Close();
            return tripcode;
        }
    }
}
