using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }
        [Required]
        public string Category_Name { get; set; }
        public IEnumerable<Course> Courses { get; set; }
        public List<HyperLink> HyperLinks = new List<HyperLink>();

    }
}