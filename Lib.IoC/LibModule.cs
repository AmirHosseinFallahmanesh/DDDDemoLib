using FluentValidation;
using Lib.Application.Book;
using Lib.Core.Contracts;
using Lib.Domain.Commands.Author;
using Lib.Domain.Commands.Author.Validators;
using Lib.Domain.Commands.Book;
using Lib.Domain.Commands.Book.Validators;
using Lib.Domain.Commands.Publisher;
using Lib.Domain.Commands.Publisher.Validators;
using Lib.Domain.Contracts;
using Lib.Domain.Events;
using Lib.Infra.Data.ElasticSearch;
using Lib.Infra.Data.Repositories;
using Lib.Infra.ElasticSearch;
using Lib.Infra.Messaging;
using Lib.Infra.Sql;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Lib.IoC
{
    public static class LibModule
    {
        public static void Register(this IServiceCollection services)
        {
            //data
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IPublisherRepository, PublisherRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookEventRepository, BookEventRepository>();
           

            //validators
            services.AddScoped<IValidator<CreateAuthorCommand>, CreateAuthorCommandValidator>();
            services.AddScoped<IValidator<UpdateAuthorCommand>, UpdateAuthorCommandValidator>();

            services.AddScoped<IValidator<CreatePublisherCommand>, CreatePublisherCommandValidator>();
            services.AddScoped<IValidator<UpdatePublisherCommand>, UpdatePublisherCommandValidator>();

            services.AddScoped<IValidator<CreateBookCommand>, CreateBookCommandValidator>();
            services.AddScoped<IValidator<UpdateBookCommand>, UpdateBookCommandValidator>();
            services.AddScoped<IValidator<DeleteBookCommand>, DeleteBookCommandValidator>();
            services.AddScoped<IValidator<PublicationCommand>, PublicationValidator>();


            //command Handler
            services.AddScoped<ICommandHandler<CreateBookCommand>, CreateBookCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateBookCommand>, UpdateBookCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteBookCommand>, DeleteBookCommandHandler>();


            //messaging

            services.AddScoped<IEventPublisher<BookEvent>, EventPublisher<BookEvent>>();
            services.AddScoped<IEventPublisher<DeleteBookEvent>, EventPublisher<DeleteBookEvent>>();
            services.AddTransient<IEventConsumer<BookEvent, Guid>, BookEventConsumer>();
            services.AddTransient<IEventConsumer<DeleteBookEvent, Guid>, DeleteBookEventConsumer>();
            services.AddScoped<IConsumerSubscription, ConsumerSubscription>();


            //elastic
            services.AddScoped<IElasticContextProvider, ElasticContextProvider>();
            services.AddScoped<IElasticConfigurationService, ElasticConfigurationService>();


        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibContext>
                (opt => opt.UseSqlServer(configuration.GetConnectionString("Server=localhost;Database=SampleLibrary;Trusted_Connection=True;")));
        }

    }


    //public static class ApplicationBuilderExtensions
    //{
    //    private static IConsumerSubscription consumerSubscription;
    //    public static IApplicationBuilder UseRabbitListener(this IApplicationBuilder app, IConsumerSubscription consumerSubscriptions)
    //    {
    //       consumerSubscription = consumerSubscriptions;
    //        var life = app.ApplicationService.GetSerice<IApplicationLifetime>;
    //        life.ApplicationStarted.Register(()=> consumerSubscriptions.Subscribe());
    //        life.ApplicationStopping.Register(()=> consumerSubscriptions.Unsubscribe());
    //        return app;

    //    }

     
    //}

}
