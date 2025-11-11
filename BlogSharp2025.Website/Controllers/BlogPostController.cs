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

        if (ModelState.IsValid)
        {
            //TODO: try catch
            var newId = _blogPostApiClient.Create(blogpost);

            return RedirectToAction("Details", "BlogPost", new { Id = newId }); 
        }
        //TODO: giv fejlbesked og  vis formular igen
        return View();
    }


    [HttpGet]
    public IActionResult Edit(int id)
    {
        //TODO: try catch
        return View(_blogPostApiClient.GetOne(id));
    }

    [HttpPost]
    public IActionResult Edit(BlogPost blogpost)
    {
        if (ModelState.IsValid)
        {
            //TODO: try catch
            _blogPostApiClient.Update(blogpost);
            return RedirectToAction("Details", "BlogPost", new { blogpost.Id }); 
        }
        //TODO: giv fejlbesked
        return View(blogpost);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        //TODO: try catch
        return View(_blogPostApiClient.GetOne(id));
    }

    [HttpPost]
    public IActionResult Delete(int id, BlogPost blogpost)
    {
            //TODO: try catch
            _blogPostApiClient.Delete(id);
            return RedirectToAction("Index", "Home");
    }
}
