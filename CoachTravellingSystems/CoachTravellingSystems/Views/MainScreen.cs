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
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (Program.member.isCustomer(userType.Customer, textBox1.Text, textBox2.Text))
            {
                this.Visible = false;
                CustomerView customerView = new CustomerView();
                customerView.ShowDialog();
                
            }
            else if(Program.member.isCustomer(userType.Salesman, textBox1.Text, textBox2.Text))
            {
                    this.Visible = false;
                    StaffView staffView = new StaffView();
                    staffView.ShowDialog();
            }
            else if (Program.member.isCustomer(userType.Driver, textBox1.Text, textBox2.Text))
            {
                this.Visible = false;
                StaffView staffView = new StaffView();
                staffView.ShowDialog();
            }
            else
            {
                MessageBox.Show("Incorrect password or username", "error",MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }      
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if(confirmBox.Text != passwordBox.Text)
                MessageBox.Show("Passwords do not match", "Password error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            if( usernameBox.Text == "")
                MessageBox.Show("Username field is empty", "Password error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            if (passwordBox.Text == "")
                MessageBox.Show("Password field is empty", "Password error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            if (fnameBox.Text == "")
                MessageBox.Show("Firstname field is empty", "Password error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            if (fnameBox.Text == "")
                MessageBox.Show("Lastname field is empty", "Password error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            else
            {
                Program.member.addCustomer(usernameBox.Text,passwordBox.Text,fnameBox.Text,lnameBox.Text);
                this.Visible = false;
                CustomerView customerView = new CustomerView();
                customerView.ShowDialog();
            }
               
        }
    }
}
