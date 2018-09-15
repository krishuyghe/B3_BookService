using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace BookService.WebAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        BookRepository repository;

        public BooksController(BookRepository bookRepository)
        {
            repository = bookRepository;
        }

        // GET: api/Book
        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(repository.List());
        }

        // GET: api/Book/Basic
        [HttpGet]
        [Route("Basic")]
        public IActionResult GetBookBasic()
        {
            return Ok(repository.ListBasic());
        }

    }
}