using Guider.Application.UseCases.consultant.Query.GetDetails;
using Guider.Domain.Entities;

namespace Guider.Application.UseCases.consultant.Query.GetAll
{
    public class ConsultantListVM
    {
        public int Id { get; set; }
        
        public string Bio { get; set; }
        public float HourlyRate { get; set; }
        public UserDto user { get; set; }
       
        public string SubCategoryName { get; set; }
        public string CategoryName { get; set; }
        public List<ScheduledDto> Schedules { get; set; }
    }
}