using BlogAPI.Models;
using BlogAPI.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        [HttpPost]
        public ActionResult AddNewPost(AddPostDto addPostDto)
        {
            try
            {
                using (BlogDbContext context = new BlogDbContext())
                {
                    var post = new Post() {
                        Category = addPostDto.Category,
                        Title = addPostDto.Title,
                        Description = addPostDto.Description,
                        BloggerId = addPostDto.BloggerID
                    
                    };

                    if (post != null)
                    {
                        context.post.Add(post);
                        context.SaveChanges();
                        return StatusCode(201, new {message = "Sikeres felvétel", result = post});
                    }

                    return NotFound(new { message = "Sikertelen felvétel", result = post });
                }
            }
            catch (Exception ex)
            {

                return StatusCode(400, new {message = ex.Message, result = ""});
            }
        }
    }
}
