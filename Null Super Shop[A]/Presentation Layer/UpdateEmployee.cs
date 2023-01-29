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
using Null_Super_Shop_A_.Data_Access_Layer.Entities;

namespace Null_Super_Shop_A_.Presentation_Layer
{
    public partial class UpdateEmployee : Form
    {
        public UpdateEmployee()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void UpdateEmployee_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void UpdateEmployee_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NullSuperShop"].ConnectionString);
            connection.Open();
            string sql = "SELECT * FROM Users ";
            SqlCommand command = new SqlCommand(sql, connection);
            List<User> users = new List<User>();
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                User user = new User();
                user.UserId = (int)reader["UserId"];
                user.Username = reader["Username"].ToString();
                user.Password = reader["Password"].ToString();
                user.Email = reader["Email"].ToString();
                user.NidNumber = reader["NidNumber"].ToString();
                user.DateOfBirth = reader["DateOfBirth"].ToString();
                user.Address = reader["Address"].ToString();
                user.PhoneNumber = reader["PhoneNumber"].ToString();
                user.BloodGroup = reader["BloodGroup"].ToString();
                user.Salary = reader["Salary"].ToString();
                user.Gender = reader["Gender"].ToString();
                user.UserType = reader["UserType"].ToString();
                user.Picture = reader["Picture"].ToString();
                users.Add(user);
            }
            connection.Close();
            UpdEmpdataGridView1.DataSource = users;

        }

        private void UpdEmpdataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            idTextBox.Text = UpdEmpdataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            nameTextBox.Text = UpdEmpdataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            passwordTextBox.Text = UpdEmpdataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            emailTextBox.Text = UpdEmpdataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            NIDtextBox.Text = UpdEmpdataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            dateOfBirthDateTimePicker.Text = UpdEmpdataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            addressTextBox.Text = UpdEmpdataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            phoneTextBox.Text = UpdEmpdataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            bloodGroupComboBox.Text = UpdEmpdataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            salarytextBox.Text = UpdEmpdataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            // gender.Text = UpdEmpdataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            statuscomboBox.Text = UpdEmpdataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            picturetextBox.Text = UpdEmpdataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();

            pictureBox1.Image = Image.FromFile(picturetextBox.Text);
        }

        private void termsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (termsCheckBox.Checked)
            {
                searchButton.Enabled = true;
            }
            else
                searchButton.Enabled = false;
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
                // string sql = "UPDATE Users SET Username='"+ nameTextBox.Text + "',Password,Email,NidNumber,DateOfBirth,Picture,Address,PhoneNumber,BloodGroup,Salary,UserType,Gender) VALUES('" + nameTextBox.Text + "','" + passwordTextBox.Text + "','" + emailTextBox.Text + "','" + NIDtextBox.Text + "','" + dateOfBirthDateTimePicker.Text + "','" + picturetextBox.Text + "','" + addressTextBox.Text + "','" + phoneTextBox.Text + "','" + bloodGroupComboBox.Text + "','" + salarytextBox.Text + "', '" + statuscomboBox.Text + "','" + gender + "')";
                string sql = "UPDATE Users SET Username='" + nameTextBox.Text + "',Password='" + passwordTextBox.Text + "',Email='" + emailTextBox.Text + "',NidNumber='" + NIDtextBox.Text + "',DateOfBirth='" + dateOfBirthDateTimePicker.Text + "',Address='" + addressTextBox.Text + "',PhoneNumber='" + phoneTextBox.Text + "',BloodGroup='" + bloodGroupComboBox.Text + "',Salary='" + salarytextBox.Text + "',Gender='" + gender + "',UserType='" + statuscomboBox.Text + "',Picture='" + picturetextBox.Text + "' WHERE UserId=" + Convert.ToInt32(idTextBox.Text);
                SqlCommand command = new SqlCommand(sql, connection);
                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("User updated.");
                    UpdateEmployee um = new UpdateEmployee();
                    this.Hide();
                    um.Show();
                }
                else
                {
                    MessageBox.Show("Error");
                }
                connection.Close();



                File.Copy(picturetextBox.Text, Path.Combine(@"C:\Users\Rushdi\source\repos\Null Super Shop[A]\Null Super Shop[A]\EmpPicture", Path.GetFileName(picturetextBox.Text)), true);




















            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            this.Hide();
            f1.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NullSuperShop"].ConnectionString);
            connection.Open();
            string sql = "SELECT * FROM Users WHERE UserId=" + Convert.ToInt32(idTextBox.Text);
            SqlCommand command = new SqlCommand(sql, connection);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                nameTextBox.Text = reader["Username"].ToString();
                NIDtextBox.Text = reader["NidNumber"].ToString();
                passwordTextBox.Text = reader["Password"].ToString();
                emailTextBox.Text = reader["Email"].ToString();
                dateOfBirthDateTimePicker.Text = reader["DateOfBirth"].ToString();
                addressTextBox.Text = reader["Address"].ToString();
                phoneTextBox.Text = reader["PhoneNumber"].ToString();
                salarytextBox.Text = reader["Salary"].ToString();
                statuscomboBox.Text = reader["UserType"].ToString();
                picturetextBox.Text = reader["Picture"].ToString();
                pictureBox1.Image = Image.FromFile(reader["Picture"].ToString());
                string gender = reader["Gender"].ToString();
                if (gender == "Male")
                {
                    maleRadioButton.Checked = true;
                }
                else
                {
                    femaleRadioButton.Checked = true;
                }
                bloodGroupComboBox.Text = reader["BloodGroup"].ToString();

            }
            else
            {
                MessageBox.Show("User does not exist");
                //nameTextBox.Text = nameTextBox.Text = passwordTextBox.Text = confirmPasswordTextBox.Text = emailTextBox.Text = "";
                dateOfBirthDateTimePicker.Text = "";
                maleRadioButton.Checked = femaleRadioButton.Checked = false;
                bloodGroupComboBox.Text = "";
            }
            connection.Close();
        }
    }
}