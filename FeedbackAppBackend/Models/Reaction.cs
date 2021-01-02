using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeedbackAppBackend.Models
{
    public class Reaction
    {
        public int Id { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }    
    }
}