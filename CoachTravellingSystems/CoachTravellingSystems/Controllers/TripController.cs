using CoachTravellingSystems;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoachTravellingSystems
{
    class TripController
    {
        public List<Coach> coaches = new List<Coach>();
        public List<Ticket> tickets = new List<Ticket>();
        public String tripCode;
        public String destination;
        public String price;
        public String time;
        public String review;
        private  Journey j = new Journey();
        public TripController()
        {
            setupCoaches();
        }
        private void populateData(String tripName, String price, String time)
        {
           
        }
        public bool checkTripCode(String tripcode)
        {
                       
            if (j.viewTripCode(tripcode) == "CTS-Invalid" && j.viewDestination(tripcode) == "CTS-Invalid")
                return false;
            if (j.viewTripCode(tripcode) == "CTS-Invalid")
                tripcode = j.viewDestination(tripcode);
            tripCode = tripcode; destination = j.getDestination(tripcode); price = j.getPrice(tripcode);
            time = j.getTripTime(tripcode); review = j.getReview(tripcode);
            return true;
        }
        public void leaveReview(String tripcode, String message)
        {
            if(checkTripCode(tripcode))
            {
                string value = j.getReview(tripCode);;
                SqlCommand execute = new SqlCommand("Update trips SET review = @review WHERE tripCode=@tripcode", Program.cnn);
                execute.Parameters.AddWithValue("@tripcode", tripCode);
                execute.Parameters.AddWithValue("@review", value + "\n" + message);
                Program.cnn.Open();
                try
                { 
                    execute.ExecuteNonQuery();
                    MessageBox.Show("Review successfully added", "Review Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch
                {
                    MessageBox.Show("Review cannot be added!", "Review unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                Program.cnn.Close();
            }
            
        }
        public void addTicket(int id, string holderName, string tripcode)
        {
            Ticket t = new Ticket();
            id = 0;
            while(t.viewTicketID(id) != -1)
            {
                id = id + 1;
            } 
            if (checkTripCode(tripcode))
            {
                SqlCommand execute = new SqlCommand("INSERT INTO Ticket (ticketID,holderName, tripCode, paid) values ("+id+",'"+holderName+"','"+tripcode+"','no')", Program.cnn);
                 Program.cnn.Open();
                try
                {
                    execute.ExecuteNonQuery();
                }
                catch
                {
                    MessageBox.Show("Cannot buy a ticket!", "Review unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                Program.cnn.Close();
            }
        }
        private void setupCoaches()
        {
            for(int i = 0; i < 10; i++)
            {
                Coach c = new Coach();               
                if (c.viewCoachNumber(i) == i)
                    c.seats = setUpSeats(c.getNumberOfSeats(i));
                else
                    continue;
                coaches.Add(c);
            }
        }
        public List<Seats> setUpSeats(int amount)
        {
            List<Seats> coachSeats = new List<Seats>();
            bool odd = false;
            for(int i = 0; i < amount; i++)
            {
                Seats s = null;
                if (i < 16)
                    s = SeatFactory.seatFactory(seatType.FirstClass);
                else
                    s = SeatFactory.seatFactory(seatType.SecondClass);
                if (odd)
                    s.windowSeat = odd;
                else
                    s.windowSeat = odd;
                odd = !odd;
                coachSeats.Add(s);
            }
            return coachSeats;
        }        
        public String getQuote(String update)
        {
            String quote = null;
            int size = getQuoteSize();
            for (int i = 0; i < size; i++)
            {
                if (update == "")
                    quote += getAllQuotes(update, i);
                else
                    quote += getSpecificQuotes(update, i);
            }
            return quote;
        }
        public String getAllQuotes(String update, int index)
        {
            String quote = "";
            Program.cnn.Open();
            SqlCommand execute = new SqlCommand("SELECT * FROM Quotes where id=@ID", Program.cnn);
            execute.Parameters.AddWithValue("@ID", index);
            try
            {
                using (SqlDataReader reader = execute.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        quote += "Question Number : " + index + "\n";
                        quote += "Question asked by : " + update + "\n";
                        quote += "Question : " + reader["quote"].ToString() + "\n";
                        quote += "Responded by : " + reader["rUsername"].ToString() + "\n";
                        quote += "Response : " + reader["response"].ToString() + "\n\n";
                    }
                }
            }
            catch
            {
                Program.cnn.Close();
                return "CTS-Invalid";
            }

            Program.cnn.Close();
            return quote;
        }
        public String getSpecificQuotes(String update, int index)
        {
            String quote ="";
            Program.cnn.Open();
            SqlCommand execute = new SqlCommand("SELECT * FROM Quotes where id=@user", Program.cnn);
            execute.Parameters.AddWithValue("@user", index);
            try
            {
                using (SqlDataReader reader = execute.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        if (reader["username"].ToString() == update)
                        {
                            quote += "Question Number : " + index + "\n";
                            quote += "Question asked by : " + update + "\n";
                            quote += "Question : " + reader["quote"].ToString() + "\n";
                            quote += "Responded by : " + reader["rUsername"].ToString() + "\n";
                            quote += "Response : " + reader["response"].ToString() + "\n\n";
                        }
                    }
                }

            }
            catch
            {
                Program.cnn.Close();
                return "CTS-Invalid";
            }

            Program.cnn.Close();
            return quote;
        }
        public void sendQuote(String username,  String message)
        {
            Ticket t = new Ticket();
            int id = 0;
            while (viewQuoteID(id) != -1)
            {
                id = id + 1;
            }
            try
            {
                Program.cnn.Open();
                string query = "INSERT INTO Quotes (id, username,quote) VALUES (" + id +",'" + username + "','" + message + "')";
                SqlCommand execute = new SqlCommand(query, Program.cnn);
                execute.ExecuteNonQuery();
                MessageBox.Show("Quote has been sent", "update success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            catch
            {
                MessageBox.Show("Quote error occured", "update failure", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            Program.cnn.Close();
        }
        public void replyQuote(int ID, String message)
        {
            updateQuotesDatabase("Quotes", "rUsername", ID,Program.member.username);
            updateQuotesDatabase("Quotes", "response", ID, message);
            
        }
        private void updateQuotesDatabase(String where, String update, int ID, String value)
        {
            Program.cnn.Open();
            SqlCommand command;
            command = new SqlCommand("UPDATE " + where + "  SET " + update + " = @update WHERE id = @id ", Program.cnn);
            command.Parameters.AddWithValue("@update", value);
            command.Parameters.AddWithValue("@id", ID);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Response was unsuccessful", "Error : Quote failure", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            Program.cnn.Close();
        }
        private void updateTripsDatabase(String update,String code, String value)
        {
            Program.cnn.Open();
            SqlCommand command;
            command = new SqlCommand("UPDATE trips SET " + update + " = @update WHERE tripCode = @id ", Program.cnn);
            command.Parameters.AddWithValue("@update", value);
            command.Parameters.AddWithValue("@id", code);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Response was unsuccessful", "Error : Quote failure", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            Program.cnn.Close();
        }
        public int getQuoteSize()
        {
            Int32 count = 0;
            SqlCommand execute = new SqlCommand("Select Count(*) From Ticket", Program.cnn);
            Program.cnn.Open();
            try
            {
                count = (Int32)execute.ExecuteScalar();
            }
            catch
            {

            }
            Program.cnn.Close();
            return count;
        }
        private int viewQuoteID(int ID)
        {
            SqlCommand execute = new SqlCommand("SELECT * FROM Quotes where id =@ID", Program.cnn);
            execute.Parameters.AddWithValue("@ID", ID);
            Program.cnn.Open();
            try
            {

                using (SqlDataReader reader = execute.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ID = 1;
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
            return ID;
        }
        public void memberRemoveFrom(int ticketID)
        {
            Ticket t = new Ticket();
            if (t.getPaid(ticketID) != "no")
            {
                return;
            }
            else
            {
                staffRemoveFrom(ticketID);
            }
        }
        public void staffRemoveFrom(int ticketID)
        {
            SqlCommand execute = new SqlCommand("DELETE FROM Ticket WHERE ticketID= @ticketID", Program.cnn);
            execute.Parameters.AddWithValue("@ticketID", ticketID);
            Program.cnn.Open();
            try
            {

                int sqltest = execute.ExecuteNonQuery();
                if (sqltest >= 0)
                {
                    MessageBox.Show("item removed!", "Remove unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                else
                {
                    MessageBox.Show("item does not exsist", "Remove unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
            }
            catch
            {
                MessageBox.Show("Cannot remove item!", "Review unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            Program.cnn.Close();
        }    
        public void addTrip(string tripcode, string destination,string price,string triptime,string date,string image)
        {
            try
            {
                Program.cnn.Open();
                string query = "INSERT INTO trips (tripCode,destination,price,tripTime,date,image) VALUES ('" + tripcode+ "','" + destination + "','" + price + "','" + triptime + "','" + date + "','" + image+ "')";
                SqlCommand execute = new SqlCommand(query, Program.cnn);
                execute.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Trip already exists", "Error : Trip failure", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Program.cnn.Close();

            }
            Program.cnn.Close();
        }
        public void updateTrip(string tripcode, string destination, string price, string triptime, string date, string image)
        {            
            if(destination != null)
                updateTripsDatabase("destination", tripCode, destination);
            if(price != null)
                updateTripsDatabase("price", tripCode, price);
            if(triptime != null)
                updateTripsDatabase("tripTime", tripCode, triptime);
            if(date != null)
                updateTripsDatabase("date", tripCode, date);
            if(image != null)
                updateTripsDatabase("image", tripCode, image);
        }
        public void removeTrip(string tripcode)
        {
            SqlCommand execute = new SqlCommand("DELETE FROM trips WHERE tripCode= @tripcode", Program.cnn);
            execute.Parameters.AddWithValue("@tripcode", tripcode);
            Program.cnn.Open();
            try
            {

                int sqltest = execute.ExecuteNonQuery();
                if (sqltest >= 0)
                {
                    MessageBox.Show("item removed!", "Remove unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                else
                {
                    MessageBox.Show("item does not exsist", "Remove unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
            }
            catch
            {
                MessageBox.Show("Cannot remove item!", "Review unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            Program.cnn.Close();
        }
    }
}
