using AutoMapper;
using Guider.Application.UseCases.Schedules.Command.CreateSchedule;
using Guider.Application.UseCases.Schedules.Command.UpdateSchedule;
using Guider.Application.UseCases.Schedules.Query.GetAllSchdeulesForConsultant;
using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Schedules
{
    public class ScheduleProfile:Profile
    {
        public ScheduleProfile()
        {
            CreateMap<CreateScheduleDto, Schedule>();
            CreateMap<Schedule,ScheduleDto>();
            CreateMap<UpdateScheduleDto, Schedule>();
            CreateMap<UpdateScheduleCommand, Schedule>();
        }
        
    }
}
