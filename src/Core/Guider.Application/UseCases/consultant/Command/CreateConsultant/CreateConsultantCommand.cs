using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.consultant.Command.CreateConsultant
{
    public class CreateConsultantCommand:IRequest<ConsultantCreateOrUpdateDto>
    {
        
        public string Bio { get; set; }
        public float HourlyRate { get; set; }
        public int UserId { get; set; }
        public int SubCategoryId { get; set; }
    }
}
