using System;

namespace Lib.Core.Event
{
    public abstract class Message : IMessage<Guid>
    {
        public Guid Id { get; set; }
        public Message()
        {
            Id = Guid.NewGuid();
        }
    }
}
