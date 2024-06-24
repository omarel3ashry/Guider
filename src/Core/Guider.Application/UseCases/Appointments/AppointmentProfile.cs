using AutoMapper;
using Guider.Application.UseCases.Appointments.Command.InsertAppointment;
using Guider.Application.UseCases.Appointments.Query.GetById;
using Guider.Domain.Entities;

namespace Guider.Application.UseCases.Appointments
{
    internal class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {

            CreateMap<Appointment, AppointmentToReturnDto>();
            CreateMap<AddAppointmentCommand, Appointment>();
        }



    }
}
