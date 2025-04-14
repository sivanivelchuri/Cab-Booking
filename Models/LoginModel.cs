using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RegisterLoginMVC.Models
{
    public class LoginModel
    {
        public int UserId { get; set; }
        [Required(ErrorMessage ="Email is Required.")]
        public string EmailId {  get; set; }
        [Required(ErrorMessage = "Password is Required.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}