using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERP.Core.Interfaces
{
    public interface IGetFile
    {
        Stream? GetFile(string FileName, string FolderName);
    }
}