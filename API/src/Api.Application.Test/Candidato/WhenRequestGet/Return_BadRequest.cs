using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Candidato;
using Api.Domain.Interfaces.Services.Candidato;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Candidato.WhenRequestGet
{
  public class Return_BadRequest
  {
    private CandidatosController _controller;

    [Fact(DisplayName = "Its possible perform Getted.")]
    public async Task Its_Possible_Call_Get_Controller()
    {
      var serviceMock = new Mock<ICandidatoService>();
      var name = Faker.Name.FullName();
      var email = Faker.Internet.Email();

      serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
          new CandidatoDtoCompleto
          {
            Id = Guid.NewGuid(),
            NomeCompleto = name,
            Email = email,
            CreatedAt = DateTime.UtcNow
          }
      );

      _controller = new CandidatosController(serviceMock.Object);
      _controller.ModelState.TryAddModelError("Id", "Formato inválido");

      var result = await _controller.Get(default(Guid));

      Assert.True(result is BadRequestObjectResult);
    }

  }
}
