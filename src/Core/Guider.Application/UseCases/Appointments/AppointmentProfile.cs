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
            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.ConsultantName, opt => opt.MapFrom(src => src.Consultant.User.FirstName))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.Consultant.SubCategory.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Consultant.SubCategory.Category.Name))
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.User.FirstName));

            CreateMap<AddAppointmentCommand, Appointment>();
            CreateMap<Appointment, AppointmentListDto>()
                .ForMember(dest => dest.ConsultantName, opt => opt.MapFrom(src => src.Consultant.User.FirstName))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.Consultant.SubCategory.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Consultant.SubCategory.Category.Name))
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.User.FirstName))
                .ForMember(dest => dest.ClientUserId, opt => opt.MapFrom(src => src.Client.UserId))
                .ForMember(dest => dest.ConsultantUserId, opt => opt.MapFrom(src => src.Consultant.UserId));
        }
    }
}
