using AutoMapper;
using Guider.Application.UseCases.client.Query.GetClientDetails;
using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.client
{
    public class ClientProfiles:Profile
    {
        public ClientProfiles() {

            CreateMap<Client,ClienttoReturnVM>();
            CreateMap<Appointment,AppointmentDTO>();
        }

    }
}
