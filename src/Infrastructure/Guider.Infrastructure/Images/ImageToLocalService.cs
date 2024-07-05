using Guider.Application.Contracts.Infrastructure;
using Guider.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guider.Infrastructure.Images
{
    public class ImageToLocalService : IImageService
    {
        private readonly string _path;
        public ImageToLocalService()
        {
            _path = @"wwwroot\";
        }
        public async Task<List<string>> SaveImages(IFormFileCollection files,Consultant consultant)
        {
            try
            {
                List<string> imagesUrls = new List<string>();
                int counter = 0;
                foreach (var file in files)
                {
                    counter++;
                    string fileExe = file.FileName.Split('.').Last();
                    string imagePath = $"ConsultantAttachments\\Con{consultant.Id}_doc_{counter}.{fileExe}";
                    string fullPath = _path + imagePath;
                    if (System.IO.File.Exists(fullPath))
                    {
                        System.IO.File.Delete(fullPath);
                    }
                    using (FileStream stream = System.IO.File.Create(fullPath))
                    {
                        await file.CopyToAsync(stream);
                    }
                    imagesUrls.Add(imagePath);
                }
                return imagesUrls;
            }
            catch(Exception e) {
                return new List<string>();
            }
           
        }
    }
}
