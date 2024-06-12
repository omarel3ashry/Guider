using AutoMapper;
using Guider.Application.UseCases.consultant.Command.CreateConsultant;
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
            CreateMap<Consultant,ConsultantDetailsVM>().ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SubCategory.Category.Name))
            .ForMember(dest => dest.Schedules, opt => opt.MapFrom(src => src.Schedules));
           
            CreateMap<Consultant,ConsultantListVM>().ForMember(dest => dest.SubCategoryName, opt => opt.MapFrom(src => src.SubCategory.Name))
            .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.SubCategory.Category.Name))
            .ForMember(dest => dest.Schedules, opt => opt.MapFrom(src => src.Schedules));
           
            CreateMap<Schedule,ScheduledDto>();
            CreateMap<User,UserDto>();

            CreateMap<CreateConsultantCommand, Consultant>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => true))
            .ForMember(dest => dest.IsVerified, opt => opt.MapFrom(src => false));

            CreateMap<Consultant, ConsultantCreateOrUpdateDto>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.User.Image))
                .ForMember(dest => dest.BankAccount, opt => opt.MapFrom(src => src.User.BankAccount));
            
            CreateMap<UpdateConsultantCommand, Consultant>().ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}
