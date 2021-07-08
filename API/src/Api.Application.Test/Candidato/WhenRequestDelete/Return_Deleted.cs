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
  public class Return_Deleted
  {
    private CandidatosController _controller;

    [Fact(DisplayName = "Its possible perform Deleted.")]
    public async Task Its_Possible_Call_Delete_Controller()
    {
      var serviceMock = new Mock<ICandidatoService>();

      serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);

      _controller = new CandidatosController(serviceMock.Object);

      var result = await _controller.Delete(Guid.NewGuid());

      Assert.True(result is OkObjectResult);

      var resultValue = ((OkObjectResult)result).Value;

      Assert.NotNull(resultValue);
      Assert.True((Boolean)resultValue);
    }
  }
}
