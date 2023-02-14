#pragma warning disable CS8618
namespace Catalog.Host.Data.Entities;

public class CatalogType
{
    public int Id { get; set; }

    public string Type { get; set; }
    public bool Equal(CatalogType obj)
    {
        if (obj == null)
        {
            return false;
        }

        return obj.Id == Id &&
            obj.Type == Type;
    }
}