using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.client.Query.GetClientDetails
{
    public class GetClientDetailsQuery : IRequest<ClienttoReturnVM>
    {
        public int Id { get; set; }
    }
}
