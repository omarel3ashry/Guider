using AutoMapper;
using Guider.Application.Contracts.Persistence;
using MediatR;

namespace Guider.Application.UseCases.Clients.Query.GetClientDetails
{
    public class GetClientDetailsQueryHandler : IRequestHandler<GetClientDetailsQuery, ClienttoReturnVM>
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;


        public GetClientDetailsQueryHandler(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;

        }
        public async Task<ClienttoReturnVM> Handle(GetClientDetailsQuery request, CancellationToken cancellationToken)
        {
            var Client = await _clientRepository.GetClientWithAppointments(request.Id);

            var clienttoReturn = _mapper.Map<ClienttoReturnVM>(Client);

            return clienttoReturn;





        }
    }
}
