using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeedbackAppBackend.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CreatedDate { get; set; }
        public AppUser AppUser { get; set; }
        public int? AppUserId { get; set; }
        public List<Comment> Comments { get; set; }
    }
}