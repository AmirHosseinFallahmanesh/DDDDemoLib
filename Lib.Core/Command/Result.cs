using System.Collections.Generic;

namespace Lib.Core.Command
{
    public class Result
    {
        private readonly IEnumerable<string> errors;

        public Result(bool success,IEnumerable<string> errors)
        {
            this.errors = errors;
        }

    }
}
