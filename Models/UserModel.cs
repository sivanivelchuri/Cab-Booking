using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegisterLoginMVC.Models
{
    public class UserModel
    {
        public int UserId { get; set; }

        [Required(AllowEmptyStrings = false,ErrorMessage ="UserName is Required.")]
        [Display(Name ="User Name: ")]
        public string UserName{ get;set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is Required.")]
        [Display(Name = "EmailId: ")]
        public string EmailId { get;set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required.")]
        [Display(Name = "Password: ")]
        [DataType(DataType.Password)]
        public string Password { get;set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm Password is Required.")]
        [Display(Name ="ConfirmPassword: ")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Password and Confirm Password should be same.")]
        public string ConfirmPassword { get; set; }
        public string MobileNum { get; set; }
        
    }
}