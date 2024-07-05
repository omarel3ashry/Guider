namespace Guider.Application.UseCases.Consultants.Query.ConsultantPagination
{
    public class PaginatedConsultantDto
    {
        public List<ConsultantDto> Consultants { get; set; }
        public int TotalCount { get; set; }
    }
}
