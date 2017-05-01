using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnneshProject.Models
{
    public class ServiceProvider
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string DistrictId { get; set; }
        public int IsActive { get; set; }
        public int IsPermitted { get; set; }
        public int ConfirmBy { get; set; }
    }
}