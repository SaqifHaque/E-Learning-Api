using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class Notification
    {
        [Key]
        public int N_Id { get; set; }
        public string No_Type { get; set; }
        public string Notify { get; set; }
        public System.DateTime AddedOn { get; set; }
        public string Type { get; set; }
        public IEnumerable<Status> Statuses { get; set; }
        public List<HyperLink> HyperLinks = new List<HyperLink>();
    }
}