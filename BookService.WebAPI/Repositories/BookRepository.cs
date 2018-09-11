using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookService.WebAPI.Repositories
{

    public class BookRepository
    {
        private BookServiceContext db;
        public BookRepository(BookServiceContext context)
        {
            db = context;
        }
        public List<Book> List()
        {
            // return a list of books with all Book-properties
            return db.Books.ToList();
        }

        public List<BookBasic> ListBasic()
        {
            // return a list of BookBasic DTO-items (Id and Title only)
            return db.Books.Select(b => new BookBasic
            {
                Id = b.Id,
                Title = b.Title
            }).ToList();
        }
    }


}
