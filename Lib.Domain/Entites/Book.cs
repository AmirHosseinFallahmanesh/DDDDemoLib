using Lib.Core.Entity;
using Lib.Domain.ValueObjects;
using System;

namespace Lib.Domain.Entites
{
    public class Book:BaseEntity
    {
        public string Title { get;private set; }

        public Publication Publication { get;private set; }

        public Guid AuthorId { get; private set; }
        public Author Author { get; private set; }

        public Guid PublisherId { get; private set; }
        public Publisher Publisher { get; private set; }

        public Book(string title, Guid authorId, Guid publisherId, Publication publication)
        {
            Title = title;
            AuthorId = authorId;
            PublisherId = publisherId;
            Publication = publication;
            
        }

        public Book()
        {

        }

    }
}
