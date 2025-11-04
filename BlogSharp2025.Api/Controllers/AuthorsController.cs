using BlogSharp2025.DataAccessLibrary.Interfaces;
using BlogSharp2025.DataAccessLibrary.Model;
using BlogSharp2025.DataAccessLibrary.SqlServer;
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
    public ActionResult< IEnumerable<Author>> Get()
    {
        try
        {
            return Ok(_authorDao.GetAll());
        }
        catch (Exception ex)
        {
            //log the error

            return StatusCode(500, $"An error occurred trying to retrieve all authors.");
        }
    }
}
