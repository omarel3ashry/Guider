﻿using AutoMapper;
using Guider.Application.Contracts.Persistence;
using Guider.Application.Exceptions;
using Guider.Application.UseCases.Appointments.Dto;
using Guider.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Appointments.Query
{
    public class GetAppointmentQueryHandler : IRequestHandler<GetAppointmentQuery, AppointmentToReturnDto>
    {
        private readonly IMapper _mapper;
        private readonly  IRepository<Appointment> _AppointmentRepo;
        public GetAppointmentQueryHandler(IMapper mapper, IRepository<Appointment> AppointmentRepo)
        {
            _mapper = mapper;
            _AppointmentRepo = AppointmentRepo;
        }

        public async Task<AppointmentToReturnDto> Handle(GetAppointmentQuery request, CancellationToken cancellationToken)
        {
            var appointment = await _AppointmentRepo.GetByIdAsync(request.id);
            if (appointment == null)
            {
                throw new NotFoundException("there is no appointment with this id");
            }
            return _mapper.Map<AppointmentToReturnDto>(appointment);
        }
    }
}