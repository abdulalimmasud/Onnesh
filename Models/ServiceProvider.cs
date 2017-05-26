using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnneshProject.Models
{
    public class ServiceProvider
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        [Required]
        [DisplayName("District")]
        public string DistrictId { get; set; }
        public int IsActive { get; set; }
        public int IsPermitted { get; set; }
        public int ConfirmBy { get; set; }
    }
}