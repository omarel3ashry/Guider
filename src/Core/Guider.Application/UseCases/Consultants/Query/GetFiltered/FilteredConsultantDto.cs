namespace Guider.Application.UseCases.Consultants.Query.GetFiltered
{
    public class FilteredConsultantDto
    {
        public int Id { get; set; }
        public string Bio { get; set; }
        public float HourlyRate { get; set; }
        public float AverageRate { get; set; }
        public string Image { get; set; }
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string SubCategoryName { get; set; }
        public string CategoryName { get; set; }
    }
}
