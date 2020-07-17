using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TarkariWala.Models
{
    public class AdminUser
    {
        [Key]
        public int userID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

    }
}