using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class Cart
    {
        public int Cart_Id { get; set; }
        public int Student_Id { get; set; }
        [ForeignKey("Student_Id")]
        public User User { get; set; }
        public int Item_Id { get; set; }
        [ForeignKey("Item_Id")]
        public Course Course { get; set; }
        
    }
}