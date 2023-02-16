using AutoMapper;
using Lib.Domain.Commands.Book;
using Lib.Domain.Events;
using Lib.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lib.Application.AutoMapper
{
   public static class BookMapper
    {
        public static Domain.Entites.Book CommandToEntity(CreateBookCommand command)
        {
            var config = new MapperConfiguration(config =>
              {
                  config.CreateMap<CreateBookCommand, Domain.Entites.Book>();
                  config.CreateMap<PublicationCommand, Publication>();


              });
            var mapper = config.CreateMapper();
            return mapper.Map<Domain.Entites.Book>(command);


        }

        public static Domain.Entites.Book CommandToEntity(UpdateBookCommand command)
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<UpdateBookCommand, Domain.Entites.Book>();
                config.CreateMap<PublicationCommand, Publication>();


            });
            var mapper = config.CreateMapper();
            return mapper.Map<Domain.Entites.Book>(command);


        }

        public static BookEvent EntityToEvent(Domain.Entites.Book entity)
        {
            var config = new MapperConfiguration(config =>
            {
               
                config.CreateMap<Domain.Entites.Book, BookEvent>();
                config.CreateMap<Domain.Entites.Publisher, PublisherEvent>();
                config.CreateMap<Domain.Entites.Author    , AuthorEvent>();


            });
            var mapper = config.CreateMapper();
            return mapper.Map<BookEvent>(entity);
        }





    }
}
