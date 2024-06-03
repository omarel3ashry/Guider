namespace Guider.Domain.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IReadOnlyCollection<SubCategory> SubCategories { get; set; }
    }
}
