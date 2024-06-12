using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.consultant.Command.DeleteConsultant
{
    public class DeleteConsultantCommand:IRequest<int>
    {
        public int ConsultantId { get; set; }
       
    }
}
