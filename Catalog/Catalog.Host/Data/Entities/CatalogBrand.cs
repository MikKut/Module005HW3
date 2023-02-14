#pragma warning disable CS8618
using System.Xml.Linq;

namespace Catalog.Host.Data.Entities;

public class CatalogBrand
{
    public int Id { get; set; }

    public string Brand { get; set; }
    public bool Equal(CatalogBrand obj)
    {
        if (obj == null)
        {
            return false;
        }

        return obj.Id == Id &&
            obj.Brand == Brand;
    }
}