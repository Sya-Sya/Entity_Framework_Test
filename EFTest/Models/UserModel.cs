using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EFTest.Models
{
    public class UserModel : CommonModel
    {
        [Key]
        public int UID { get; set; }
        [MaxLength(36)]
        [Required]
        [RegularExpression(@"^[^|^<^>^#^\\]*$", ErrorMessage = "Invalid input")]
        public string Username { get; set; }
        [Required]
        [MaxLength(16)]
        [MinLength(8)]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Mobile Number")]
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Invalid Mobile Number")]
        public string MobileNumber { get; set; }
    }
}