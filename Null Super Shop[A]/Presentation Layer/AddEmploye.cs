using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Null_Super_Shop_A_.Presentation_Layer
{
    public partial class AddEmploye : Form
    {
        public AddEmploye()
        {
            InitializeComponent();
        }

        private void AddEmploye_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void uploadbtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *jpeg; *.gif; *.bmp;)|*.jpg; *jpeg; *.gif; *.bmp;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                picturetextBox.Text = open.FileName;
                pictureBox1.Image = new Bitmap(open.FileName);

            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {


            if (nameTextBox.Text == "")
            {
                MessageBox.Show("Name can not be empty");
            }

            else if (emailTextBox.Text == "")
            {
                MessageBox.Show("Email can not be empty");
            }
            else if (NIDtextBox.Text == "")
            {
                MessageBox.Show("NID can not be empty");
            }
            else if (dateOfBirthDateTimePicker.Text == "")
            {
                MessageBox.Show("Select a date of birth");
            }
            else if (picturetextBox.Text == "")
            {
                MessageBox.Show("Picture Location can not be empty");
            }
            else if (addressTextBox.Text == "")
            {
                MessageBox.Show("Address can not be empty");
            }

            else if (phoneTextBox.Text == "")
            {
                MessageBox.Show("Phone Number can not be empty");
            }

            else if (bloodGroupComboBox.Text == "")
            {
                MessageBox.Show("Select a blood group");
            }
            else if (salarytextBox.Text == "")
            {
                MessageBox.Show("Please add  a salary");
            }

            else if (maleRadioButton.Checked == false && femaleRadioButton.Checked == false)
            {
                MessageBox.Show("Select a gender");
            }
            else if (statuscomboBox.Text == "")
            {

                
                MessageBox.Show("Please add  a status");
            }
            else
            {

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NullSuperShop"].ConnectionString);
                connection.Open();
                string gender = "";
                int status = Convert.ToInt32(statuscomboBox.Text);
                if (maleRadioButton.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                string sql = "INSERT INTO Users(Username,Password,Email,NidNumber,DateOfBirth,Picture,Address,PhoneNumber,BloodGroup,Salary,UserType,Gender) VALUES('" + nameTextBox.Text + "','" + passwordTextBox.Text + "','" + emailTextBox.Text + "','" + NIDtextBox.Text + "','" + dateOfBirthDateTimePicker.Text + "','" + picturetextBox.Text+ "','" + addressTextBox.Text + "','" + phoneTextBox.Text + "','" + bloodGroupComboBox.Text + "','" +  salarytextBox.Text + "', '"+statuscomboBox.Text+"','" + gender + "')";
                SqlCommand command = new SqlCommand(sql, connection);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("User updated.");
                    AddEmploye am = new AddEmploye();
                     this.Hide();
                    am.Show();
                }
                else
                {
                    MessageBox.Show("Error");
                }
                connection.Close();



                File.Copy(picturetextBox.Text, Path.Combine(@"C:\Users\Rushdi\source\repos\Null Super Shop[A]\Null Super Shop[A]\EmpPicture", Path.GetFileName(picturetextBox.Text)), true);
            }
        }

        private void termsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (termsCheckBox.Checked)
            {
                submitButton.Enabled = true;
            }
            else
                submitButton.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void AddEmploye_Load(object sender, EventArgs e)
        {

        }
    }
}

