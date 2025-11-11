using BlogSharp2025.ApiClient;
using BlogSharp2025.DataAccessLibrary.Interfaces;
using BlogSharp2025.DataAccessLibrary.Model;
using Microsoft.AspNetCore.Mvc;

namespace BlogSharp2025.Website.Controllers;
public class BlogPostController : Controller
{
    IBlogPostDao _blogPostApiClient = new BlogPostApiClient("https://localhost:7249");
    public IActionResult Details(int id)
    {
        return View(_blogPostApiClient.GetOne(id));
    }
    [HttpGet]
    public IActionResult Create() {
        return View();
    }

    [HttpPost]
    public IActionResult Create(BlogPost blogpost) {

        return Redirect("");
    
    }
}
