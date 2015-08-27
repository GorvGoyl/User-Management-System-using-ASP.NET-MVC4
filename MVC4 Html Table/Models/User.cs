using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MVC4_Html_Table.Models
{
    public class User
    {

        public string GUID { get; set; }
        [Required(ErrorMessage = "Name Required.", AllowEmptyStrings = false)]
        public string Name { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        //[Range(typeof(DateTime), "01/01/1900", "06/06/2016", ErrorMessage = "Date is Invalid")] 

        [Required(ErrorMessage = "Please enter the date of birth")]
        [RegularExpression(@"[0-9]{1,2}\/[0-9]{1,2}\/[0-9]{4}", ErrorMessage = "Date format should be 'mm/dd/yyyy' ")]
        public string DOB { get; set; }
        [RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Email Format is wrong")]
        [Display(Name = "Email Id")]
        public string EMail { get; set; }
    }
}