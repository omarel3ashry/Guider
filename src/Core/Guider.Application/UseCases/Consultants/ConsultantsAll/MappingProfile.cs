using AutoMapper;
using Guider.Application.UseCases.Consultants.ConsultantPagination.Query;
using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.ConsultantsAll
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Consultant, ConsultantDto>()
                .ForMember(dest => dest.ConsultantName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
                .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SubCategory.Category.Name));
        }
    }
}