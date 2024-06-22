using MediatR;

namespace Guider.Application.UseCases.Payment.command.PayToconsultant
{
    public class PayToConsultantCommand:IRequest<bool>
    {

        public int appointmentId {  get; set; }    
    
    }
}
