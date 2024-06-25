namespace Guider.Application.UseCases.Consultants.Query.ConsultantSearch
{
    public class ConsultantSearchDto
    {
        public int Id { get; set; }
        public string ConsultantName { get; set; }
        public string SubCategoryName { get; set; }
        public string CategoryName { get; set; }
        public float HourlyRate { get; set; }
        public float Rate { get; set; }
        public string Image { get; set; }
    }
}
