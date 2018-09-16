using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace BookService.WebAPI.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerCrudBase<Book, BookRepository>
    {

        public BooksController(BookRepository bookRepository): base (bookRepository)
        {
        }

        // GET: api/Books
        [HttpGet]
        public override async Task<IActionResult> Get()
        {
            return Ok(await repository.GetAllInclusive());
        }

        // GET: api/Books/Basic
        [HttpGet]
        [Route("Basic")]
        public async Task<IActionResult> GetBookBasic()
        {
            return Ok(await repository.ListBasic());
        }

        // GET: api/books/imagebyname/book2.jpg
        [HttpGet]
        [Route("ImageByName/{filename}")]
        public IActionResult ImageByFileName(string filename)
        {
            var image = Path.Combine(Directory.GetCurrentDirectory(),
                             "wwwroot", "images", filename);
            return PhysicalFile(image, "image/jpeg");
        }

        // GET: api/books/imagebyid/6
        [HttpGet]
        [Route("ImageById/{bookid}")]
        public async Task<IActionResult> ImageById(int bookid)
        {
            BookDetail book = await repository.GetDetailById(bookid);
            return ImageByFileName(book.FileName);
        }

    }
}