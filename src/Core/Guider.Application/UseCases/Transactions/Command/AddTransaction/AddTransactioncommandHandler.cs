using AutoMapper;
using Guider.Application.Contracts.Infrastructure;
using Guider.Application.Contracts.Persistence;
using Guider.Domain.Entities;
using MediatR;

namespace Guider.Application.UseCases.Transactions.Command.AddTransaction
{
    public class AddTransactioncommandHandler : IRequestHandler<AddTransactionCommand, bool>
    {

        private readonly IMapper _mapper;
        private readonly IRepository<Transaction> _transactionRepo;

        public AddTransactioncommandHandler(
            IMapper mapper,
            IRepository<Transaction> transactionRepo)
        {
            _mapper = mapper;
            _transactionRepo = transactionRepo;
            
        }

        public async Task<bool> Handle(AddTransactionCommand request, CancellationToken cancellationToken)
        {
            var mappedtransaction = _mapper.Map<Transaction>(request);
            var result = await _transactionRepo.AddAsync(mappedtransaction);
            return result;
        }
    }
}
