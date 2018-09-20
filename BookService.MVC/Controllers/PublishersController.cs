using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookService.Lib.DTO;
using BookService.Lib.Models;
using BookService.MVC.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace BookService.MVC.Controllers
{
    public class PublishersController : Controller
    {
        string baseuri = "http://localhost:53945/api/publishers";
        private object httpClient;

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

        [HttpPost]
        public async Task<IActionResult> Update(Publisher publisher)
        {
            string uri = $"{baseuri}/{publisher.Id}";


            Publisher p = await WebApiHelper.PutCallAPI<Publisher, Publisher>(uri, publisher);

            ViewBag.Mode = "Detail";
            return View("Detail", publisher);
        }

        [HttpPost]
        public IActionResult Insert(Publisher publisher)
        {
            string uri = $"{baseuri}/{publisher.Id}";

            // save in db

            ViewBag.Mode = "Detail";
            return View("Detail", publisher);
        }
    }
}