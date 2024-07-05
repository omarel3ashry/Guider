using Guider.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Application.Contracts.Infrastructure
{
    public interface IImageService
    {
        Task<List<String>> SaveImages(IFormFileCollection files, Consultant consultant);
    }
}
