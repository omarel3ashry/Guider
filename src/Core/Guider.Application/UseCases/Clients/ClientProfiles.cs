using AutoMapper;
using Guider.Application.UseCases.Clients.Command.UpdateClient;
using Guider.Application.UseCases.Clients.Query.GetClientDetails;
using Guider.Domain.Entities;

namespace Guider.Application.UseCases.Clients
{
    public class ClientProfiles : Profile
    {
        public ClientProfiles()
        {

            CreateMap<Client, ClienttoReturnVM>();
            CreateMap<User, UserClientDto>();
            CreateMap<Client, UserClientDto>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName));
            CreateMap<Appointment, AppointmentDTO>().ForMember(dest => dest.ConsultantName, opt => opt.MapFrom(src => src.Consultant.User.FirstName + " " + src.Consultant.User.LastName));
            CreateMap<Client, UpdateClientDto>().ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));

        }

    }
}
