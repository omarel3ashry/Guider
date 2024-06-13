using Guider.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.consultant.Command.UpdateImage
{
    public class UpdateImageCommand:IRequest<BaseResponse<string>>
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Image { get; set; }
    }
}
