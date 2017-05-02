using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnneshProject.Models
{
    public class Users
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string Password { get; set; }
        public string InstituteName { get; set; }
        public string Address { get; set; }
        public int DistrictId { get; set; }
        public int IsActive { get; set; }
        public int IsPermitted { get; set; }
        public int ConfirmBy { get; set; }
    }
}