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
using Null_Super_Shop_A_.Business_Logic_Layer;
using Null_Super_Shop_A_.Data_Access_Layer.Entities;

namespace Null_Super_Shop_A_.Presentation_Layer
{
    public partial class ManageProduct : Form
    {
        public ManageProduct()
        {
            InitializeComponent();
            ProductService productService = new ProductService();
            productListDataGridView.DataSource = productService.GetAllProducts();
            CategoryService categoryService = new CategoryService();
            addProductCategoryComboBox.DataSource = categoryService.GetCategoryNames();
            CategoryService categoryService2 = new CategoryService();
            productByCategoryComboBox.DataSource = categoryService2.GetCategoryNames();
        }

        private void ManageProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();        }

        private void ManageProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        void UpdateListOfProducts()
        {
            ProductService productService = new ProductService();
            productListDataGridView.DataSource = productService.GetAllProducts();
        }

        private void ManageProduct_Load(object sender, EventArgs e)
        {
            ProductService productService = new ProductService();
            productListDataGridView.DataSource = productService.GetAllProducts();
            CategoryService categoryService = new CategoryService();
            addProductCategoryComboBox.DataSource = categoryService.GetCategoryNames();
            CategoryService cs = new CategoryService();
            updateProductCategoryTextBox.DataSource = cs.GetCategoryNames();
            
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            File.Copy(addProductPictureTextBox.Text,Path.Combine(@"C:\Users\Rushdi\source\repos\Null Super Shop[A]\Null Super Shop[A]\Images",Path.GetFileName(addProductPictureTextBox.Text)),true);
            ProductService productService = new ProductService();
            int result = productService.AddNewProduct(addProductNameTextBox.Text,addProductPictureTextBox.Text, Convert.ToDouble(addProductPriceTextBox.Text), Convert.ToInt32(addProductQuantityTextBox.Text),addProductProductionDateTextBox.Text, addProductExpiryDateTextBox.Text, addProductDiscriptionTextBox.Text, addProductCategoryComboBox.Text);
            if (result > 0)
            {
                MessageBox.Show("New product added successfully !!");
                UpdateListOfProducts();
            }
            else
            {
                MessageBox.Show("Error in adding.");
            }
        }

        private void productListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void updateProductCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void updateButton_Click(object sender, EventArgs e)
        {

            //SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString);
            //connection.Open();
            //string sql = "UPDATE Users SET Name='" + nameTextBox.Text + "',Username='" + usernameTextBox.Text + "',Password='" + passwordTextBox.Text + "',Email='" + emailTextBox.Text + "',DateOfBirth='" + dateOfBirthDateTimePicker.Text + "',Gender='" + gender + "',BloodGroup='" + bloodGroupComboBox.Text + "' WHERE Id=" + Convert.ToInt32(idTextBox.Text);
            //SqlCommand command = new SqlCommand(sql, connection);
            //int result = command.ExecuteNonQuery();
            //if (result > 0)
            //{
            //    MessageBox.Show("User updated.");
            //    Dashboard dashboard = new Dashboard();
            //    this.Hide();
            //    dashboard.Show();
            //}
            //else
            //{
            //    MessageBox.Show("Error");
            //}
            //connection.Close();


            File.Copy(updateProductPictureTextBox.Text, Path.Combine(@"C:\Users\Rushdi\source\repos\Null Super Shop[A]\Null Super Shop[A]\Images", Path.GetFileName(updateProductPictureTextBox.Text)), true);
            ProductService productService = new ProductService();
            int result = productService.UpdateExistingProduct(Convert.ToInt32(updateProductIdTextBox.Text), updateProductNameTextBox.Text, updateProductPictureTextBox.Text, Convert.ToDouble(updateProductPriceTextBox.Text), Convert.ToInt32(updateProductQuantityTextBox.Text), updateProductProductionDateTextBox.Text, updateProductExpiryDateTextBox.Text, updateProductDiscription.Text, updateProductCategoryTextBox.Text);
            if (result > 0)
            {
                MessageBox.Show("Products updated successfully !!");
                UpdateListOfProducts();
            }
            else
            {
                MessageBox.Show("Error in updating.");
            }
        }

        private void productsByCategoryGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void productByCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProductService productService = new ProductService();
            productsByCategoryGridView.DataSource = productService.GetAllProductsByCategory(productByCategoryComboBox.Text);
            //productsByCategoryGridView.DataSource = productService.GetAllProductsByCategory(productByCategoryComboBox.Text);
            
        }

        private void productListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            updateProductIdTextBox.Text = productListDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            updateProductNameTextBox.Text = productListDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
            updateProductPictureTextBox.Text = productListDataGridView.Rows[e.RowIndex].Cells[2].Value.ToString();
            updateProductPriceTextBox.Text = productListDataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
            updateProductProductionDateTextBox.Text = productListDataGridView.Rows[e.RowIndex].Cells[4].Value.ToString();
            updateProductExpiryDateTextBox.Text = productListDataGridView.Rows[e.RowIndex].Cells[5].Value.ToString();
            updateProductDiscription.Text = productListDataGridView.Rows[e.RowIndex].Cells[6].Value.ToString();
            //updateProductCategoryTextBox.Text = productListDataGridView.Rows[e.RowIndex].Cells[7].Value.ToString();
            deleteProductIdTextBox.Text = productListDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            updatepictureBox2.Image = Image.FromFile(updateProductPictureTextBox.Text);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {

            ProductService categoryService = new ProductService();
            int result = categoryService.DeleteProduct(Convert.ToInt32(deleteProductIdTextBox.Text));
            if (result > 0)
            {
                MessageBox.Show("Category deleted successfully !!");
                UpdateListOfProducts();
            }
            else
            {
                MessageBox.Show("Error in deleting.");
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *jpeg; *.gif; *.bmp;)|*.jpg; *jpeg; *.gif; *.bmp;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                addProductPictureTextBox.Text = open.FileName;
                addproductpictureBox.Image = new Bitmap(open.FileName);

            }
        }

        private void addProductPictureTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *jpeg; *.gif; *.bmp;)|*.jpg; *jpeg; *.gif; *.bmp;";
            if (open.ShowDialog() == DialogResult.OK)
            {
                updateProductPictureTextBox.Text = open.FileName;
                //PictureBOx.Image = new Bitmap(open.FileName);

            }
        }

        private void groupBox6_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {

                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NullSuperShop"].ConnectionString);
                connection.Open();
                string sql = "SELECT * FROM Products order by ProductPrice ASC";
                SqlCommand command = new SqlCommand(sql, connection);
                List<Product> users = new List<Product>();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product user = new Product();
                    user.ProductId = (int)reader["ProductId"];
                    user.ProductName = reader["ProductName"].ToString();
                    user.ProductPicture = reader["ProductPicture"].ToString();
                    user.ProductPrice = (double)reader["ProductPrice"];
                    user.ProductProductionDate = reader["ProductProductionDate"].ToString();
                    user.ProductExpiryDate = reader["ProductExpiryDate"].ToString();
                    user.ProductDiscription = reader["ProductDiscription"].ToString();
                    user.CategoryId = (int)reader["CategoryId"];
                    users.Add(user);
                }
                connection.Close();
                productsByCategoryGridView.DataSource = users;

            }
            else
            {
                SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["NullSuperShop"].ConnectionString);
                connection.Open();
                string sql = "SELECT * FROM Products order by ProductPrice DESC";
                SqlCommand command = new SqlCommand(sql, connection);
                List<Product> users = new List<Product>();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Product user = new Product();
                    user.ProductId = (int)reader["ProductId"];
                    user.ProductName = reader["ProductName"].ToString();
                    user.ProductPicture = reader["ProductPicture"].ToString();
                    user.ProductPrice = (double)reader["ProductPrice"];
                    user.ProductProductionDate = reader["ProductProductionDate"].ToString();
                    user.ProductExpiryDate = reader["ProductExpiryDate"].ToString();
                    user.ProductDiscription = reader["ProductDiscription"].ToString();
                    user.CategoryId = (int)reader["CategoryId"];
                    users.Add(user);
                }
                connection.Close();
                productsByCategoryGridView.DataSource = users;
            }



        }

        private void addProductCategoryComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
    }
