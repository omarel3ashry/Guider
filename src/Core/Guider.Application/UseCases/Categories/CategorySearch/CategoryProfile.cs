using AutoMapper;
using Guider.Application.UseCases.Categories.CategorySearch.Query;
using Guider.Application.UseCases.Categories.Query.GetListOfCategories;
using Guider.Application.UseCases.Consultants.ConsultantSearch.Query;
using Guider.Domain.Entities;

namespace Guider.Application.UseCases.Categories.CategorySearch
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Consultant, CategorySearchDto>()
                .ForMember(dest => dest.ConsultantName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Appointments.Any() ? src.Appointments.Average(a => a.Rate) : 0))
                .ForMember(dest => dest.HourlyRate, opt => opt.MapFrom(src => src.HourlyRate))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));

            CreateMap<Category, CategoryDto>();
        }
    }
}
