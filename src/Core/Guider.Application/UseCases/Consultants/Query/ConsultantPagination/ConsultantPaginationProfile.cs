using AutoMapper;
using Guider.Application.UseCases.Consultants.Query.ConsultantPagination.Query;
using Guider.Domain.Entities;

namespace Guider.Application.UseCases.Consultants.Query.ConsultantPagination
{
    public class ConsultantPaginationProfile : Profile
    {
        public ConsultantPaginationProfile()
        {
            CreateMap<Consultant, ConsultantDto>()
               .ForMember(dest => dest.ConsultantName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SubCategory.Category.Name))
                .ForMember(dest => dest.HourlyRate, opt => opt.MapFrom(src => src.HourlyRate))
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Appointments.OrderByDescending(a => a.Date).FirstOrDefault().Rate))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));
        }
    }
}
