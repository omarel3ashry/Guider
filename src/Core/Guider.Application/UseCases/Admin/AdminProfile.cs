using AutoMapper;
using Guider.Application.UseCases.Admin.Query.GetUnVerifiedConsultantDetailes;
using Guider.Application.UseCases.Admin.Query.GetUnVerifiedConsultants;
using Guider.Domain.Entities;

namespace Guider.Application.UseCases.Admin
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<Consultant, ConsultantListDto>()
                .ForMember(dest => dest.Name, src => src.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dest => dest.SubcatrgoryName, src => src.MapFrom(src => src.SubCategory.Name))
                .ForMember(dest => dest.Email, src => src.MapFrom(src => src.User.Email));

            CreateMap<Consultant, ConsultantDetailsDto>()
                .ForMember(dest => dest.SubcatrgoryName, src => src.MapFrom(src => src.SubCategory.Name))
                .ForMember(dest => dest.FirstName, src => src.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, src => src.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.Email, src => src.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.Attachments, src => src.MapFrom(src => src.Attachments.Select(e => e.ImageUrl).ToList()));



        }
    }
}
