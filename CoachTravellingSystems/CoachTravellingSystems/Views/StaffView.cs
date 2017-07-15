using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoachTravellingSystems
{
    public partial class StaffView : Form
    {
        private Basket b = new Basket();
        List<TextBox> allFields = new List<TextBox>();
        List<Label> labels = new List<Label>();
        List<Button> buttons = new List<Button>();
        public StaffView()
        {
            InitializeComponent();
            populateFields();
            welcomeLabel.Text = "Welcome " + Program.member.username;
            quoteField.ReadOnly = true;
            reviewBox.ReadOnly = true;
            viewBox.ReadOnly = true;
            ownedTickets.ReadOnly = true;
            checkoutBox.ReadOnly = true;
            memberDetailsBox.ReadOnly = true;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }        
        private void searchButton_Click(object sender, EventArgs e)
        {
            String type = searchBox.Text;
            if (Program.trip.checkTripCode(type))
            {
                viewBox.Text = "Trip Code : " + Program.trip.tripCode + "\n";
                viewBox.Text += "Trip Name : " + Program.trip.destination + "\n";
                viewBox.Text += "Trip Price: " + Program.trip.price + "\n";
                viewBox.Text += "Trip Time : " + Program.trip.time + "\n\n";
                reviewBox.Text = Program.trip.review;
            }
            else if (!type.Contains("CTS-0"))
            {
                if (Program.trip.checkTripCode("CTS-0" + type))
                {
                    viewBox.Text = "Trip Code : " + Program.trip.tripCode + "\n";
                    viewBox.Text += "Trip Name : " + Program.trip.destination + "\n";
                    viewBox.Text += "Trip Price: " + Program.trip.price + "\n";
                    viewBox.Text += "Trip Time : " + Program.trip.time + "\n\n";
                    reviewBox.Text = Program.trip.review;
                }
                else
                {
                    populateFields();
                    MessageBox.Show("Could not find trip", "Error : No trip found", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
            else
            {
                populateFields();
                MessageBox.Show("Could not find trip", "Error : No trip found", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void searchMember(object sender, EventArgs e)
        {
            memberDetailsBox.Text = "";
            usernamelabel.Text = "Customer/" + memberBox.Text;
            if (searchAllMembers(memberBox.Text))
            {
                setMemberDetails(memberDetailsBox.Text);
                String check = Program.trip.getQuote(memberBox.Text);
                if (check != "CTS-Invalid" && check != null)
                    quoteField.Text = check;
                else
                    quoteField.Text = "No quotes left from this user";
            }
            else
            {

            } 

        }
        private void setMemberDetails(string username)
        {
            memberDetailsBox.Text += "Username  : " + Program.member.user.username;
            memberDetailsBox.Text += "\nFirst name : " + Program.member.user.getFirstName(username);
            memberDetailsBox.Text += "\nLast name : " + Program.member.user.getLastName(username);
        }
        private Boolean searchAllMembers(String username)
        {
            if (Program.member.isCustomer(userType.Customer, username, "Override-Code1111"))
                return true;
            else if (Program.member.isCustomer(userType.Salesman, username, "Override-Code1111"))
                return true;
            else if (Program.member.isCustomer(userType.Driver, username, "Override-Code1111"))
                return true;
            else
                MessageBox.Show("Account username could not be Found", "Error : Does not exist", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            return false;
        }

        private void tabChangeControl(object sender, EventArgs e)
        {
            idBox.BackColor = Color.White;
            responeBox.BackColor = Color.White;
            searchBox.BackColor = Color.White;
            memberBuyBox.BackColor = Color.White;
            addMemberBox.BackColor = Color.White;
            addCodeBox.BackColor = Color.White;
            checkoutBox.Text = b.printBasket(addMemberBox.Text);
            ownedTickets.Text = b.AllTickets();

        }
        private void updateButton_Click(object sender, EventArgs e)
        {
            String username = Program.member.StringCheck(usernameField.Text);
            String password = Program.member.StringCheck(passwordField.Text);
            String confirm = Program.member.StringCheck(confirmField.Text);
            String fname = Program.member.StringCheck(firstnameField.Text);
            String lname = Program.member.StringCheck(lastnameField.Text);
            if (username == null && password == null && fname == null && lname == null && confirm == null)
            {
                MessageBox.Show("Account could not be created\n All fields are empty", "Error : update failure", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else if (password == confirm)
            {
                if (memberRadio.Checked)
                    Program.member.updateCustomer(username, password, fname, lname, null, null, null);
                else if (salesmanRadio.Checked)
                    Program.member.updateStaff(username, password, fname, lname);
                else if (driverRadio.Checked)
                    Program.member.updateDriver(username, password, fname, lname);
                else
                {
                    MessageBox.Show("No account option selected", "Error : update failure", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                MessageBox.Show("Update was successful", "Update success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
                MessageBox.Show("Could not update", "Error : update failure", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            MainScreen s = new MainScreen();
            s.ShowDialog();
        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            b.buyTickets();
            checkoutBox.Text = b.printBasket();
            MessageBox.Show("Thank you for your purchase", "Thank you ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        private void removeButton_Click(object sender, EventArgs e)
        {          
            if (removeBox.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete this acount?\n" + removeAccountBox.Text, "Delete option", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        Program.trip.staffRemoveFrom(int.Parse(removeBox.Text));
                        ownedTickets.Text = b.AllTickets();
                    }
                    catch
                    {
                        MessageBox.Show("Invalid input", "update failure ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }                   
                }
                else
                    MessageBox.Show("Remove cancelled", "Confirm : Cancel ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
        private void populateFields()
        {
            viewBox.Text = "";
            for (int i = 1; i < 11; i++)
            {
                if (Program.trip.checkTripCode("CTS-0" + i))
                {
                    viewBox.Text += "Trip Code : " + Program.trip.tripCode + "\n";
                    viewBox.Text += "Trip Name : " + Program.trip.destination + "\n";
                    viewBox.Text += "Trip Price: " +Program.trip.price + "\n";
                    viewBox.Text += "Trip Time : " + Program.trip.time + "\n\n";                    
                }
            }
        }
        private void insertButton_Click(object sender, EventArgs e)
        {
            String username = Program.member.StringCheck(usernameField.Text);
            String password = Program.member.StringCheck(passwordField.Text);
            String confirm = Program.member.StringCheck(confirmField.Text);
            String fname = Program.member.StringCheck(firstnameField.Text);
            String lname = Program.member.StringCheck(lastnameField.Text);
            if (username == null || password == null || fname == null || lname == null || confirm == null)
            {
                MessageBox.Show("Account could not be created\n One or more fields are empty", "Error : update failure", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else if (password == confirm)
            {
                if (memberRadio.Checked)
                    Program.member.addCustomer(username, password, fname, lname);
                else if (salesmanRadio.Checked)
                    Program.member.addStaff(username, password, fname, lname);
                else if (driverRadio.Checked)
                    Program.member.addDriver(username, password, fname, lname);
                else
                {
                    MessageBox.Show("Account could not be created\n No account option selected", "Error : update failure", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                MessageBox.Show("Account has been created", "Update success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
                MessageBox.Show("Account could not be created\n Passwords do no match", "Error : update failure", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }
        //Password Override-Code1111
        private void removeAccountButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete this acount?\n" + removeAccountBox.Text, "Delete option", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (Program.member.isCustomer(userType.Customer, removeAccountBox.Text, "Override-Code1111"))
                    Program.member.deleteAccount("Customer", removeAccountBox.Text);
                else if (Program.member.isCustomer(userType.Salesman, removeAccountBox.Text, "Override-Code1111"))
                    Program.member.deleteAccount("staff", removeAccountBox.Text);
                else if (Program.member.isCustomer(userType.Driver, removeAccountBox.Text, "Override-Code1111"))
                    Program.member.deleteAccount("Driver", removeAccountBox.Text);
                else
                {
                    MessageBox.Show("Account username could not be deleted", "Error : Does not exist", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return;
                }
                MessageBox.Show("Account has been deleted", "Confirm : Account ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            } 
            else
            {
                MessageBox.Show("Account was not deleted", "Option : No", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void replyButton_Click(object sender, EventArgs e)
        {
            if (idBox.Text == "")
                idBox.BackColor = Color.Red;
            else if (responeBox.Text == "")
                responeBox.BackColor = Color.Red;
            else
            {
                Program.trip.replyQuote(int.Parse(idBox.Text), responeBox.Text);
                MessageBox.Show("Reponse sent", "Update success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                idBox.BackColor = Color.White;
                responeBox.BackColor = Color.White;
            }

        }

        private void atToBasketButton_Click(object sender, EventArgs e)
        {
            addMemberBox.BackColor = Color.White;
            addCodeBox.BackColor = Color.White;
            String search = addCodeBox.Text;
            String username = addMemberBox.Text;
            if (username == "" && search == "")
            {
                addMemberBox.BackColor = Color.Red;
                addCodeBox.BackColor = Color.Red;
            }
            if (username == "")
                addMemberBox.BackColor = Color.Red;            
            else if (search == "")
                addCodeBox.BackColor = Color.Red;
            else
            {
                int amount = 1;
                try
                {
                    amount = int.Parse(addAmountBox.Text);

                }
                catch
                {

                }
                if (book(username, search))
                {
                    for (int i = 0; i < amount; i++)
                    {
                        Program.trip.addTicket(Program.ticketCount, username, Program.trip.tripCode);
                    }
                    MessageBox.Show("Added to basket!", "Review unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    checkoutBox.Text = b.printBasket(addMemberBox.Text);
                }

                
            }
        }

        private void bookNow_Click(object sender, EventArgs e)
        {
            memberBuyBox.BackColor = Color.White;
            searchBox.BackColor = Color.White;
            String search = searchBox.Text;
            String username = memberBuyBox.Text;
            if(username == "" && search == "")
            {
                memberBuyBox.BackColor = Color.Red;
                searchBox.BackColor = Color.Red;
            }
            else if (username == "")
                memberBuyBox.BackColor = Color.Red;            
            else if (search == "")
                searchBox.BackColor = Color.Red;
            else
            {               
                int amount = 1;
                try
                {
                    amount = int.Parse(amountField.Text);

                }
                catch
                {

                }
                if (book(username, search))
                {
                    for (int i = 0; i < amount; i++)
                    {
                        Program.trip.addTicket(Program.ticketCount, username, Program.trip.tripCode);
                    }
                    MessageBox.Show("Added to basket!", "Review unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    checkoutBox.Text = b.printBasket(addMemberBox.Text);
                }
            }            

        }
        private Boolean book(String username, String search)
        {
            if (Program.trip.checkTripCode(search))
            {
                if (Program.member.isCustomer(userType.Customer, username, "Override-Code1111"))
                    return true;
                else if (Program.member.isCustomer(userType.Salesman, username, "Override-Code1111"))
                    return true;
                else if (Program.member.isCustomer(userType.Driver, username, "Override-Code1111"))
                    return true;
                else
                    MessageBox.Show("Account username could not be Found", "Error : Does not exist", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return false;
            }
            else if (!search.Contains("CTS-0"))
            {
                if (Program.trip.checkTripCode("CTS-0" + search))
                {
                    if (Program.member.isCustomer(userType.Customer, username, "Override-Code1111"))
                        return true;
                    else if (Program.member.isCustomer(userType.Salesman, username, "Override-Code1111"))
                        return true;
                    else if (Program.member.isCustomer(userType.Driver, username, "Override-Code1111"))
                        return true;
                    else
                        MessageBox.Show("Account username could not be Found", "Error : Does not exist", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return false;
                } else
                {
                    return false;
                }
            } else
                return false;
        }

        private void clearBasketButton_Click(object sender, EventArgs e)
        {
            b.clearBaskets(addMemberBox.Text);
            checkoutBox.Text = b.printBasket(addMemberBox.Text);
            MessageBox.Show("Basket cleared", "Basket removal", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void removeBasket(object sender, EventArgs e)
        {
            if (removeBasketField.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete this ticket?\n" + removeBasketField.Text, "Delete option", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        Program.trip.memberRemoveFrom(int.Parse(removeBasketField.Text));
                        checkoutBox.Text = b.printBasket(addMemberBox.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Invalid input", "update failure ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    }
                }
                else
                    MessageBox.Show("Remove cancelled", "Confirm : Cancel ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void newTripButton_Click(object sender, EventArgs e)
        {
            String tripcode = Program.member.StringCheck(codeTripBox.Text);
            String destination = Program.member.StringCheck(destTripBox.Text);
            String price = Program.member.StringCheck(priceTripBox.Text);
            String triptime = Program.member.StringCheck(timeTripBox.Text);
            if (tripcode == null || destination == null || price == null || triptime == null)
            {
                MessageBox.Show("Account could not be created\n All fields are empty", "Error : update failure", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                Program.trip.addTrip(tripcode, destination, price, triptime, null, null);
                MessageBox.Show("Update was successful", "Update success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                populateFields();
            }
        }

        private void updateTripButton_Click(object sender, EventArgs e)
        {
            String tripcode = Program.member.StringCheck(codeTripBox.Text);
            String destination = Program.member.StringCheck(destTripBox.Text);
            String price = Program.member.StringCheck(priceTripBox.Text);
            String triptime = Program.member.StringCheck(timeTripBox.Text);
            String date = Program.member.StringCheck(dateTripBox.Text);
            String image = Program.member.StringCheck(imageTripBox.Text);
           
            if (destination == null && price == null && triptime == null && date == null && image == null)
            {
                MessageBox.Show("Account could not be created\n All fields are empty", "Error : update failure", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                if (Program.trip.checkTripCode(tripcode))
                {
                    Program.trip.updateTrip(tripcode, destination, price, triptime, date, image);
                    MessageBox.Show("Update was successful", "Update success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    populateFields();               
                }
            }
        }

        private void removeTripButton_Click(object sender, EventArgs e)
        {
            if(Program.trip.checkTripCode(removeTripBox.Text))
                Program.trip.removeTrip(removeTripBox.Text);
        }

        private void addMemberBox_TextChanged(object sender, EventArgs e)
        {
            checkoutBox.Text = b.printBasket(addMemberBox.Text);
        }
    }
}
