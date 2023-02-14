namespace Catalog.Host.Repositories.Interfaces
{
    public interface ICrudRepository<T>
        where T : class
    {
        Task<int?> Add(T itemToAdd);
        Task<bool> Delete(T itemToDelete);
        Task<bool> Update(int id, T itemToAdd);
    }
}
