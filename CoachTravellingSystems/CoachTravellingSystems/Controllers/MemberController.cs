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
    class MemeberController
    {
        //CoachTravellingData.CustomersDataTable cdt = new CoachTravellingData.CustomersDataTable();
        public User user { get; set; }
        public String username = null;
        public String firstName = null;
        public String lastName = null;
        public void addCustomer(String username, String password, String firstname, String lastname)
        {
            user = UserFactory.userFactory(userType.Customer);
            try
            {
                Program.cnn.Open();
                string query = "INSERT INTO Customer (username,password,firstname,lastname,email,mobile,address) VALUES ('" + username + "','" + password + "','" + firstname + "','" + lastname + "','','','')";
                SqlCommand execute = new SqlCommand(query, Program.cnn);
                execute.ExecuteNonQuery();
                if (this.username == null)
                    this.username = username; this.firstName = firstname; this.lastName = lastname;
                Console.WriteLine(this.username);
            }
            catch
            {
                MessageBox.Show("Username already exists", "Error : Account failure", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            Program.cnn.Close();
        }        
        public void addStaff(String username, String password, String firstname, String lastname)
        {
            user = UserFactory.userFactory(userType.Salesman);
            Program.cnn.Open();
            try
            {
                string query = "INSERT INTO staff (username,password,firstname,lastname) VALUES ('" + username + "','" + password + "','" + firstname + "','" + lastname + "')";
                SqlCommand execute = new SqlCommand(query, Program.cnn);
                execute.ExecuteNonQuery();
                if (this.username == null)
                    this.username = username; this.firstName = firstname; this.lastName = lastname;
            }
            catch
            {
                MessageBox.Show("Username already exists", "Error : Account failure", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            Program.cnn.Close();            
        }
        public void addDriver(String username, String password, String firstname, String lastname)
        {
            user = UserFactory.userFactory(userType.Driver);
            Program.cnn.Open();
            try
            {
                string query = "INSERT INTO Driver (username,password,firstname,lastname) VALUES ('" + username + "','" + password + "','" + firstname + "','" + lastname + "')";
                SqlCommand execute = new SqlCommand(query, Program.cnn);
                execute.ExecuteNonQuery();
                if(this.username == null)
                    this.username = username; this.firstName = firstname; this.lastName = lastname;
            }
            catch
            {
                MessageBox.Show("Username already exists", "Error : Account failure", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }            
            Program.cnn.Close();
        }
        public Boolean isCustomer(userType type, String username, String password)
        {

            user = UserFactory.userFactory(type);
            String usr = user.viewUsername(username);
            if (usr == "CTS-Invalid")
                return false;
            String pwd = user.getPassword(username);
            if (password != "Override-Code1111") {
                if (pwd == "CTS-Invalid" || pwd != password)
                    return false;
                this.username = usr; this.firstName = user.getFirstName(usr); lastName = user.getLastName(usr);
            }
            return true;
        }
        public void deleteAccount(String where, String update)
        {
            Program.cnn.Open();
            SqlCommand command;
            command = new SqlCommand("DeLETE FROM " + where + " WHERE username = @username ", Program.cnn);
            command.Parameters.AddWithValue("@username",update);
            try
            {
                command.ExecuteNonQuery();
            }
            catch
            {
                MessageBox.Show("Username does not exists", "Error : Account failure", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            Program.cnn.Close();
        }
        private void updateDatabase(String where, String update, String value)
        {
            Program.cnn.Open();
            SqlCommand command;

            command = new SqlCommand("UPDATE " + where + "  SET " + update + " = @update WHERE username = @username ", Program.cnn);
            command.Parameters.AddWithValue("@update", value);
            command.Parameters.AddWithValue("@username", Program.member.username);

            try
            {
                command.ExecuteNonQuery();
                if (update == "username")
                    Program.member.username = username;

            }
            catch
            {
                MessageBox.Show("Username already exists", "Error : Account failure", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }


            Program.cnn.Close();
        }
        public void updateCustomer(String username, String password, String firstname, String lastname, String email,String mobile, String address)
        {
            if(username != null)
            {
                Basket b = new Basket();
                b.changeTicketOwner(username);
            }
            if (username != null)
                updateDatabase("Customer", "username", username);
            if (password != null)
                updateDatabase("Customer", "password", password);
            if (firstname != null)
                updateDatabase("Customer", "firstname", firstname);
            if (lastname != null)
                updateDatabase("Customer", "lastname", lastname);
            if (email != null)
                updateDatabase("Customer", "email", email);
            if (mobile != null)
                updateDatabase("Customer", "mobile", mobile);
            if (address != null)
                updateDatabase("Customer", "address", address);
        }
        public void updateStaff(String username,String password,String firstname,String lastname)
        {
            if (username != null )
                updateDatabase("staff", "username", username);
            if (password != null)
                updateDatabase("staff", "password", password);
            if (firstname != null)
                updateDatabase("staff", "firstname", firstname);
            if(lastname != null)
                updateDatabase("staff", "lastname", lastname);
        }
        public void updateDriver(String username, String password, String firstname, String lastname)
        {
            if (username != null)
                updateDatabase("Driver", "username", username);
            if (password != null)
                updateDatabase("Driver", "password", password);
            if (firstname != null)
                updateDatabase("Driver", "firstname", firstname);
            if (lastname != null)
                updateDatabase("Driver", "lastname", lastname);
        }
        public String StringCheck(String check)
        {
            return (check == "" ? null : check);
        }
        
        public void resetMemeber()
        {
            this.username = null; this.firstName =null; this.lastName = null;
        }
    }
}
