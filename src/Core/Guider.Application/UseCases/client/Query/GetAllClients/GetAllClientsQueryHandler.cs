using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.UseCases.client.Query.GetClientDetails;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.client.Query.GetAllClients
{
    public class GetAllClientsQueryHandler : IRequestHandler<GetAllClientsQuery, List<ClienttoReturnVM>>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Client> _clientrepository;

        public GetAllClientsQueryHandler(IMapper mapper,IRepository<Client> Clientrepository)
        {
            _mapper = mapper;
            _clientrepository = Clientrepository;
        }
        public async  Task<List<ClienttoReturnVM>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var AllClients= (await _clientrepository.ListAllAsync()).OrderBy(x=>x.Id).ToList();
            var ClientsToReturn =_mapper.Map<List< ClienttoReturnVM>>(AllClients);
            return ClientsToReturn;
        }
    }
}
