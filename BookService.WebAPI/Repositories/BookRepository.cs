using AutoMapper;
using AutoMapper.QueryableExtensions;
using BookService.WebAPI.DTO;
using BookService.WebAPI.Models;
using BookService.WebAPI.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookService.WebAPI.Repositories
{

    public class BookRepository: MappingRepository<Book>
    {

        public BookRepository(BookServiceContext context, IMapper mapper): base(context, mapper)
        {
        }
        public async Task<List<Book>> GetAllInclusive()
        {
            return await GetAll()
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .ToListAsync();
        }

        public async Task<List<BookBasic>> ListBasic()
        {
            // return a list of BookBasic DTO-items (Id and Title only) using AutoMapper
            return await db.Books
                .ProjectTo<BookBasic>(mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<BookDetail> GetDetailById(int id)
        {
            return await db.Books.Select(b => new BookDetail
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
            }).FirstOrDefaultAsync(b => b.Id == id);
        }
    }


}
