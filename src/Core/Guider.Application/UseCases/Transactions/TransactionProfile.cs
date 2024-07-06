using AutoMapper;
using Guider.Application.UseCases.Transactions.Command.AddTransaction;
using Guider.Application.UseCases.Transactions.Dto;
using Guider.Application.UseCases.Transactions.Query.GetTransactionQuery;
using Guider.Domain.Entities;

namespace Guider.Application.UseCases.Transactions
{
    internal class TransactionProfile : Profile
    {

        public TransactionProfile()
        {
            CreateMap<AddTransactionCommand, Transaction>();
            CreateMap<Transaction, TransactionToReturnDto>();
            CreateMap<TransactionToAddDto, Transaction>();
            CreateMap<Transaction, TransactionReturnDto>().ForMember(dest => dest.clientName, opt => opt.MapFrom(src => src.Appointment.Client.User.FirstName + " " + src.Appointment.Client.User.LastName)).
                ForMember(dest => dest.consultantName, opt => opt.MapFrom(src => src.Appointment.Consultant.User.FirstName + " " + src.Appointment.Consultant.User.LastName));



        }

    }
}
