namespace Contracts
{
    public interface IRepositoryBase<T>
    {
        void Create(T entity);
    }
}
