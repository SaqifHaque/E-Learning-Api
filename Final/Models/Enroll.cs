using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class Enroll
    {
        [Key]
        public int E_Id { get; set; }
        [Required]
        public int Course_Id { get; set; }
        [Required]
        public int Student_Id { get; set; }
        [Required]
        public string Student_Email { get; set; }
        [Required]
        public string Status { get; set; }
        [ForeignKey("Course_Id")]
        public Course Course { get; set; }
        public List<HyperLink> HyperLinks = new List<HyperLink>();

    }
}