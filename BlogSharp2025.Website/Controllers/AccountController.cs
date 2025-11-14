using BlogSharp2025.DataAccessLibrary.Model;
using BlogSharp2025.Website.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using System.Security.Claims;

namespace BlogSharp2025.Website.Controllers;
public class AccountController : Controller
{
    [HttpGet]
    public IActionResult Login()
    {
       
        return View();
    }

    [HttpPost]
    public async Task< IActionResult> LoginAsync(LoginModel loginModel, [FromQuery] string returnUrl)
    {
        if(loginModel.Email.Equals("test@test.net", StringComparison.InvariantCultureIgnoreCase ))
        {
            //We simulate calling the API through an apiclient
            //but hardcode an author
            var author = new Author() { 
                Id = 52,
                Email = loginModel.Email
            };
            await SignIn(author);
            Redirect("/");
        }
        return View();
    }

    //creates the authentication cookie with claims
    private async Task SignIn(Author author)
    {
        var claims = new List<Claim>
        {
            new Claim("id",author.Id.ToString()),
            new Claim(ClaimTypes.Email, author.Email),
        };

        var claimsIdentity = new ClaimsIdentity(
            claims, CookieAuthenticationDefaults.AuthenticationScheme);

        var authProperties = new AuthenticationProperties
        {
            #region often used options - to consider including in cookie
            //AllowRefresh = <bool>,
            // Refreshing the authentication session should be allowed.

            //ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
            // The time at which the authentication ticket expires. A 
            // value set here overrides the ExpireTimeSpan option of 
            // CookieAuthenticationOptions set with AddCookie.

            //IsPersistent = true,
            // Whether the authentication session is persisted across 
            // multiple requests. When used with cookies, controls
            // whether the cookie's lifetime is absolute (matching the
            // lifetime of the authentication ticket) or session-based.

            //IssuedUtc = <DateTimeOffset>,
            // The time at which the authentication ticket was issued.

            //RedirectUri = <string>
            // The full path or absolute URI to be used as an http 
            // redirect response value. 
            #endregion
        };

        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity),
            authProperties);

        TempData["Message"] = $"You are logged in as {claimsIdentity.Name}";
    }


}
