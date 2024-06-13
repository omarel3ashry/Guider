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
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointment, SortAppointementByRateDto>()
                 .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.Consultant.User.FirstName} {src.Consultant.User.LastName}"))
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Consultant.SubCategory.Category.Name))
                .ForMember(dest => dest.SubCategory, opt => opt.MapFrom(src => src.Consultant.SubCategory.Name))
                .ForMember(dest => dest.Rate, opt => opt.MapFrom(src => src.Rate))
                .ForMember(dest => dest.HourlyRate, opt => opt.MapFrom(src => src.Consultant.HourlyRate))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.Consultant.Image));
        }


    }
}
