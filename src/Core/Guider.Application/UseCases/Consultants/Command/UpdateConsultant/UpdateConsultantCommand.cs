﻿using Guider.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Consultants.Command.UpdateConsultant
{
    public class UpdateConsultantCommand : IRequest<BaseResponse<ConsultantUpdateDto>>
    {
        public int ConsultantId { get; set; }
        public string Bio { get; set; }
        public float HourlyRate { get; set; }


    }
}