using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnneshProject.ViewModel
{
    public class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public string AccountType { get; set; }
        public string[] Roles { get; set; }
    }
}