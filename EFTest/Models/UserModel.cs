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
        public string Username { get; set; }
        [Required]
        [MaxLength(16)]
        [MinLength(8)]
        public string Password { get; set; }
        public string Email { get; set; }
    }
}