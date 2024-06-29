namespace Guider.Application.UseCases.Consultants.Query.ConsultantSort
{
    public class SortByHourlyRateDto
    {
        public int Id { get; set; }
        public string ConsultantName { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public float Rate { get; set; }
        public float HourlyRate { get; set; }
        public float AverageRate { get; set; }
        public string Image { get; set; }
    }
}
