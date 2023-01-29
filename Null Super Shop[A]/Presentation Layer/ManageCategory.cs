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

namespace Null_Super_Shop_A_.Presentation_Layer
{
    public partial class ManageCategory : Form
    {
        public ManageCategory()
        {
            InitializeComponent();
        }

        private void ManageCategory_Load(object sender, EventArgs e)
        {
            CategoryService categoryService = new CategoryService();
            categoryListDataGridView.DataSource = categoryService.GetAllCategories();
        }



        private void ManageCategory_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //private void ManageCategory_Load(object sender, EventArgs e)
        //{
        //    CategoryService categoryService = new CategoryService();
        //    categoryListDataGridView.DataSource = categoryService.GetAllCategories();
        //}

        void UpdateListofCategories()
        {
            CategoryService categoryService = new CategoryService();
            categoryListDataGridView.DataSource = categoryService.GetAllCategories();
            addCategoryNameTextBox.Text = updateCategoryNameTextBox.Text = updateCategoryIdTextBox.Text = deleteCategoryIdTextBox.Text = string.Empty;
        }

        void UpdateGridView(object sender, EventArgs e)
        {
            CategoryService categoryService = new CategoryService();
            categoryListDataGridView.DataSource = categoryService.GetAllCategories();
            addCategoryNameTextBox.Text = updateCategoryNameTextBox.Text = updateCategoryIdTextBox.Text = deleteCategoryIdTextBox.Text = string.Empty;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            CategoryService categoryService = new CategoryService();
            int result = categoryService.AddNewCategory(addCategoryNameTextBox.Text);
            if (result > 0)
            {
                MessageBox.Show("New category added successfully !!");
                UpdateListofCategories();
            }
            else
            {
                MessageBox.Show("Error in adding.");
            }
        }

        private void categoryListDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            updateCategoryIdTextBox.Text = categoryListDataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
            updateCategoryNameTextBox.Text = categoryListDataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            CategoryService categoryService = new CategoryService();
            int result = categoryService.UpdateExistingCategory(Convert.ToInt32(updateCategoryIdTextBox.Text), updateCategoryNameTextBox.Text);
            if (result > 0)
            {
                MessageBox.Show("Category updated successfully !!");
                UpdateListofCategories();
            }
            else
            {
                MessageBox.Show("Error in updating.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            CategoryService categoryService = new CategoryService();
            int result = categoryService.DeleteCategory(Convert.ToInt32(deleteCategoryIdTextBox.Text));
            if (result > 0)
            {
                MessageBox.Show("Category deleted successfully !!");
                UpdateListofCategories();
            }
            else
            {
                MessageBox.Show("Error in deleting.");
            }
        }

        private void addCategoryNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void categoryListDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
