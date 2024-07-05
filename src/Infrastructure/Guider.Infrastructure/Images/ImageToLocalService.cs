using Guider.Application.Contracts.Infrastructure;
using Guider.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Guider.Infrastructure.Images
{
    public class ImageToLocalService : IImageService
    {
        private readonly string _path;
        public ImageToLocalService()
        {
            _path = @"wwwroot\";
        }

        public async Task<string> SaveImageAsync(IFormFile file, Client client)
        {
            try
            {
                string fileExe = file.FileName.Split('.').Last();
                string imagePath = $"Images\\client\\cli_{client.Id}_pp.{fileExe}";
                string fullPath = _path + imagePath;
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
                using (FileStream stream = File.Create(fullPath))
                {
                    await file.CopyToAsync(stream);
                }

                return imagePath;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public async Task<string> SaveImageAsync(IFormFile file, Consultant consultant)
        {
            try
            {
                string fileExe = file.FileName.Split('.').Last();
                string imagePath = $"Images\\consultant\\con_{consultant.Id}_pp.{fileExe}";
                string fullPath = _path + imagePath;
                if (File.Exists(fullPath))
                {
                    File.Delete(fullPath);
                }
                using (FileStream stream = File.Create(fullPath))
                {
                    await file.CopyToAsync(stream);
                }

                return imagePath;
            }
            catch (Exception e)
            {
                return string.Empty;
            }
        }

        public async Task<List<string>> SaveImages(IFormFileCollection files, Consultant consultant)
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
                    if (File.Exists(fullPath))
                    {
                        File.Delete(fullPath);
                    }
                    using (FileStream stream = File.Create(fullPath))
                    {
                        await file.CopyToAsync(stream);
                    }
                    imagesUrls.Add(imagePath);
                }
                return imagesUrls;
            }
            catch (Exception e)
            {
                return new List<string>();
            }

        }
    }
}
