using Guider.Application.UseCases.Categories.CategorySearch.Query;
using Guider.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.Contracts.Persistence
{
    public interface ICategoryRepository : IRepository<Category>
    {

        Task<List<Consultant>> SearchConsultantsByCategoryAsync(int subCategoryId, string consultantName = null);
    }
}
