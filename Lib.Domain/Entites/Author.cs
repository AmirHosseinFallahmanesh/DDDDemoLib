using Lib.Core.Entity;
using System.Collections.Generic;

namespace Lib.Domain.Entites
{
    public class Author : BaseEntity
    {
        public Author(string name)
        {
            Name = name;
            Books = new List<Book>();
        }

        public string Name { get; private set; }
        public List<Book> Books { get; private set; }

    }
}
