using AutoMapper;
using Guider.Application.UseCases.Appointments.Command.AddAppointment;
using Guider.Application.UseCases.Appointments.Query.GetAllForConsultant;
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
            CreateMap<Appointment, AppointmentListDto>()
                .ForMember(dest => dest.ConsultantName, opt => opt.MapFrom(src => src.Consultant.User.FirstName))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.Consultant.SubCategory.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Consultant.SubCategory.Category.Name)); 
        }
    }
}
