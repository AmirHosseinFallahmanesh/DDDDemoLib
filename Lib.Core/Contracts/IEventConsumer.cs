using Lib.Core.Event;

namespace Lib.Core.Contracts
{
    public interface IEventConsumer<TMessage,TPrimaryKey>
        where TMessage:class,IMessage<TPrimaryKey>
    {
        void Subscribe();
        void Unsubscribe();
    }
}

