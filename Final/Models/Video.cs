using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class Video
    {
        [Key]
        public int V_Id { get; set; }
        public int Course_Id { get; set; }
        public string Video_Name { get; set; }
        
        public string Video_Path { get; set; }
        [ForeignKey("Course_Id")]
        public virtual Course Course { get; set; }
        public List<HyperLink> HyperLinks = new List<HyperLink>();
    }
}