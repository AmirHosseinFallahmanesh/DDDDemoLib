using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lib.Core.Contracts
{
    public interface ISearchableRepository<TMessage,TPrimaryKey> where TMessage : class
    {
        TMessage GetById(TPrimaryKey id);
        Task<TMessage> GetByIdAsync(TPrimaryKey id);
        Task<IEnumerable<TMessage>> GetAllAsync();
    }
}

