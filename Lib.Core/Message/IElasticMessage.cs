using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Core.Message
{
   public interface IElasticMessage<TPrimaryKey>
    {
        TPrimaryKey Id { get; set; }
    }
}
