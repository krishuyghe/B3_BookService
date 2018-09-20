using BookService.Lib.DTO;
using BookService.MVC.Helpers;
using BookService.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookService.MVC.Controllers
{
    public class BooksController : Controller
    {
        string baseuri = "http://localhost:53945/api/books";
        public IActionResult Index()
        {
            string bookUri = $"{baseuri}/basic";
            return View(WebApiHelper.GetApiResult<List<BookBasic>>(bookUri));
        }

        public IActionResult Detail(int id)
        {
            string geekJokesUri = "https://geek-jokes.sameerkumar.website/api";
            string ipsumUri = "https://baconipsum.com/api/?type=meat-and-filler&paras=2&format=text";
            string bookUri = $"{baseuri}/detail/{id}";

            return View(new BookDetailExtraViewModel
            {
                BookDetail = WebApiHelper.GetApiResult< BookDetail>(bookUri),
                AuthorJoke = WebApiHelper.GetApiResult<string>(geekJokesUri),
                BookSummary = new HttpClient().GetStringAsync(ipsumUri).Result //pure string response, no json
            });
        }


        



    }
}