using System.Collections.Generic;
using BookService.Lib.DTO;
using BookService.MVC.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BookService.MVC.Controllers
{
    public class AuthorsController : Controller
    {
        string baseuri = "http://localhost:53945/api/authors";
        public IActionResult Index()
        {
            string uri = $"{baseuri}/basic";
            return View(WebApiHelper.GetApiResult<List<AuthorBasic>>(uri));
        }
    }
}