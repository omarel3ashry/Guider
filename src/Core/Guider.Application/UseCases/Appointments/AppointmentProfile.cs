using AutoMapper;
using Guider.Application.UseCases.Appointments.Dto;
using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments
{
    internal class AppointmentProfile: Profile
    {
        public AppointmentProfile()
        {

            CreateMap<AppointmentToUpdateDto, Appointment>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<Appointment, AppointmentToReturnDto>();
        }



    }
}
