#pragma warning disable CS8618
namespace Catalog.Host.Models.Requests
{
    public class DeleteRequest<T>
        where T : class
    {
        public T Data { get; set; }
    }
}
