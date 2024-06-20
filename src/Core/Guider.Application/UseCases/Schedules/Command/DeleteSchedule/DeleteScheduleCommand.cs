﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Schedules.Command.DeleteSchedule
{
    public class DeleteScheduleCommand : IRequest<bool>
    {
        public int ConsultantId { get; set; }
        public DateTime Date { get; set; }
    }
}