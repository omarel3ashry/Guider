using Guider.Application.UseCases.consultant.Query.GetAll;

namespace Guider.Application.UseCases.consultant.Query.GetDetails
{
    public class ConsultantDetailsVM
    {
        public int Id { get; set; }
        public UserDto user { get; set; }
        public string Bio { get; set; }
        public float HourlyRate { get; set; }
        public string SubCategoryName { get; set; }
        public string CategoryName { get; set; }
        public List<ScheduledDto> Schedules { get; set; }


       
    }
}