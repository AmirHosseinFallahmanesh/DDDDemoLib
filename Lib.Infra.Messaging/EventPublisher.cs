using EasyNetQ;
using Lib.Core.Contracts;

namespace Lib.Infra.Messaging
{
    public class EventPublisher<TMessage> : IEventPublisher<TMessage> where TMessage : class
    {
        public void Publish(TMessage message)
        {
           using(var bus = RabbitHutch.CreateBus("host=localhost;virtualhost=Lib;username=guest;password=guest"))
            {
                bus.Publish(message);
            }
        }
    }



}
