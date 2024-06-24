﻿using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.Contracts.Persistence
{
    public interface IScheduleRepository:IRepository<Schedule>
    {
        Task<bool> AddSchedulesAsync(List<Schedule> schedules);
        Task<List<Schedule>> GetSchedulesByConsultantIdAsync(int consultantId);
        Task<Schedule> GetScheduleByConsultantIdAndDateAsync(int consultantId, DateTime date);
        Task<bool> UpdateScheduleAsync(Schedule currentSchedule, List<Schedule> newSchedules);
        Task<bool> UpdateScheduleStateAsync(int consultantId, DateTime date,bool isReserved,int timeSpan);
    }
}
