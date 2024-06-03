namespace Guider.Application.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException(string msg) : base(msg) { }
    }
}
