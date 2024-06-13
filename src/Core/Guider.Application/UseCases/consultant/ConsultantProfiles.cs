using AutoMapper;

using Guider.Application.UseCases.consultant.Command.UpdateConsultant;
using Guider.Application.UseCases.consultant.Query.GetAll;
using Guider.Application.UseCases.consultant.Query.GetDetails;
using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.consultant
{
    public class ConsultantProfiles:Profile
    {
        public ConsultantProfiles()
        {
          

            CreateMap<Consultant, ConsultantVM>().ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SubCategory.Category.Name))
            .ForMember(dest => dest.Schedules, opt => opt.MapFrom(src => src.Schedules))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));
            



            CreateMap<Schedule,ScheduledDto>();
           

           

            CreateMap<Consultant, ConsultantUpdateDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));
                
            
            CreateMap<UpdateConsultantCommand, Consultant>().ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
