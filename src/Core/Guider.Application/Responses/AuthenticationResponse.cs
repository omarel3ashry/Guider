namespace Guider.Application.Responses
{
    public class AuthenticationResponse
    {
        public bool Success { get; set; }
        public int Id { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }

}
