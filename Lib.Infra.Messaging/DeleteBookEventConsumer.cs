using EasyNetQ;
using Lib.Core.Contracts;
using Lib.Domain.Contracts;
using Lib.Domain.Events;
using System;

namespace Lib.Infra.Messaging
{
    public class DeleteBookEventConsumer : IEventConsumer<DeleteBookEvent, Guid>
    { 
        private readonly IBookEventRepository _bookEventRepository;
        private IBus _bus;

        public DeleteBookEventConsumer(IBookEventRepository bookEventRepository)
        {
            _bookEventRepository = bookEventRepository;
        }
        public void Subscribe()
        {
            _bus = RabbitHutch.CreateBus("host=localhost;virtualhost=sample-library;username=guest;password=guest");
            _bus.Subscribe<DeleteBookEvent>(nameof(DeleteBookEvent), Handle);
        }

        public void Unsubscribe() => _bus.Dispose();

        protected  void Handle(DeleteBookEvent message)
        {
            _bookEventRepository.RemoveAsync(message.Id).Wait();
        }
    }



}
