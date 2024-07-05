using Guider.Application.Responses;
using MediatR;

namespace Guider.Application.UseCases.Consultants.Command.UpdateConsultant
{
    public class UpdateConsultantCommand : IRequest<BaseResponse<ConsultantUpdateDto>>
    {
        public int id { get; set; }
        public string Bio { get; set; }
        public float HourlyRate { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }   

    }
}
