using Guider.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Admin.Command.VerifyConsultant
{
    public class VerifyConsultantCommand : IRequest<BaseResponse>
    {
        public int Id { get; set; }
    }
}
