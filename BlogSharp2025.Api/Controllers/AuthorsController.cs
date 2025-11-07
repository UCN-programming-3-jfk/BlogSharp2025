using BlogSharp2025.DataAccessLibrary.Interfaces;
using BlogSharp2025.DataAccessLibrary.Model;
using Microsoft.AspNetCore.Mvc;
namespace BlogSharp2025.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthorsController : ControllerBase
{
    IAuthorDao _authorDao;
    public AuthorsController(IAuthorDao authorDao)
    {
        _authorDao = authorDao;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Author>> Get()
    {
        try
        {
            return Ok(_authorDao.GetAll());
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred trying to retrieve all authors.");
        }
    }

    [HttpGet("{id}")]
    public ActionResult<Author> Get(int id)
    {
        try
        {
            var author = _authorDao.GetOne(id);
            if (author == null)
            {
                return NoContent();
            }

            return Ok(author);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred trying to retrieve the author with id {id}.");
        }
    }

    [HttpPost]
    public ActionResult<int> Create(Author author)
    {
        try
        {
            return Ok(_authorDao.Create(author));
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred trying to create the author.");
        }
    }

    [HttpPut("{id}")]
    public ActionResult<bool> Update(int id, Author author)
    {
        try
        {
            if (author == null || id != author.Id)
            {
                return BadRequest("Author payload is null or id mismatch.");
            }

            
            var updated = _authorDao.Update(author);
            if (!updated)
            {
                return NoContent();
            }

            return Ok(true);
        }
        catch (Exception ex)
        {
            //log the error

            return StatusCode(500, $"An error occurred trying to update the author with id {id}.");
        }
    }

    [HttpDelete("{id}")]
    public ActionResult<bool> Delete(int id)
    {
        try
        {
            
            var deleted = _authorDao.Delete(id);
            if (!deleted)
            {
                return NoContent();
            }

            return Ok(true);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred trying to delete the author with id {id}.");
        }
    }
}