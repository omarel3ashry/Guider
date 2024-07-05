using AutoMapper;
using Guider.Application.UseCases.Consultants.Command.UpdateConsultant;
using Guider.Application.UseCases.Consultants.Query;
using Guider.Application.UseCases.Consultants.Query.GetFiltered;
using Guider.Application.UseCases.Consultants.Query.TopConsultants;
using Guider.Domain.Entities;

namespace Guider.Application.UseCases.Consultants
{
    public class ConsultantProfiles : Profile
    {
        public ConsultantProfiles()
        {

            CreateMap<Consultant, ConsultantDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SubCategory.Category.Name));

            CreateMap<Schedule, ScheduledDto>();

            CreateMap<Appointment, AppointmentDto>()
            .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.User.FirstName + " " + src.Client.User.LastName));

            CreateMap<Consultant, ConsultantUpdateDto>().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));

            CreateMap<UpdateConsultantCommand, Consultant>().ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Consultant, TopConsultantsDto>()
                 .ForMember(dest => dest.ConsultantName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name)).ReverseMap();
            CreateMap<Consultant, FilteredConsultantDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SubCategory.Category.Name));
        }
    }
}
