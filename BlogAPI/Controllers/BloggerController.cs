using BlogAPI.Models;
using BlogAPI.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloggerController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddNewBlogger(AddBloggerDto addBloggerDto)
        {
            try
            {
                using (BlogDbContext blogDbContext = new BlogDbContext())
                {
                    var blogger = new Blogger()
                    {
                        Name = addBloggerDto.Name,
                        Password = addBloggerDto.Password,
                        Email = addBloggerDto.Email
                    };

                    if (blogger != null)
                    {
                        blogDbContext.blogger.Add(blogger);
                        blogDbContext.SaveChanges();
                        return StatusCode(201, new { message = "Sikeres felvétel", result = blogger });
                    }
                    return NotFound(new { message = "Sikertelen felvétel", result = blogger });
                }
            }
            catch (Exception ex)
            {

                return NotFound(new { message = ex.Message, result = "" });
            }

        }

        [HttpGet]
        public ActionResult GetBloggers() 
        {
            try
            {

                using (BlogDbContext context = new BlogDbContext())
                {
                    var bloggerek = context.blogger.ToArray();

                    if (bloggerek != null)
                    {
                        return Ok(new { result = bloggerek });
                    }

                    return NotFound(new { message = "nincsenek bloggerek" });
                }
            }
            catch (Exception ex)
            {
                return NotFound(new {message = ex.Message, result = ""});
            }
        }

        [HttpGet("withPost")]
        public ActionResult GetBloggersWithPosts()
        {
            try
            {

                using (BlogDbContext context = new BlogDbContext())
                {
                    var bloggersWithPosts = context.blogger.Include(blogger => blogger.Posts).ToArray();
                    return Ok(new { result = bloggersWithPosts });
                }
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message, result = "" });
            }
        }

        [HttpGet("GetByIdwithPost")]
        public ActionResult GetBloggersWithPosts(int id)
        {
            try
            {

                using (BlogDbContext context = new BlogDbContext())
                {
                    var bloggersWithPosts = context.blogger.Include(x => x.Posts).FirstOrDefault(x => x.Id == id);

                    var blogger = new { Blogger = bloggersWithPosts.Name, Category = bloggersWithPosts.Posts.Select(p => new { p.Category, p.Description }) };
                    return Ok(new { result = blogger });
                }
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message, result = "" });
            }
        }

        [HttpGet("GetBloggerPostCount")]
        public ActionResult GetBloggerPostsCount()
        {
            try
            {
                using (BlogDbContext context = new BlogDbContext())
                {
                    var bloggersWithPosts = context.blogger
                        .Include(x => x.Posts)
                        .ToArray()
                        .Select(b => new { b.Name, b.Posts.Count });
                    
                    return Ok(new { result = bloggersWithPosts });
                }
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message, result = "" });
            }
        }
    }
}
