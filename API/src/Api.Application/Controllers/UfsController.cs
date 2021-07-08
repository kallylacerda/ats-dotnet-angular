using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.Uf;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UfsController : ControllerBase
  {
    public IUfService _service { get; set; }

    public UfsController(IUfService service)
    {
      _service = service;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      try
      {
        return Ok(await _service.GetAll());
      }
      catch (ArgumentException aex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, aex.Message);
      }
    }

    [HttpGet]
    [Route("{id}", Name = "GetUfWithId")]
    public async Task<ActionResult> Get(byte id)
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
