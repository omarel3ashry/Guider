using System;

namespace Guider.Application.UseCases.Categories.CategorySearch.Query
{
    public class CategorySearchDto
    {
        public int Id { get; set; }
        public string ConsultantName { get; set; }
        public string SubCategoryName { get; set; }
        public float Rate { get; set; }
        public float HourlyRate { get; set; }
        public string Image { get; set; }
    }
}
