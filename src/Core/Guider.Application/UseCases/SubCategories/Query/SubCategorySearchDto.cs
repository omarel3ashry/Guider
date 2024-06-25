namespace Guider.Application.UseCases.SubCategories.Query
{
    public class SubCategorySearchDto
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

