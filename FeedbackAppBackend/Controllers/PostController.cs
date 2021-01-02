using FeedbackAppBackend.Models;
using FeedbackAppBackend.Services;
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
        private PostService _postService;
        public PostController()
        {
            _context = new ApplicationDbContext();
            _postService = new PostService();
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
                IEnumerable<Post> paginatedPosts = _postService.getPaginatedPost(posts, 1, 1);
                return Ok( new { success = true, paginatedPosts } );

            } catch(Exception exception)
            {
                return Ok(new { success = false, error = exception.Message });
            }   
        }

        [HttpGet]
        [Route("api/GetPost/{title}")]
        public IHttpActionResult GetPost(string title)
        {
            try
            {
                Post post = _context.Posts.Include("AppUser").FirstOrDefault(x => x.Title == title);
                if (post == null)
                {
                    return Ok(new { success = false, error = "Post not found" });
                }
                List<Comment> comments = _context.Comments.Include("Reaction")
                    .Where(x => x.PostId == post.Id)
                    .ToList();

                return Ok(new { success = true, post });
            }
            catch (Exception exception)
            {
                return Ok(new { success = false, error = exception.Message });
            }
        }
    }
}
