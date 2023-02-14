namespace Catalog.Host.Services.Interfaces
{
    public interface ICrudService<T>
        where T : class
    {
        Task<int?> Add(T itemToAdd);
        Task<bool> Delete(T itemToDelete);
        Task<bool> Update(int id, T itemToAdd);
    }
}
