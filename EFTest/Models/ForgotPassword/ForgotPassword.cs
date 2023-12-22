using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFTest.Models.ForgotPassword
{
    public class ForgotPassword
    {
        [Required]
        [Display(Name = "Mobile Number")]
        [StringLength(10, ErrorMessage ="Mobile number must be 10 digit")]
        public string MobileNumber { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class OTPCode
    {
        public string Code1 { get; set; }
        public string Code2 { get; set; }
        public string Code3 { get; set; }
        public string Code4 { get; set; }
    }
    public class ResetPassword
    {
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}