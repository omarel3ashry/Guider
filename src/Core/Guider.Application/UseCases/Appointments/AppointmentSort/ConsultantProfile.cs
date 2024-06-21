using AutoMapper;
using Guider.Application.UseCases.Appointments.AppointmentSort.Query;
using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments.AppointmentSort
{
    public class ConsultantProfile : Profile
    {
        public ConsultantProfile()
        {
            CreateMap<Consultant, SortconsultantByRateDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
              .ForMember(dest => dest.ConsultantName, opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
              .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SubCategory.Category.Name))
              .ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
              .ForMember(dest => dest.HourlyRate, opt => opt.MapFrom(src => src.HourlyRate))
              .ForMember(dest => dest.AverageRate, opt => opt.MapFrom(src => src.AverageRate))
              .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Image));

        }
    }


    
}
