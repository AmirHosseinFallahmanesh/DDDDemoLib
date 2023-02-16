using Lib.Domain.Contracts;
using Lib.Domain.Events;
using System;

namespace Lib.Infra.Messaging
{
    public class BookEventConsumer : EventConsumer<BookEvent, Guid>
    {
        public BookEventConsumer(IBookEventRepository bookEventRepository):base(bookEventRepository)
        {

        }
    }



}
