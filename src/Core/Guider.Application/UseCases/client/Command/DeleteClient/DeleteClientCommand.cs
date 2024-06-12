using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.client.Command.DeleteClient
{
    public class DeleteClientCommand:IRequest<int>
    {
        public int ClientId { get; set; }
    }
}
