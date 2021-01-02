using FeedbackAppBackend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace FeedbackAppBackend.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PostController : ApiController
    {
        private readonly ApplicationDbContext _context;
        public PostController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpGet]
        [Route("api/GetPosts")]
        public IHttpActionResult GetPosts()
        {
            try
            {
                List<Post> posts = _context.Posts.Include("AppUser").ToList();
                posts.ForEach(post =>
                {
                    List<Comment> comments = _context.Comments.Include("Reaction")
                    .Where(x => x.PostId == post.Id)
                    .ToList();
                    post.Comments = comments;
                   
                });
                return Ok( new { success = true, posts } );

            } catch(Exception exception)
            {
                return Ok(new { success = false, error = exception.Message });
            }           
            
           
        }
    }
}
