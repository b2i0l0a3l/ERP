using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Interfaces;

namespace ERP.Application.services
{
    public class LocalFileStorageService : IFileStorageService
    {
        private readonly string _basePath;

        public LocalFileStorageService(string basePath)
        {
            _basePath = basePath;
        } 
        public async Task<string> SaveFileAsync(Stream fileStream, string fileName, string folderName)
        {
            string targetFolder = Path.Combine(_basePath, folderName);

            if (!Directory.Exists(targetFolder))
                Directory.CreateDirectory(targetFolder);

            string uniqueFileName = $"{Guid.NewGuid()}_{fileName}";
            string fullPath = Path.Combine(targetFolder, uniqueFileName);

            using (FileStream destinationStream = new FileStream(fullPath, FileMode.Create))
            {
                await fileStream.CopyToAsync(destinationStream);
            }

            return Path.Combine(folderName, uniqueFileName);
    
        }
    }
}