using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pmesp.Application.DTOs.Addresses;
using pmesp.Application.Interfaces.Addresses;

namespace pmesp.API.Controllers;

[Route("api/address")]
[ApiController]
public class AddressController : ControllerBase
{
    private readonly IAddressesService _addressesService;

    public AddressController(IAddressesService addressesService)
    {
        _addressesService = addressesService;
    }

    [HttpPost]
    public async Task<ActionResult> PostAsync([FromBody]AddressDTO address)
    {
        var result = await _addressesService.PostAsync(address);
        return result.Success ? Ok(result) : BadRequest(result);
    }
}
