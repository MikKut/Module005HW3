using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogBrandService : BaseDataService<ApplicationDbContext>, ICatalogBrandService
    {
        private readonly ICatalogBrandRepository _catalogBrandRepository;
        private readonly IMapper _mapper;
        public CatalogBrandService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogBrandRepository catalogBrandRepository,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _mapper = mapper;
            _catalogBrandRepository = catalogBrandRepository;
        }

        public Task<int?> Add(CatalogBrandDto itemToAdd)
        {
            return ExecuteSafeAsync(() => _catalogBrandRepository.Add(_mapper.Map<CatalogBrand>(itemToAdd)));
        }

        public Task<bool> Delete(CatalogBrandDto itemToDelete)
        {
            return ExecuteSafeAsync(() => _catalogBrandRepository.Delete(_mapper.Map<CatalogBrand>(itemToDelete)));
        }

        public Task<bool> Update(int id, CatalogBrandDto itemToAdd)
        {
            return ExecuteSafeAsync(() => _catalogBrandRepository.Update(id, _mapper.Map<CatalogBrand>(itemToAdd)));
        }
    }
}
