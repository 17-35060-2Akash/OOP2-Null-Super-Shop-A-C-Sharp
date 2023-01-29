using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Null_Super_Shop_A_.Business_Logic_Layer;
using Null_Super_Shop_A_.Presentation_Layer;

namespace Null_Super_Shop_A_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();


        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoginService loginService = new LoginService();
            int result = loginService.LoginValidation(usernameTextBox.Text, passwordTextBox.Text);
            if (result == 0)
            {
                Dashboard ds = new Dashboard();
                this.Hide();
                ds.Show();
            }
            else if (result == 2)
            {
                DashboardEmp de = new DashboardEmp();
                this.Hide();
                de.Show();
            }
            else if (result == 1)
            {
                ManageCategory manageCategory = new ManageCategory();
                this.Hide();
                manageCategory.Show();
            }
            else
            {
                MessageBox.Show("Invalid username or password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddEmploye ae = new AddEmploye();
            ae.Show();
            this.Hide();
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            UpdateEmployee up = new UpdateEmployee();
            up.Show();
            this.Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

