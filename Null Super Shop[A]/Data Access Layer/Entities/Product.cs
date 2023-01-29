using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Null_Super_Shop_A_.Data_Access_Layer.Entities
{
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductPicture { get; set; }
        public double ProductPrice { get; set; }

        public int ProductQuantity { get; set; }
        public string ProductProductionDate { get; set; }
        public string ProductExpiryDate { get; set; }
        public string ProductDiscription { get; set; }
        public int CategoryId { get; set; }
    }
}
