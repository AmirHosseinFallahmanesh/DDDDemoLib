using Lib.Core.Event;
using Lib.Domain.ValueObjects;

namespace Lib.Domain.Events
{
    public class BookEvent : Message
    {
        public string Title { get; set; }
        public Publication Publication { get; set; }
        public AuthorEvent AuthorCreateEvent { get; set; }
        public PublisherEvent PublisherCreateEvent { get; set; }
    }
}
