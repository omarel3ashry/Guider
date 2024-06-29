using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Transactions.Query.GetTransactionQuery
{
    public class getTransactionByUserIdQuery:IRequest<List<TransactionReturnDto>>
    {
  
        public int  UserId { get; set; }

    
    
    }
}
