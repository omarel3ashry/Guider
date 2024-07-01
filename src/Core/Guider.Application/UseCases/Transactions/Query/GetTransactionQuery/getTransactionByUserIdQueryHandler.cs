using AutoMapper;
using Guider.Application.Contracts.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Transactions.Query.GetTransactionQuery
{
    public class getTransactionByUserIdQueryHandler : IRequestHandler<getTransactionByUserIdQuery, List<TransactionReturnDto>>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepository;
        public getTransactionByUserIdQueryHandler(IMapper mapper,ITransactionRepository transactionRepository) 
        {
       
            _mapper = mapper;
            _transactionRepository = transactionRepository;
        
        }
        public async Task<List<TransactionReturnDto>> Handle(getTransactionByUserIdQuery request, CancellationToken cancellationToken)
        {

            var transactions=await _transactionRepository.GetTransactionsByUserId(request.UserId);
            var returnTransaction=_mapper.Map<List<TransactionReturnDto>>(transactions);
            return returnTransaction;

        }
    }
}
