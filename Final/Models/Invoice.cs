using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class Invoice
    {
        [Key]
        public int Invoice_Id { get; set; }
        [Required]
        public int Student_Id { get; set; }
        [Required]
        public string Items { get; set; }
        [Required]
        public double Price { get; set; }
        [ForeignKey("Student_Id")]
        public User User { get; set; }
        public List<HyperLink> HyperLinks = new List<HyperLink>();
    }

}