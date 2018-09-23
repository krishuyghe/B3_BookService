using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.Lib.DTO;
using BookService.Lib.Models;
using BookService.MVC.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace BookService.MVC.Controllers
{
    public class PublishersController : Controller
    {
        string baseuri = "https://localhost:44396/api/publishers";
        public IActionResult Index()
        {
            string uri = $"{baseuri}/basic";
            return View(WebApiHelper.GetApiResult<List<PublisherBasic>>(uri));
        }

        public IActionResult Detail(int id)
        {
            string uri = $"{baseuri}/{id}";

            return View(WebApiHelper.GetApiResult<Publisher>(uri));
                
        }
    }
}