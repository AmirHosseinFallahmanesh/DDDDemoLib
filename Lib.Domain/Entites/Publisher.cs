using Lib.Core.Entity;
using System.Collections.Generic;

namespace Lib.Domain.Entites
{
    public class Publisher : BaseEntity
    {
        public Publisher(string name)
        {
            Name = name;
            Books = new List<Book>();
        }

        public string Name { get; private set; }
        public  List<Book> Books { get; private set; }
    }
}
