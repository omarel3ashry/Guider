using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.client.Command.CreateClient
{
    public class ClientCreateCommand:IRequest<ClientCreateDto>
    {
        public int UserId { get; set; }
    }
}
