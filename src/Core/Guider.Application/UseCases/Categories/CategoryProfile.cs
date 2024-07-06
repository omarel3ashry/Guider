using AutoMapper;
using Guider.Application.UseCases.Categories.Query;
using Guider.Domain.Entities;

namespace Guider.Application.UseCases.Categories
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
            CreateMap<SubCategory, SubCategoryDto>();
        }
    }
}
