using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Final.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        public string PostDetails { get; set; }

        public List<HyperLink> HyperLinks = new List<HyperLink>();

        public int UserId { set; get; }

        [ForeignKey("UserId")]
        public User User { set; get; }

        public IEnumerable<Comment> Comments { get; set; }

    }
}