using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ERP.Core.Interfaces;

namespace ERP.Infrastructure.Shared
{
    public class GetFileService : IGetFile
    {
        private readonly string _basePath;
        public GetFileService(string basePath)
        {
            _basePath = basePath;
        }

        public Stream? GetFile(string FileName, string FolderName)
        {
            if (string.IsNullOrEmpty(FileName) || string.IsNullOrEmpty(FolderName)) return null;
            string targetFolder = Path.Combine(_basePath, FolderName);
            if (!Path.Exists(targetFolder)) return null;
            string targetFile = Path.Combine(targetFolder, FileName);
            if (!File.Exists(targetFile)) return null;


            return new FileStream(targetFile, FileMode.Open, FileAccess.Read, FileShare.Read, bufferSize: 4096, useAsync: true);

        }
    }
}