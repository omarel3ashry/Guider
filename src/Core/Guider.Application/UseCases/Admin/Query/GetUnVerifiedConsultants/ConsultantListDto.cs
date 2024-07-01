using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.UseCases.Admin.Query.GetUnVerifiedConsultants
{
    public class ConsultantListDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string SubcatrgoryName { get; set; }

    }
}
