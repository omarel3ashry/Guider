using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.client.Query.GetClientDetails
{
    public class GetClientDetailsQueryHandler : IRequestHandler<GetClientDetailsQuery, ClienttoReturnVM>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Client> _clientRepository;
        private readonly IRepository<Appointment> _appointmentRepository;

        public GetClientDetailsQueryHandler(IMapper mapper, IRepository<Client> ClientRepository, IRepository<Appointment> AppointmentRepository)
        {
            _mapper = mapper;
            _clientRepository = ClientRepository;
            _appointmentRepository = AppointmentRepository;
        }
        public async Task<ClienttoReturnVM> Handle(GetClientDetailsQuery request, CancellationToken cancellationToken)
        {
            var Client = await _clientRepository.GetByIdAsync(request.Id);

            var clienttoReturn = _mapper.Map<ClienttoReturnVM>(Client);

            return clienttoReturn;

            //need to include the appointment 



        }
    }
}
