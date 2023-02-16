using Lib.Core.Event;

namespace Lib.Domain.Events
{
    public class AuthorEvent : Message
    {
        public string Name { get; set; }
    }
}
