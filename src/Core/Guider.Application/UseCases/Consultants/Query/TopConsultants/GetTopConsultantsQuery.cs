using MediatR;

namespace Guider.Application.UseCases.Consultants.Query.TopConsultants
{
    public class GetTopConsultantsQuery : IRequest<List<TopConsultantsDto>>
    {
    }
}
