using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace RegisterLoginMVC.Models
{
    public class AdminRegister
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "FirstName is Required.")]
        [Display(Name = "Name: ")]
        public string Name { get; set; }

        

        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is Required.")]
        [Display(Name = "Email: ")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required.")]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string SuccessMessage { get; set; }
    }
}