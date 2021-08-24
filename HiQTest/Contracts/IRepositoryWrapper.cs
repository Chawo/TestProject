using Contracts.Interfaces;

namespace Contracts
{
    public interface IRepositoryWrapper
    {
        IFileRepository File { get; }
        void Save();
    }
}
