using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class Course
    {
        [Key]
        public int C_Id { get; set; }
        [Required]
        public int Instructor_Id { get; set; }
        [ForeignKey("Instructor_Id")]
        public User User { set; get; }
        [Required]
        public int Category_Id { get; set; }
        [ForeignKey("Category_Id")]
        public Category Category { get; set; }
        [Required]
        public string C_Name { get; set; }
        [Required]
        public string C_Description { get; set; }
        [Required]
        public string Status { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public string C_Image { get; set; }

        public IEnumerable<Cart> Carts { get; set; }
        public IEnumerable<Enroll> Enrolls { get; set; }
        public IEnumerable<Content> Contents { get; set; }

        public IEnumerable<Video> Videos { get; set; }
        public IEnumerable<Notice> Notices { get; set; }
        public List<HyperLink> HyperLinks = new List<HyperLink>();

    }
}