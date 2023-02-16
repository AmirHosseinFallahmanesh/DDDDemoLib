using Lib.Core.Contracts;
using Lib.Domain.Entites;
using Lib.Domain.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.Domain.Contracts
{
    public interface IPublisherRepository : IRepository<Publisher>
    {
        Task<bool> ExistsAsync(string name);
        Task<IEnumerable<Publisher>> GetAllAsync();
    }

    public interface IBookEventRepository : IElasticSearchRepository<BookEvent,Guid>
    {
        Task<IEnumerable<BookEvent>> GetByTextAsync(string text);
    }
}
