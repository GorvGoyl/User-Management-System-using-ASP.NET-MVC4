using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC4_Html_Table.Models
{
    public class User
    {
      
        public string UserId { get; set; }     
        public string UserName { get; set; }
        public string FullName { get; set; }     
        public string Phone { get; set; }    
        public string Email { get; set; }
        public string City { get; set; }      
        public string Dob { get; set; }
        public string Password { get; set; }

    }
}