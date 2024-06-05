using Guider.Application.UseCases.client.Query.GetClientDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.client.Query.GetAllClients
{
    public class GetAllClientsQuery:IRequest<List<ClienttoReturnVM>>
    {
    }
}
