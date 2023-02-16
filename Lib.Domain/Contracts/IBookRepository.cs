using Lib.Core.Contracts;
using Lib.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lib.Domain.Contracts
{
    public interface IBookRepository : IRepository<Book>
    {
        Task<bool> ExistsAsync(string title);
        Book GetById(Guid id);
        void Delete(Guid id);
        Task<IEnumerable<Book>> GetAllAsync();
    }
}
