using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Payment.command.PayToconsultant
{
    public class PayToConsultantCommand:IRequest<bool>
    {

        public int appointmentId {  get; set; }    
    
    }
}
