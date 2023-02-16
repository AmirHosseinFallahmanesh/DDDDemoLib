using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Lib.Domain.Contracts;
using Lib.Domain.Entites;

namespace Lib.Application.Publisher
{
    public class PublisherQueries : IPublihserQuery
    {
        private readonly IPublisherRepository publisherRepository;

        public PublisherQueries(IPublisherRepository publisherRepository)
        {
            this.publisherRepository = publisherRepository;
        }
        public async Task<IEnumerable<Domain.Entites.Publisher>> GetAllAsync()
        {
            return await publisherRepository.GetAllAsync();
        }
    }
    public interface IPublihserQuery
    {
        Task<IEnumerable<Domain.Entites.Publisher>> GetAllAsync();
        
    }

}
