using AutoMapper;
using Guider.Application.UseCases.Users.Command.ClientRegister;
using Guider.Application.UseCases.Users.Command.ConsultantRegister;
using Guider.Domain.Entities;


namespace Guider.Application.UseCases.Users
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ClientRegisterCommand, User>();
            CreateMap<ClientRegisterCommand, Client>();
            CreateMap<ConsultantRegisterCommand, User>();
            CreateMap<ConsultantRegisterCommand, Consultant>();
        }
    }
}
