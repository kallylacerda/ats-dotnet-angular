using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Municipio;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class MunicipiosController : ControllerBase
  {
    public IMunicipioService _service { get; set; }

    public MunicipiosController(IMunicipioService service)
    {
      _service = service;
    }

    [HttpGet]
    public async Task<ActionResult> Get(byte ufId)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      try
      {
        if (ufId == 0)
        {
          return Ok(await _service.GetAll());
        }
        return Ok(await _service.GetByUfId(ufId));
      }
      catch (ArgumentException aex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, aex.Message);
      }
    }

    [HttpGet]
    [Route("{id}", Name = "GetMunicipioWithId")]
    public async Task<ActionResult> GetById(ushort id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      try
      {
        return Ok(await _service.Get(id));
      }
      catch (ArgumentException aex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, aex.Message);
      }
    }
  }
}
