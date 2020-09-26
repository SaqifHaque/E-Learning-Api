using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class Financial
    {
        [Key]
        public int F_Id { get; set; }
        [Required]
        public string Courses { get; set; }
        [Required]
        public int Paid_By { get; set; }
        [Required]
        public int Amount { get; set; }
        [Required]
        public double Profit { get; set; }
        public List<HyperLink> HyperLinks = new List<HyperLink>();

    }
}