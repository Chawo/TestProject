

using Contracts.Interfaces;
using Entities;
using Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repositories
{
    public class FileRepository : RepositoryBase<File>, IFileRepository
    {
        private readonly RepositoryContext repositoryContext;

        public FileRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        public IList<File> GetAllFiles()
        {
            var files = repositoryContext.Files.ToList();
            return files;
        }

        public void UploadFile(string fileName, string dbPath)
        {
            var newFile = new File()
            {
                Id = new System.Guid(),
                Name = fileName,
                ImgPath = dbPath
            };

            Create(newFile);
        }
    }
}
