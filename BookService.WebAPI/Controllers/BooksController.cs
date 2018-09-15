using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using BookService.WebAPI.DTO;

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

        // GET: api/Book/3
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            return Ok(repository.GetById(id));
        }

        // GET: api/book/imagebyname/book2.jpg
        [HttpGet]
        [Route("ImageByName/{filename}")]
        public IActionResult ImageByFileName(string filename)
        {
            var image = Path.Combine(Directory.GetCurrentDirectory(),
                             "wwwroot", "images", filename);
            return PhysicalFile(image, "image/jpeg");
        }

        // GET: api/book/imagebyid/6
        [HttpGet]
        [Route("ImageById/{bookid}")]
        public IActionResult ImageById(int bookid)
        {
            BookDetail book = repository.GetById(bookid);
            return ImageByFileName(book.FileName);
        }

    }
}