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
    public AuthorsController(IAuthorDao authorDao) => _authorDao = authorDao;

    [HttpGet]
    public IEnumerable<Author> Get()
    {
        return null;
    }
}
