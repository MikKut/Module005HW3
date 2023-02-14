#pragma warning disable CS8618
namespace Catalog.Host.Models.Requests
{
    public class CreateRequest<T>
    {
        public T Data { get; set; }
    }
}
