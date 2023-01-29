using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Null_Super_Shop_A_.Data_Access_Layer;
using Null_Super_Shop_A_.Data_Access_Layer.Entities;

namespace Null_Super_Shop_A_.Business_Logic_Layer
{
    class ProductService
    {

        ProductDataAccess productDataAccess;
        public ProductService()
        {
            this.productDataAccess = new ProductDataAccess();
        }

        public List<Product> GetAllProducts()
        {
            return this.productDataAccess.GetProducts();
        }
        public Product GetProduct(int id)
        {
            return this.productDataAccess.GetProduct(id);
        }

        public int AddNewProduct(string productName, string productPicture, double productPrice,int productQuantity, string productProductionDate,string productExpiryDate,string productDiscription, string categoryName)
        {
            CategoryDataAccess categoryDataAccess = new CategoryDataAccess();
            int categoryId = categoryDataAccess.GetCategoryId(categoryName);

            Product product = new Product()
            {

                ProductName = productName,
                ProductPicture = productPicture,
                ProductPrice = productPrice,
                ProductQuantity = productQuantity,
                ProductProductionDate = productProductionDate,
                ProductExpiryDate = productExpiryDate,
                ProductDiscription = productDiscription,
                CategoryId = categoryId
            };
            this.productDataAccess = new ProductDataAccess();
            return this.productDataAccess.AddProduct(product);
        }
        public int UpdateExistingProduct(int productId, string productName, string productPicture ,double productPrice,int productQuantity, string productProductionDate, string productExpiryDate, string productDiscription, string categoryName)
        {

            CategoryDataAccess categoryDataAccess = new CategoryDataAccess();
            int categoryId = categoryDataAccess.GetCategoryId(categoryName);
            Product product = new Product()
            {
                ProductId = productId,
                ProductName = productName,
                ProductPicture = productPicture,
                ProductPrice = productPrice,
                ProductQuantity = productQuantity,
                ProductProductionDate = productProductionDate,
                ProductExpiryDate = productExpiryDate,
                ProductDiscription = productDiscription,
                CategoryId = categoryId
            };
            this.productDataAccess = new ProductDataAccess();
            return this.productDataAccess.UpdateProduct(product);
        }
        public int DeleteProduct(int id)
        {
            return this.productDataAccess.DeleteProduct(id);
        }
        public List<Product> GetAllProductsByCategory(string categoryName)
        {
            CategoryDataAccess categoryDataAccess = new CategoryDataAccess();
            int categoryId = categoryDataAccess.GetCategoryId(categoryName);
            this.productDataAccess = new ProductDataAccess();
            return this.productDataAccess.GetProductsByCategoryId(categoryId);
        }






    }
}
