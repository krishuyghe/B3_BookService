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
        string baseuri = "http://localhost:53945/api/publishers";
        public IActionResult Index()
        {
            string uri = $"{baseuri}/basic";
            return View(WebApiHelper.GetApiResult<List<PublisherBasic>>(uri));
        }

        public IActionResult Detail(int id)
        {
            string uri = $"{baseuri}/{id}";
            ViewBag.Mode = "Detail";
            return View(WebApiHelper.GetApiResult<Publisher>(uri));            
        }

        public IActionResult Edit(int id)
        {
            string uri = $"{baseuri}/{id}";
            ViewBag.Mode = "Edit";
            return View("Detail",WebApiHelper.GetApiResult<Publisher>(uri));
        }
    }
}