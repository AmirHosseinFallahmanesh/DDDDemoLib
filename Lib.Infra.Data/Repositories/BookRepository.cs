using Lib.Domain.Contracts;
using Lib.Domain.Entites;
using Lib.Infra.Sql;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lib.Infra.Data.Repositories
{
    public class BookRepository : CommonRepository<Book>,IBookRepository
    {
        public BookRepository(LibContext libContext):base(libContext)
        {

        }
        public void Delete(Guid id)
        {
            var entity = context.Books.FirstOrDefault(b => b.Id == id);
            context.Books.Remove(entity);
        }

        public async Task<bool> ExistsAsync(string title)
        {
            return await context.Books.AnyAsync(b => b.Title.Equals(title));
        }


     
        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await context.Books.AsNoTracking().ToListAsync();
        }

        public Book GetById(Guid id)
        {
            return context.Books.AsNoTracking()
                .Include(a => a.Author)
                .Include(a => a.Publisher)
                .Include(a => a.Publication)
                .FirstOrDefault(a => a.Id == id);
        }
    }
}
