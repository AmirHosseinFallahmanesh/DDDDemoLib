using Lib.Core.Event;
using Lib.Core.Message;
using System.Threading.Tasks;

namespace Lib.Core.Contracts
{
    public interface IPersistorRepository<TMessage, TPrimaryKey> where TMessage : class, IMessage<TPrimaryKey>
    {
        TMessage Add(TMessage entity);
        Task<TMessage> AddAsync(TMessage entity);

        TMessage AddOrUpdate(TMessage entity);
        Task<TMessage> AddOrUpdateAsync(TMessage entity);

        void Remove(TMessage entity);
        Task<TMessage> RemoveAsync(TMessage entity);
        Task<TMessage> RemoveAsync(TPrimaryKey id);


    }
}

