using System.Collections.Generic;
using System.Text;

namespace Lib.Core.Event
{
    public interface IMessage<TKey>
    {
        TKey Id { get; set; }
    }
}
