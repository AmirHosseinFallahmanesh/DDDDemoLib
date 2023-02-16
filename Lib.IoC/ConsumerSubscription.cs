using Lib.Core.Contracts;
using Lib.Domain.Events;
using System;

namespace Lib.IoC
{
    public interface IConsumerSubscription
    {
        void Subscribe();
        void Unsubscribe();
    }
    public class ConsumerSubscription : IConsumerSubscription
    {
        private readonly IEventConsumer<BookEvent, Guid> bookEventConsumer;
        private readonly IEventConsumer<DeleteBookEvent, Guid> deleteBookeventConsumer;

        public ConsumerSubscription(IEventConsumer<BookEvent,Guid> bookEventConsumer,
            IEventConsumer<DeleteBookEvent, Guid> deleteBookeventConsumer)
        {
            this.bookEventConsumer = bookEventConsumer;
            this.deleteBookeventConsumer = deleteBookeventConsumer;
        }
        public void Subscribe()
        {
            deleteBookeventConsumer.Subscribe();
            bookEventConsumer.Subscribe();
        }

        public void Unsubscribe()
        {
            deleteBookeventConsumer.Unsubscribe();
            bookEventConsumer.Unsubscribe();
        }
    }
}
