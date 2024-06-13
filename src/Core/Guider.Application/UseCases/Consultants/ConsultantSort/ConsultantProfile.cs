using AutoMapper;
using Guider.Application.UseCases.Consultants.ConsultantSortt.Query;
using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.ConsultantSortt
{
    public class ConsultantProfile : Profile
    {
        public ConsultantProfile()
        {
            CreateMap<Consultant, SortByHourlyRateDto>()
                 .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                 .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.SubCategory.Category.Name))
                 .ForMember(dest => dest.SubCategory, opt => opt.MapFrom(src => src.SubCategory.Name))
                 .ForMember(dest => dest.HourlyRate, opt => opt.MapFrom(src => src.HourlyRate))
                 .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));
        }
    }
}
