using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace OnneshProject.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        [DisplayName("Sub Category")]
        public int Parent_Id { get; set; }
        [DisplayName("Category")]
        public int CategoryType { get; set; }
        public int IsActive { get; set; }
    }
}