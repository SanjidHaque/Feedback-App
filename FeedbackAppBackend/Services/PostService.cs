using FeedbackAppBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FeedbackAppBackend.Services
{
    public class PostService
    {
        public IEnumerable<Post> getPaginatedPost(List<Post> posts, int pageNumber, int pageSize)
        {
            IEnumerable<Post> paginatedPosts = posts.Skip((pageNumber - 1) * pageSize).Take(pageSize);
            return paginatedPosts;
        }
    }
}