using Lib.Domain.Contracts;
using Lib.Domain.Entites;
using Lib.Infra.Sql;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.Infra.Data.Repositories
{
    public class PublisherRepository : CommonRepository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(LibContext libContext)
            : base(libContext)
        {
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await context.Publishers.AnyAsync(a => a.Name.Equals(name));
        }

        public async Task<IEnumerable<Publisher>> GetAllAsync()
        {
            return await context.Publishers.AsNoTracking().ToListAsync();
        }
    }
}
