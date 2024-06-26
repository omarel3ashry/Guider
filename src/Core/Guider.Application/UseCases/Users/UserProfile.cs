using AutoMapper;
using Guider.Application.UseCases.Users.Command.ClientRegister;
using Guider.Application.UseCases.Users.Command.ConsultantRegister;
using Guider.Domain.Entities;
using System.Net.Mail;


namespace Guider.Application.UseCases.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ClientRegisterCommand, User>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(src => new MailAddress(src.Email).User));
            CreateMap<ClientRegisterCommand, Client>();
            CreateMap<ConsultantRegisterCommand, User>()
                .ForMember(dest => dest.UserName, src => src.MapFrom(src => new MailAddress(src.Email).User));
            CreateMap<ConsultantRegisterCommand, Consultant>();
        }
    }
}
