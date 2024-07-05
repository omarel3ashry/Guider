using Guider.Domain.Entities;


namespace Guider.Application.Contracts.Identity
{
    public interface ITokenFactory
    {
        Task<string> GenerateToken(User user);
    }
}
