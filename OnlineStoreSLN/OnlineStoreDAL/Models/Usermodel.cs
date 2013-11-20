using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace OnlineStoreDAL.Models
{
    public class Usermodel
    {
        public string first_name { get; set; }
        public string last_name{ get; set; }
        public decimal Address { get; set; }
        public string Email{ get; set; }
        public string Password { get; set; }
        public DateTime register_time{ get; set; }        
        public int role_type{ get; set; }  
    }
}