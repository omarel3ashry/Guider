using MediatR;

namespace Guider.Application.UseCases.Payment.Command.PayToConsultant
{
    public class PayToConsultantCommand:IRequest<bool>
    {

        public int appointmentId {  get; set; }    
    
    }
}
