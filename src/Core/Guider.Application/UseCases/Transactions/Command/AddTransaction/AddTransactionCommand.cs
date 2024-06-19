using Guider.Application.UseCases.Transactions.Dto;
using Guider.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Guider.Application.UseCases.Transactions.Command.AddTransaction
{
    public  class AddTransactionCommand : IRequest<bool>
    {

        public TransactionType Type { get; set; } 
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public int UserId { get; set; }
        public int AppointmentId { get; set; }
        public string PaymentIntentId { get; set; }

    }
}
