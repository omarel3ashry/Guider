using Guider.Domain.Common;

namespace Guider.Domain.Entities
{
    public class Consultant : Consumer
    {
        public string Bio { get; set; }
        public float HourlyRate { get; set; }
        public bool IsActive { get; set; }
        public bool IsVerified { get; set; }
        public int SubCategoryId { get; set; }
        public float? AverageRate { get; set; }
        public SubCategory SubCategory { get; set; }
        public IReadOnlyCollection<Schedule> Schedules { get; set; }

    }
}
