using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using Microsoft.EntityFrameworkCore;
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
            return db.Books
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToList();
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

        public BookDetail GetById(int id)
        {
            return db.Books.Select(b => new BookDetail
            {
                Id = b.Id,
                Title = b.Title,
                ISBN = b.ISBN,
                Year = b.Year,
                Price = b.Price,
                NumberOfPages = b.NumberOfPages,
                AuthorId = b.Author.Id,
                AuthorName = $"{b.Author.LastName} {b.Author.FirstName}",
                PublisherId = b.Publisher.Id,
                PublisherName = b.Publisher.Name,
                FileName = b.FileName
            }).FirstOrDefault();
        }
    }


}
