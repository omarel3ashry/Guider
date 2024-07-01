using AutoMapper;
using Guider.Application.UseCases.Appointments.Query.AppointmentSort;
using Guider.Application.UseCases.Consultants.Command.UpdateConsultant;
using Guider.Application.UseCases.Consultants.Query.ConsultantPagination;
using Guider.Application.UseCases.Consultants.Query.ConsultantSearch;
using Guider.Application.UseCases.Consultants.Query.ConsultantSort;
using Guider.Application.UseCases.Consultants.Query.GetAll;
using Guider.Application.UseCases.Consultants.Query.GetFiltered;
using Guider.Domain.Entities;

namespace Guider.Application.UseCases.Consultants
{
    public class ConsultantProfiles : Profile
    {
        public ConsultantProfiles()
        {

            CreateMap<Consultant, ConsultantVM>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SubCategory.Category.Name));

            CreateMap<Schedule, ScheduledDto>();

            CreateMap<Consultant, ConsultantUpdateDto>();

            CreateMap<UpdateConsultantCommand, Consultant>().ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<Appointment, AppointmentDto>()
                .ForMember(dest => dest.ClientName, opt => opt.MapFrom(src => src.Client.User.FirstName + " " + src.Client.User.LastName));

            CreateMap<Consultant, ConsultantDto>()
                .ForMember(dest => dest.ConsultantName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SubCategory.Category.Name));

            CreateMap<Consultant, ConsultantSearchDto>()
                .ForMember(dest => dest.ConsultantName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SubCategory.Category.Name))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
                .ForMember(dest => dest.HourlyRate, opt => opt.MapFrom(src => src.HourlyRate));

            CreateMap<Consultant, SortByHourlyRateDto>()
                .ForMember(dest => dest.ConsultantName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SubCategory.Category.Name))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name));

            CreateMap<Consultant, SortconsultantByRateDto>()
                .ForMember(dest => dest.ConsultantName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SubCategory.Category.Name))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name));

            CreateMap<Consultant, FilteredConsultantDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SubCategory.Category.Name));
        }
    }
}
