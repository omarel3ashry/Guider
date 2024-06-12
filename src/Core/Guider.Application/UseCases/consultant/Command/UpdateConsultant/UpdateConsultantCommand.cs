using Guider.Application.UseCases.consultant.Command.CreateConsultant;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.consultant.Command.UpdateConsultant
{
    public class UpdateConsultantCommand: IRequest<ConsultantCreateOrUpdateDto>
    {
        public int ConsultantId { get; set; }
        public string Bio { get; set; }
        public float HourlyRate { get; set; }
        

    }
}
