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
    public partial class CustomerView : Form
    {
        Basket b = new Basket();
        public CustomerView()
        {
            InitializeComponent();   
            populateFields();
            welcomeLabel.Text = "Welcome " + Program.member.username;
            pQuoteBox.ReadOnly = true;
            reviewBox.ReadOnly = true;
            viewBox.ReadOnly = true;
            ownedTickets.ReadOnly = true;
            checkoutBox.ReadOnly = true;
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
            } else if (!type.Contains("CTS-0"))
            {
                if (Program.trip.checkTripCode("CTS-0" + type))
                {
                    viewBox.Text = "Trip Code : " + Program.trip.tripCode + "\n";
                    viewBox.Text += "Trip Name : " + Program.trip.destination + "\n";
                    viewBox.Text += "Trip Price: " + Program.trip.price + "\n";
                    viewBox.Text += "Trip Time : " + Program.trip.time + "\n\n";
                    reviewBox.Text = Program.trip.review;
                } else
                {

                    MessageBox.Show("Could not find trip", "Error : No trip found", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            } else
            {

                MessageBox.Show("Could not find trip", "Error : No trip found", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }
      

        private void tabChangeControl(object sender, EventArgs e)
        {
            Color color = Color.White;
            uQuoteBox.BackColor = color;
            sQuoteBox.BackColor = color;
            checkoutBox.Text = b.printBasket();
            ownedTickets.Text = b.boughtTickets();
            showQuestions();
        }

        private void reviewButton_Click(object sender, EventArgs e)
        {
            String tripcode = tripCodeBox.Text;
            String review = Program.member.username + ": " + reviewField.Text;
            Program.trip.leaveReview(tripcode,review);
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            
            String username = (usernameField.Text == "" ? null : usernameField.Text);
            String password = (passwordField.Text == "" ? null : passwordField.Text);
            String confirm = (confirmField.Text == "" ? null : confirmField.Text);
            String fname = (firstnameField.Text == "" ? null : firstnameField.Text);
            String lname = (lastnameField.Text == "" ? null : lastnameField.Text);
            String address = (houseNumberField.Text == "" ? null : houseNumberField.Text + addressField.Text + countyField.Text + countryField.Text);
            String mobile = (mobileField.Text == "" ? null : mobileField.Text);
            String email = (emailField.Text == "" ? null : emailField.Text);
            if (password == confirm)
            {
                Program.member.updateCustomer(username, password, fname, lname, email, mobile, address);
                fieldResetView();
                MessageBox.Show("Update was successful", "Update success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
                
            else
                MessageBox.Show("Could not update", "Error : update failure", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }
        private void fieldResetView()
        {
            usernameField.Text = "";
            passwordField.Text = "";
            confirmField.Text = "" ;
            firstnameField.Text = "";
            lastnameField.Text = "";
            houseNumberField.Text = "";
            addressField.Text = "";
            countyField.Text = "";
            countryField.Text = "";
            mobileField.Text = "";
            emailField.Text = "";
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Program.member.resetMemeber();
            MainScreen s = new MainScreen();
            s.ShowDialog();
        }
        private void checkoutBox_TextChanged(object sender, EventArgs e)
        {

        }

    

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (removeBox.Text != "")
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you wish to delete this ticket?\n" + removeBox.Text, "Delete option", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        Program.trip.memberRemoveFrom(int.Parse(removeBox.Text));
                        checkoutBox.Text = b.printBasket();
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
                    viewBox.Text += "Trip Price: " + Program.trip.price + "\n";
                    viewBox.Text += "Trip Time : " + Program.trip.time + "\n\n";
                    reviewBox.Text = Program.trip.review;
                }
            }
        }
        private void quoteSend (object sender, EventArgs e)
        {
            Color color = Color.Red;
            if (uQuoteBox.Text == "" || uQuoteBox.Text != Program.member.username)
                uQuoteBox.BackColor = color;
            else if (sQuoteBox.Text == "")
                sQuoteBox.BackColor = color;
            else
            {
                Program.trip.sendQuote(uQuoteBox.Text, sQuoteBox.Text);
                
                
            }
        }
        private void showQuestions()
        {
            
            String check = Program.trip.getQuote(Program.member.username);
            if (check != "CTS-Invalid" && check != null)
                pQuoteBox.Text = check;
            else
                pQuoteBox.Text = "You have no questions.";
        }

        private void atToBasketButton_Click(object sender, EventArgs e)
        {

        }

        private void buyButton_Click(object sender, EventArgs e)
        {
            b.buyTickets();
            checkoutBox.Text = b.printBasket();
            MessageBox.Show("Thank you for your purchase", "Thank you ", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void bookNow_Click(object sender, EventArgs e)
        {
            searchBox.BackColor = Color.White;
            String search = searchBox.Text;
            
            if (search == "")
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
                for (int i = 0; i < amount; i++)
                {
                    Program.trip.addTicket(Program.ticketCount, Program.member.username, Program.trip.tripCode);
                }
                MessageBox.Show("Added to basket!", "Review unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }

        }

        private void atToBasketButton_Click_1(object sender, EventArgs e)
        {
            addCodeBox.BackColor = Color.White;
            String search = addCodeBox.Text;
            if (search == "")
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
                for (int i = 0; i < amount; i++)
                {
                    Program.trip.addTicket(Program.ticketCount, Program.member.username, Program.trip.tripCode);
                }
                MessageBox.Show("Added to basket!", "Review unsuccessful", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void clearBasketButton_Click(object sender, EventArgs e)
        {
            b.clearBaskets(Program.member.username);
            checkoutBox.Text = b.printBasket();
            MessageBox.Show("Basket cleared", "Basket removal", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void pQuoteBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
