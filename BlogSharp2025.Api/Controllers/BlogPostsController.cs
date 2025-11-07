using BlogSharp2025.DataAccessLibrary.Interfaces;
using BlogSharp2025.DataAccessLibrary.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlogSharp2025.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BlogPostsController : ControllerBase
{
    IBlogPostDao _blogPostDao;
    public BlogPostsController(IBlogPostDao blogPostDao)
    {
        _blogPostDao = blogPostDao;
    }

    [HttpGet]
    public ActionResult<IEnumerable<BlogPost>> Get()
    {
        try
        {
            return Ok(_blogPostDao.GetAll());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred trying to retrieve all blog posts.");
        }
    }

    [HttpGet("{id}")]
    public ActionResult<BlogPost> Get(int id)
    {
        try
        {
            var post = _blogPostDao.GetOne(id);
            if (post == null)
            {
                return NoContent();
            }

            return Ok(post);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred trying to retrieve the blog post with id {id}.");
        }
    }

    // Route: [website]/Authors/{id}/BlogPosts
    [HttpGet("/Authors/{id}/BlogPosts")]
    public ActionResult<IEnumerable<BlogPost>> GetByAuthor(int id)
    {
        try
        {
            var posts = _blogPostDao.GetByAuthor(id);
            return Ok(posts);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred trying to retrieve blog posts for author with id {id}.");
        }
    }

    [HttpPost]
    public ActionResult<int> Create(BlogPost blogPost)
    {
        try
        {
            return Ok(_blogPostDao.Create(blogPost));
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred trying to create the blog post.");
        }
    }

    [HttpPut("{id}")]
    public ActionResult<bool> Update(int id, BlogPost blogPost)
    {
        try
        {
            if (blogPost == null || id != blogPost.Id)
            {
                return BadRequest("BlogPost payload is null or id mismatch.");
            }

            var updated = _blogPostDao.Update(blogPost);
            if (!updated)
            {
                return NoContent() ;
            }

            return Ok(true);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred trying to update the blog post with id {id}.");
        }
    }

    [HttpDelete("{id}")]
    public ActionResult<bool> Delete(int id)
    {
        try
        {
            var deleted = _blogPostDao.Delete(id);
            if (!deleted)
            {
                return NoContent();
            }

            return Ok(true);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred trying to delete the blog post with id {id}.");
        }
    }
}