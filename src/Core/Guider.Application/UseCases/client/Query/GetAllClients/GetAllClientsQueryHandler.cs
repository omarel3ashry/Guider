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
        private readonly IClientRepository _clientRepository;

        public GetAllClientsQueryHandler(IMapper mapper,IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }
        public async  Task<List<ClienttoReturnVM>> Handle(GetAllClientsQuery request, CancellationToken cancellationToken)
        {
            var AllClients = await _clientRepository.GetAllClientWithAppointments();
            var ClientsToReturn =_mapper.Map<List< ClienttoReturnVM>>(AllClients);
            return ClientsToReturn;
        }
    }
}
