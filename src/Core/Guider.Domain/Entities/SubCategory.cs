namespace Guider.Domain.Entities
{
    public class SubCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        public IReadOnlyCollection<Consultant> Consultants { get; set; }
    }
}
