using Lib.Core.Contracts;
using Lib.Domain.Entites;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.Domain.Contracts
{
    public interface IAuthorRepository : IRepository<Author>
    {
        Task<bool> ExistsAsync(string name);
      
        Task<IEnumerable<Author>> GetAllAsync();
    }
}
