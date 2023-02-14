using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;

namespace Catalog.Host.Services
{
    public class CatalogTypeService : BaseDataService<ApplicationDbContext>, ICatalogTypeService
    {
        private readonly ICatalogTypeRepository _catalogTypeRepository;
        private readonly IMapper _mapper;
        public CatalogTypeService(
            IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
            ILogger<BaseDataService<ApplicationDbContext>> logger,
            ICatalogTypeRepository catalogItemRepository,
            IMapper mapper)
            : base(dbContextWrapper, logger)
        {
            _mapper = mapper;
            _catalogTypeRepository = catalogItemRepository;
        }

        public Task<int?> Add(CatalogTypeDto itemToAdd)
        {
            return ExecuteSafeAsync(() => _catalogTypeRepository.Add(_mapper.Map<CatalogType>(itemToAdd)));
        }

        public Task<bool> Delete(CatalogTypeDto itemToDelete)
        {
            return ExecuteSafeAsync(() => _catalogTypeRepository.Delete(_mapper.Map<CatalogType>(itemToDelete)));
        }

        public Task<bool> Update(int id, CatalogTypeDto itemToAdd)
        {
            return ExecuteSafeAsync(() => _catalogTypeRepository.Update(id, _mapper.Map<CatalogType>(itemToAdd)));
        }
    }
}
