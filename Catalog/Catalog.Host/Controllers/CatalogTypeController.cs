using System.Net;
using Catalog.Host.Models.Dtos;
using Catalog.Host.Models.Requests;
using Catalog.Host.Models.Response;
using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route(ComponentDefaults.DefaultRoute)]
public class CatalogTypeController : ControllerBase
{
    private readonly ILogger<CatalogItemController> _logger;
    private readonly ICatalogTypeService _catalogTypeService;

    public CatalogTypeController(
        ILogger<CatalogItemController> logger,
        ICatalogTypeService catalogTypeService)
    {
        _logger = logger;
        _catalogTypeService = catalogTypeService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(AddItemResponse<int?>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Add(CreateRequest<CatalogTypeDto> request)
    {
        var result = await _catalogTypeService.Add(request.Data);
        return Ok(new AddItemResponse<int?>() { Id = result });
    }

    [HttpDelete]
    [ProducesResponseType(typeof(IsSuccededResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(DeleteRequest<CatalogTypeDto> request)
    {
        var result = await _catalogTypeService.Delete(request.Data);
        return Ok(new IsSuccededResponse() { IsSucceeded = result });
    }

    [HttpPost]
    [ProducesResponseType(typeof(IsSuccededResponse), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Update(UpdateRequest<CatalogTypeDto> request)
    {
        var result = await _catalogTypeService.Update(request.ID, request.NewData);
        return Ok(new IsSuccededResponse() { IsSucceeded = result });
    }
}