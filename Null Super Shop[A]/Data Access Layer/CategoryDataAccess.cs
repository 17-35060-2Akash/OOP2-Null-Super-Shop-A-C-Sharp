using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Null_Super_Shop_A_.Data_Access_Layer.Entities;

namespace Null_Super_Shop_A_.Data_Access_Layer
{
    class CategoryDataAccess:DataAccess
    {
        public List<Category> GetCategories()
        {
            string sql = "SELECT * FROM Categories";
            SqlDataReader reader = this.GetData(sql);
            List<Category> categories = new List<Category>();
            while (reader.Read())
            {
                Category category = new Category();
                category.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                category.CategoryName = reader["CategoryName"].ToString();
                categories.Add(category);
            }
            return categories;
        }
        public Category GetCategory(int id)
        {
            string sql = "SELECT * FROM Categories WHERE CategoryId=" + id;
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                Category category = new Category();
                category.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                category.CategoryName = reader["CategoryName"].ToString();
                return category;
            }
            return null;
        }

        public int AddCategory(Category category)
        {
            string sql = "INSERT INTO Categories(CategoryName) VALUES('" + category.CategoryName + "')";
            return this.ExecuteQuery(sql);
        }

        public int UpdateCategory(Category category)
        {
            string sql = "UPDATE Categories SET CategoryName='" + category.CategoryName + "' WHERE CategoryID=" + category.CategoryId;
            return this.ExecuteQuery(sql);
        }
        public int DeleteCategory(int id)
        {
            string sql = "DELETE FROM Categories WHERE CategoryId=" + id;
            return this.ExecuteQuery(sql);
        }

        public int GetCategoryId(string name)
        {
            string sql = "SELECT CategoryId FROM Categories WHERE CategoryName='" + name + "'";
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                return Convert.ToInt32(reader["CategoryId"]);
            }
            return -1;
        }
        public List<string> GetCategoryNames()
        {
            string sql = "SELECT CategoryName FROM Categories";
            SqlDataReader reader = this.GetData(sql);
            List<string> categoryNames = new List<string>();
            while (reader.Read())
            {
                categoryNames.Add(reader["CategoryName"].ToString());
            }
            return categoryNames;
        }

    }
}
