using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.Contracts.Persistence
{
    public interface IConsultantRepository:IRepository<Consultant>
    {
        Task<List<Consultant>> GetConsultantsWithCategory();
    }
}
