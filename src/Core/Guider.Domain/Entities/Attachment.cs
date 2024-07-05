namespace Guider.Domain.Entities
{
    public class Attachment
    {
        public int Id { get; set; }
        public int ConsultantId { get; set; }
        public string ImageUrl { get; set; }
        public Consultant Consultant { get; set; }
    }
}
