using Contracts;
using Contracts.Interfaces;
using Entities;
using Repository.Repositories;

namespace Repository
{
    public class RepositoryWrapper: IRepositoryWrapper
    {
        private RepositoryContext repositoryContext;
        private IFileRepository fileRepository;

        public RepositoryWrapper(RepositoryContext repoContext)
        {
            repositoryContext = repoContext;
        }

        public IFileRepository File
        {
            get
            {
                if (fileRepository == null)
                {
                    fileRepository = new FileRepository(repositoryContext);
                }
                return fileRepository;
            }
        }

        
        public void Save()
        {
            repositoryContext.SaveChanges();
        }
    }
}
