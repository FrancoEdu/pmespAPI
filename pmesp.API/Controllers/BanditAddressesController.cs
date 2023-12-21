using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pmesp.Application.DTOs.Addresses;
using pmesp.Application.DTOs.BanditAddresses;
using pmesp.Application.Interfaces.Addresses;
using pmesp.Application.Interfaces.BanditAddresses;

namespace pmesp.API.Controllers;

[Route("api/banditAddress")]
[ApiController]
public class BanditAddressesController : ControllerBase
{
    private readonly IBanditAddressService _addressesService;

    public BanditAddressesController(IBanditAddressService addressesService)
    {
        _addressesService = addressesService;
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync(BanditAddressesDTO address)
    {
        var result = await _addressesService.PostAsync(address);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
