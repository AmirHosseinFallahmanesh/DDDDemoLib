using EasyNetQ;
using Lib.Core.Contracts;

namespace Lib.Infra.Messaging
{
    public abstract class EventConsumer<TMessage, TPrimarykey> :
        IEventConsumer<TMessage, TPrimarykey>
        where TMessage : class, Core.Event.IMessage<TPrimarykey>
        where TPrimarykey : struct
    {
        protected readonly IElasticSearchRepository<TMessage, TPrimarykey> elasticSearchRepository;

        protected IBus bus;
        public EventConsumer(IElasticSearchRepository<TMessage,TPrimarykey> elasticSearchRepository)
        {
            this.elasticSearchRepository = elasticSearchRepository;
        }


        public virtual void Subscribe()
        {
            bus = RabbitHutch.CreateBus("host=localhost;virtualhost=Lib;username=guest;password=guest");
            bus.Subscribe<TMessage>(nameof(TMessage), Handle);
        }

        public virtual void Unsubscribe()
        {
            bus.Dispose();
        }
        protected virtual void Handle(TMessage message)
        {
            elasticSearchRepository.AddOrUpdateAsync(message).Wait();
        }
    }



}
