using AutoMapper;
using Guider.Application.UseCases.Transactions.Command.AddTransaction;
using Guider.Application.UseCases.Transactions.Dto;
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



        }

    }
}
