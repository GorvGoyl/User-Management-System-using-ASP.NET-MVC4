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
       // [Required(ErrorMessage = "UserName Required.", AllowEmptyStrings = false)]
        public string UserName { get; set; }
        public string FullName { get; set; }
       // [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Enter 10 digit phone number ")]
        public string Phone { get; set; }
       // [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email Format is wrong")]
        //[Display(Name = "Email Id")]
        public string Email { get; set; }
        public string City { get; set; }
      //  [Required(ErrorMessage = "Please enter the date of birth")]
      //  [RegularExpression(@"[0-9]{1,2}\/[0-9]{1,2}\/[0-9]{4}", ErrorMessage = "Date format should be 'mm/dd/yyyy' ")]
        public string Dob { get; set; }
       // [Required(ErrorMessage = "Password Required.", AllowEmptyStrings = false)]
        public string Password { get; set; }

    }
}