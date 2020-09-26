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
        [Required]

        public string PostDetails { get; set; }

        public List<HyperLink> HyperLinks = new List<HyperLink>();
        [Required]

        public int UserId { set; get; }
        [Required]

        [ForeignKey("UserId")]
        public User User { set; get; }
        [Required]

        public IEnumerable<Comment> Comments { get; set; }

    }
}