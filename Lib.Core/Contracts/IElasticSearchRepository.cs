using Lib.Core.Event;
using Lib.Core.Message;

namespace Lib.Core.Contracts
{
    public interface IElasticSearchRepository<TMessage, TPrimaryKey>:
        IPersistorRepository<TMessage,TPrimaryKey>,
        ISearchableRepository<TMessage,TPrimaryKey>
         where TMessage : class, IMessage<TPrimaryKey>
    {

    }
}

