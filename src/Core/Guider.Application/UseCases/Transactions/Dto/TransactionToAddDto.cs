using Guider.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Transactions.Dto
{
    public class TransactionToAddDto
    {

        public TransactionType Type { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public int UserId { get; set; }
        public int AppointmentId { get; set; }
        public string PaymentIntentId { get; set; }


    }
}
