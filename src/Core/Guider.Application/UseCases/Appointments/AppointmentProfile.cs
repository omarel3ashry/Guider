using AutoMapper;
using Guider.Application.UseCases.Appointments.Command.AddAppointment;
using Guider.Application.UseCases.Appointments.Query.GetById;
using Guider.Domain.Entities;

namespace Guider.Application.UseCases.Appointments
{
    internal class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {

            CreateMap<Appointment, AppointmentDto>();
            CreateMap<AddAppointmentCommand, Appointment>();
        }



    }
}
