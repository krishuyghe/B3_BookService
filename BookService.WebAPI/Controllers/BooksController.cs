using BookService.WebAPI.DTO;
using BookService.WebAPI.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

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

        // GET: api/Books
        [HttpGet]
        public async Task<IActionResult> GetBooks()
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

        // GET: api/Books/3
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            return Ok(await repository.GetById(id));
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