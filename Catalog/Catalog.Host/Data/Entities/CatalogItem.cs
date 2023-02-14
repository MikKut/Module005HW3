  #pragma warning disable CS8618

namespace Catalog.Host.Data.Entities;

public class CatalogItem
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public string PictureFileName { get; set; }

    public int CatalogTypeId { get; set; }

    public CatalogType CatalogType { get; set; }

    public int CatalogBrandId { get; set; }

    public CatalogBrand CatalogBrand { get; set; }

    public int AvailableStock { get; set; }
    public bool Equal(CatalogItem obj)
    {
        if (obj == null)
        {
            return false;
        }

        return obj.Name == Name &&
            Id == obj.Id &&
            obj.Description == Description &&
            obj.Price == Price &&
            PictureFileName == obj.PictureFileName &&
            CatalogBrandId == obj.CatalogBrandId &&
            CatalogTypeId == obj.CatalogTypeId &&
            AvailableStock == obj.AvailableStock;
    }
}
