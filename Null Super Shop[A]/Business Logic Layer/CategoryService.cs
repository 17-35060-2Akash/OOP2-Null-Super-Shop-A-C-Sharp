using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Null_Super_Shop_A_.Data_Access_Layer;
using Null_Super_Shop_A_.Data_Access_Layer.Entities;

namespace Null_Super_Shop_A_.Business_Logic_Layer
{
    class CategoryService
    {
        CategoryDataAccess categoryDataAccess;
        public CategoryService()
        {
            this.categoryDataAccess = new CategoryDataAccess();
        }

        public List<Category> GetAllCategories()
        {

            return this.categoryDataAccess.GetCategories();
        }
        public Category GetCategory(int id)
        {
            return this.categoryDataAccess.GetCategory(id);
        }

        public int AddNewCategory(string categoryName)
        {
            Category category = new Category() { CategoryName = categoryName };
            return this.categoryDataAccess.AddCategory(category);
        }
        public int UpdateExistingCategory(int categoryId, string categoryName)
        {
            Category category = new Category() { CategoryId = categoryId, CategoryName = categoryName };
            return this.categoryDataAccess.UpdateCategory(category);
        }
        public int DeleteCategory(int id)
        {
            return this.categoryDataAccess.DeleteCategory(id);
        }
        public List<string> GetCategoryNames()
        {
            return this.categoryDataAccess.GetCategoryNames();
        }
    }
}
