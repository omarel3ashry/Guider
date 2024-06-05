using Guider.Application.UseCases.consultant.Query.GetDetails;

namespace Guider.Application.UseCases.consultant.Query.GetAll
{
    public class ConsultantListVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string Bio { get; set; }
        public float HourlyRate { get; set; }
        public SubCategoryDTO SubCategory { get; set; }
    }
}