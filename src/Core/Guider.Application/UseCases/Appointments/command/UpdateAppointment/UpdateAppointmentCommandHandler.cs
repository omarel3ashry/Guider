using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Exceptions;
using Guider.Application.UseCases.Appointments.Dto;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments.command.UpdateAppointment
{
    public class UpdateAppointmentCommandHandler : IRequestHandler<UpdateAppointmentCommand,AppointmentToReturnDto>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Appointment> _appointmentRepo;
        public UpdateAppointmentCommandHandler(IMapper mapper,IRepository<Appointment> AppointmentRepo)
        {
            _mapper = mapper;
            _appointmentRepo = AppointmentRepo;
        }

        public async Task<AppointmentToReturnDto> Handle(UpdateAppointmentCommand request, CancellationToken cancellationToken)
        {

            var appointment = await _appointmentRepo.GetByIdAsync(request.appointmentToUpdateDto.Id);
            if (appointment == null)
            {
                throw new NotFoundException("there is no appointment with this id");
            }

            _mapper.Map(request.appointmentToUpdateDto, appointment);
            await _appointmentRepo.UpdateAsync(appointment);

            return _mapper.Map<AppointmentToReturnDto>(appointment);




        }
    }
}
