using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Interfaces;
using Microsoft.Extensions.Logging;

namespace ERP.Application.services
{
    public class RemoveFile : IRemoveFile
    {
        private readonly string _BasePath;
        public RemoveFile(string basePath)
        {
            _BasePath = basePath;
        }
        public void remove(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return;
            }
            string targetPath = Path.Combine(_BasePath, path);

            if (File.Exists(targetPath))
            {
                File.Delete(targetPath);
            }
        }
    }
}