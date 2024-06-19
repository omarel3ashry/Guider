using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Payment.command.Refund
{
    public class RefundPaymentCommand: IRequest<Stripe.Refund>
    {

       
        public int AppointmentId {  get; set; }
    }
}
