using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Null_Super_Shop_A_.Data_Access_Layer.Entities;

namespace Null_Super_Shop_A_.Data_Access_Layer
{
    class ProductDataAccess:DataAccess
    {

        public List<Product> GetProducts()
        {
            string sql = "SELECT * FROM Products";
            SqlDataReader reader = this.GetData(sql);
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product product = new Product();
                product.ProductId = Convert.ToInt32(reader["ProductId"]);
                product.ProductName = reader["ProductName"].ToString();
                product.ProductPicture = reader["ProductPicture"].ToString();
                product.ProductPrice = Convert.ToDouble(reader["ProductPrice"]);
                product.ProductQuantity = Convert.ToInt32(reader["ProductQuantity"]);
                product.ProductProductionDate = reader["ProductProductionDate"].ToString();
                product.ProductExpiryDate = reader["ProductExpiryDate"].ToString();
                product.ProductDiscription = reader["ProductDiscription"].ToString();
                product.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                products.Add(product);
            }
            return products;
        }
        public Product GetProduct(int id)
        {
            string sql = "SELECT * FROM Products WHERE ProductId=" + id;
            SqlDataReader reader = this.GetData(sql);
            if (reader.Read())
            {
                Product product = new Product();
                product.ProductId = Convert.ToInt32(reader["ProductId"]);
                product.ProductName = reader["ProductName"].ToString();
                product.ProductPicture = reader["ProductPicture"].ToString();
                product.ProductPrice = Convert.ToDouble(reader["ProductPrice"]);
                product.ProductQuantity = Convert.ToInt32(reader["ProductQuantity"]);
                product.ProductProductionDate = reader["ProductProductionDate"].ToString();
                product.ProductExpiryDate = reader["ProductExpiryDate"].ToString();
                product.ProductDiscription = reader["ProductDiscription"].ToString();
                product.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                return product;
            }
            return null;
        }

        public int AddProduct(Product product)
        {
            string sql = "INSERT INTO Products(ProductName,ProductPicture,ProductPrice,ProductQuantity,ProductProductionDate,ProductExpiryDate,ProductDiscription,CategoryId) VALUES('" + product.ProductName + "','" + product.ProductPicture + "'," + product.ProductPrice + ",'"+product.ProductQuantity+"','" + product.ProductProductionDate + "','" + product.ProductExpiryDate + "','" + product.ProductDiscription + "'," + product.CategoryId + ")";
            return this.ExecuteQuery(sql);
        }

        public int UpdateProduct(Product product)
        {
            string sql = "UPDATE Products SET ProductName='" + product.ProductName+"',ProductPicture='" + product.ProductPicture+ "',ProductPrice=" + product.ProductPrice+ "',ProductQuantity=" + product.ProductQuantity + "', ProductProductionDate= '" + product.ProductProductionDate+ "',ProductExpiryDate='"+ product.ProductExpiryDate+ "',ProductDiscription='"+ product.ProductDiscription+ "',CategoryId=" + product.CategoryId + " WHERE ProductId=" + product.ProductId;
            return this.ExecuteQuery(sql);
        }
        public int DeleteProduct(int id)
        {
            string sql = "DELETE FROM Products WHERE ProductId=" + id;
            return this.ExecuteQuery(sql);
        }
        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            string sql = "SELECT * FROM Products WHERE CategoryId=" + categoryId;
            SqlDataReader reader = this.GetData(sql);
            List<Product> products = new List<Product>();
            while (reader.Read())
            {
                Product product = new Product();
                product.ProductId = Convert.ToInt32(reader["ProductId"]);
                product.ProductName = reader["ProductName"].ToString();
                product.ProductPicture = reader["ProductPicture"].ToString();
                product.ProductPrice = Convert.ToDouble(reader["ProductPrice"]);
                product.ProductQuantity = Convert.ToInt32(reader["ProductQuantity"]);
                product.ProductProductionDate = reader["ProductProductionDate"].ToString();
                product.ProductExpiryDate = reader["ProductExpiryDate"].ToString();
                product.ProductDiscription = reader["ProductDiscription"].ToString();
                product.CategoryId = Convert.ToInt32(reader["CategoryId"]);
                products.Add(product);
            }
            return products;
        }

    }
}
