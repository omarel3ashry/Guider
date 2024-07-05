using AutoMapper;
using Guider.Application.UseCases.Payment.Command.UserPayment;
using Guider.Application.UseCases.Schedules.Command.CreateSchedule;
using Guider.Application.UseCases.Schedules.Command.UpdateSchedule;
using Guider.Application.UseCases.Schedules.Query.GetAllSchdeulesForConsultant;
using Guider.Domain.Entities;

namespace Guider.Application.UseCases.Schedules
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<CreateScheduleDto, Schedule>();
            CreateMap<Schedule, ScheduleDto>();
            CreateMap<UpdateScheduleDto, Schedule>();
            CreateMap<UpdateScheduleCommand, Schedule>();
            CreateMap<CreateOrUpdatePaymentIntentCommand, UserPaymentDto>();
        }

    }
}
