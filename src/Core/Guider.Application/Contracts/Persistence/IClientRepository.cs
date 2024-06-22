﻿using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.Contracts.Persistence
{
    public interface IClientRepository :IRepository<Client>
    {
        Task<List<Client>> GetAllClientWithAppointments();
        Task<Client>  GetClientWithAppointments(int id);
        
    }
}