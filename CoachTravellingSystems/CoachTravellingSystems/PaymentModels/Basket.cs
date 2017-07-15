using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoachTravellingSystems
{
    class Basket
    {
        Ticket t = new Ticket();
        public string printBasket()
        {
            string basket = null;
            for(int i = 0; i < Program.ticketCount; i++)
            {
                if(t.viewTicketID(i) != -1 && t.viewTicketHolder(i) == Program.member.username && t.getPaid(i) == "no")
                    basket += i + " : " + t.holderName + " : " + t.viewTripCode(i)+ "\n";
            }
            return basket;
        }
        public string printBasket(String username)
        {
            string basket = null;
            for (int i = 0; i < Program.ticketCount; i++)
            {
                if (t.viewTicketID(i) != -1 && t.viewTicketHolder(i) == username && t.getPaid(i) == "no")
                    basket += i + " : " + t.holderName + " : " + t.viewTripCode(i) + "\n";
            }
            return basket;
        }
        public void buyTickets()
        {
            for (int i = 0; i < Program.ticketCount; i++)
            {
                if (t.viewTicketID(i) != -1 && t.viewTicketHolder(i) == Program.member.username && t.getPaid(i) == "no")
                {
                    SqlCommand execute = new SqlCommand("Update Ticket SET paid = 'yes' WHERE ticketID=@ticketID", Program.cnn);
                    execute.Parameters.AddWithValue("@ticketID", i);
                    Program.cnn.Open();
                    try
                    {
                        execute.ExecuteNonQuery();                       
                    }
                    catch
                    {
                        MessageBox.Show("Purchase unsuccessful!", "Error : Purchase unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Program.cnn.Close();
                        return;
                    }
                    Program.cnn.Close();
                }
            }
        }
        public void clearBaskets(String username)
        {
            for (int i = 0; i < Program.ticketCount; i++)
            {
                if (t.viewTicketID(i) != -1 && t.viewTicketHolder(i) == username && t.getPaid(i) == "no")
                {
                    SqlCommand execute = new SqlCommand("DELETE FROM Ticket WHERE ticketID=@ticketID", Program.cnn);
                    execute.Parameters.AddWithValue("@ticketID", i);
                    Program.cnn.Open();
                    try
                    {
                        execute.ExecuteNonQuery();
                    }
                    catch
                    {
                        MessageBox.Show("Failed to remove", "Error : removal unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        Program.cnn.Close();
                        return;
                    }
                    Program.cnn.Close();
                }
            }
        }
        public string boughtTickets()
        {
            string basket = null;
            for (int i = 0; i < Program.ticketCount; i++)
            {
                if (t.viewTicketID(i) != -1 && t.viewTicketHolder(i) == Program.member.username && t.getPaid(i) == "yes")
                    basket += i + " : " + t.holderName + " : " + t.viewTripCode(i) + "\n";
            }
            return basket;
        }
        public string AllTickets()
        {
            string tickets = null;
            for (int i = 0; i < Program.ticketCount; i++)
            {
                if (t.viewTicketID(i) != -1)                
                    tickets += "Ticket No. :" + i + " Name : " + t.viewTicketHolder(i)+ " \nTrip code :" + t.viewTripCode(i) + " Paid : " + t.getPaid(i) + "\n\n";
                
                   
            }
            return tickets;
        }
        public void changeTicketOwner(String owner)
        {
            for (int i = 0; i < Program.ticketCount; i++)
            {
                if (t.viewTicketID(i) != -1 && t.viewTicketHolder(i) == Program.member.username)
                {
                    SqlCommand execute = new SqlCommand("Update Ticket SET holderName = @username WHERE ticketID=@ticketID", Program.cnn);
                    execute.Parameters.AddWithValue("@ticketID", i);
                    execute.Parameters.AddWithValue("@username", owner);
                    Program.cnn.Open();
                    try
                    {
                        execute.ExecuteNonQuery();
                    }
                    catch
                    {
                        Program.cnn.Close();
                        return;
                    }
                    Program.cnn.Close();
                }

            }
        }
    }
}
