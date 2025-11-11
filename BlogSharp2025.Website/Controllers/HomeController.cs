using BlogSharp2025.ApiClient;
using BlogSharp2025.DataAccessLibrary.Interfaces;
using BlogSharp2025.Website.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogSharp2025.Website.Controllers;
public class HomeController : Controller
{
    //IBlogPostDao _blogPostApiClient = new BlogPostDao()
    IBlogPostDao _blogPostApiClient = new BlogPostApiClient("https://localhost:7249");


    public IActionResult Index()
    {
        return View(_blogPostApiClient.GetAll());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
