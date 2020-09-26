using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public string Password { get; set; }

        public IEnumerable<Course> Courses { get; set; }
        public IEnumerable<Post> Posts { get; set; }
        //public IEnumerable<Enroll> Enrolls { get; set; }
        public IEnumerable<Invoice> Invoices { get; set; }
        public List<HyperLink> HyperLinks = new List<HyperLink>();


    }
}