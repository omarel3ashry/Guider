using Guider.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Guider.Application.Contracts.Infrastructure
{
    public interface IImageService
    {
        Task<List<string>> SaveImages(IFormFileCollection files, Consultant consultant);
        Task<string> SaveImageAsync(IFormFile file, Client client);
        Task<string> SaveImageAsync(IFormFile file, Consultant consultant);
    }
}
