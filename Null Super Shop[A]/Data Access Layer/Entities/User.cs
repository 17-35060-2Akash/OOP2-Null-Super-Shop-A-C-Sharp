using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Null_Super_Shop_A_.Data_Access_Layer.Entities
{
    class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string NidNumber { get; set; }
        public string DateOfBirth { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string BloodGroup { get; set; }
        public string Salary { get; set; }
        public string Gender { get; set; }
        public string UserType { get; set; }
        public string Picture { get; set; }
    }
}
