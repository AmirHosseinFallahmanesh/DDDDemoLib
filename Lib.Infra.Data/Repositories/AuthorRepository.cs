using Lib.Domain.Contracts;
using Lib.Domain.Entites;
using Lib.Infra.Sql;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.Infra.Data.Repositories
{
    public class AuthorRepository : CommonRepository<Author>, IAuthorRepository
    {
        public AuthorRepository(LibContext libContext)
            : base(libContext)
        {
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await context.Authors.AnyAsync(a => a.Name.Equals(name));
        }

        public async Task<IEnumerable<Author>> GetAllAsync()
        {
            return await context.Authors.AsNoTracking().ToListAsync();
        }
    }
}
