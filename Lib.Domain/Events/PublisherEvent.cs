using Lib.Core.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Domain.Events
{
    public class PublisherEvent:Message
    {
        public string Name { get; set; }
    }
}
