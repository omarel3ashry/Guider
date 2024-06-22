using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.Contracts.Persistence
{
    public interface ISubCategoryRepository
    {
        Task<List<Consultant>> SearchConsultantsBySubCategoryAsync(int subCategoryId, string consultantName = null);
        Task<List<SubCategory>> getbyCategoryId(int categoryId);

    }
}
