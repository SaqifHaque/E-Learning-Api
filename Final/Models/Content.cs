using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class Content
    {
        [Key]
        public int Content_Id { get; set; }
        public int Course_Id { get; set; }
        public string File_Name { get; set; }
        public string File_Path { get; set; }
        [ForeignKey("Course_Id")]
        public Course Course { get; set; }
        public List<HyperLink> HyperLinks = new List<HyperLink>();
    }
}