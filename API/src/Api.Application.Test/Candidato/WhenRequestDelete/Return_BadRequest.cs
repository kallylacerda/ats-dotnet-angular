using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Candidato;
using Api.Domain.Interfaces.Services.Candidato;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Candidato.WhenRequestDelete
{
  public class Return_BadRequest
  {
    private CandidatosController _controller;

    [Fact(DisplayName = "Its possible perform Deleted.")]
    public async Task Its_Possible_Call_Delete_Controller()
    {
      var serviceMock = new Mock<ICandidatoService>();

      serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);

      _controller = new CandidatosController(serviceMock.Object);
      _controller.ModelState.AddModelError("Id", "Formato inválido");

      var result = await _controller.Delete(default(Guid));

      Assert.True(result is BadRequestObjectResult);
      Assert.False(_controller.ModelState.IsValid);
    }
  }
}
