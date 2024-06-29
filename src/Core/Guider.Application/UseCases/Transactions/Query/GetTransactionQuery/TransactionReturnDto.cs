using Guider.Domain.Entities;
using Guider.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Transactions.Query.GetTransactionQuery
{
    public class TransactionReturnDto
    {
        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public string? clientName { get; set; }

        public string? consultantName {  get; set; }


    }
}
