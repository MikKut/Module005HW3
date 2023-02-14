using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Repositories;

public class CatalogItemRepository : ICatalogItemRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<CatalogItemRepository> _logger;

    public CatalogItemRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<CatalogItemRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int?> Add(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        var item = await _dbContext.AddAsync(new CatalogItem
        {
            CatalogBrandId = catalogBrandId,
            CatalogTypeId = catalogTypeId,
            Description = description,
            Name = name,
            PictureFileName = pictureFileName,
            Price = price
        });

        await _dbContext.SaveChangesAsync();

        return item.Entity.Id;
    }

    public async Task<bool> Delete(string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        var catalog = new CatalogItem() { Name = name, Description = description, Price = price, AvailableStock = availableStock, CatalogBrandId = catalogBrandId, CatalogTypeId = catalogTypeId, PictureFileName = pictureFileName };
        var item = await _dbContext.CatalogItems
           .SingleAsync(t => t.Equal(catalog));
        if (item == null)
        {
            return false;
        }

        _dbContext.Remove(new CatalogItem
        {
            CatalogBrandId = catalogBrandId,
            CatalogTypeId = catalogTypeId,
            Description = description,
            Name = name,
            PictureFileName = pictureFileName,
            Price = price,
            AvailableStock = availableStock,
        });

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Update(int id, string name, string description, decimal price, int availableStock, int catalogBrandId, int catalogTypeId, string pictureFileName)
    {
        var item = await _dbContext.CatalogItems
           .FindAsync(id);
        if (item == null)
        {
            return false;
        }

        item!.AvailableStock = availableStock;
        item!.Name = name;
        item!.Description = description;
        item!.Price = price;
        item!.CatalogTypeId = catalogTypeId;
        item!.CatalogBrandId = catalogBrandId;
        item!.PictureFileName = pictureFileName;
        await _dbContext.SaveChangesAsync();
        return true;
    }
}