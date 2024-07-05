namespace Guider.Application.UseCases.Categories.Query
{
    public class CategoryDto
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public IReadOnlyCollection<SubCategoryDto> SubCategories { get; set; }
    }
}
