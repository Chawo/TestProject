using Entities.Models;
using System.Collections.Generic;

namespace Contracts.Interfaces
{
    public interface IFileRepository : IRepositoryBase<File>
    {
        void UploadFile(string fileName, string dbPath);
        IList<File> GetAllFiles();
    }
}
