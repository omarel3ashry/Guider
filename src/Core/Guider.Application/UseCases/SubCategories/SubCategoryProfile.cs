using AutoMapper;
using Guider.Application.UseCases.SubCategories.Query.getSubCategoryList;
using Guider.Domain.Entities;

namespace Guider.Application.UseCases.SubCategories
{
    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<SubCategory, subCategoryDto>();
        }
    }
}
