using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos.Candidato;
using Api.Domain.Interfaces.Services.Candidato;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class CandidatosController : ControllerBase
  {
    private ICandidatoService _service;

    public CandidatosController(ICandidatoService service)
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
    [Route("{id}", Name = "GetCandidatoWithId")]
    public async Task<ActionResult> Get(Guid id)
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

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CandidatoDtoCreate Candidato)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      try
      {
        var result = await _service.Post(Candidato);
        if (result != null)
        {
          return Created(new Uri(Url.Link("GetCandidatoWithId", new { id = result.Id })), result);
        }
        return BadRequest();
      }
      catch (ArgumentException aex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, aex.Message);
      }
    }

    [HttpPut]
    public async Task<ActionResult> Put([FromBody] CandidatoDtoUpdate Candidato)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      try
      {
        var result = await _service.Put(Candidato);
        if (result != null)
        {
          return Ok(result);
        }
        return BadRequest();
      }
      catch (ArgumentException aex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, aex.Message);
      }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(Guid id)
    {
      if (!ModelState.IsValid)
        return BadRequest(ModelState);

      try
      {
        return Ok(await _service.Delete(id));
      }
      catch (ArgumentException aex)
      {
        return StatusCode((int)HttpStatusCode.InternalServerError, aex.Message);
      }
    }
  }
}
