using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class Status
    {
        [Key]
        public int S_Id { get; set; }
        public string Check { get; set; }
        public int User_Id { get; set; }
        [ForeignKey("User_Id")]
        public User User { get; set; }
        public int N_Id { get; set; }
        [ForeignKey("N_Id")]
        public Notification Notification { set; get; }
        public List<HyperLink> HyperLinks = new List<HyperLink>();
    }
}