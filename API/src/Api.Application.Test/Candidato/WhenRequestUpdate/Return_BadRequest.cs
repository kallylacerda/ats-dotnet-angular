using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Candidato;
using Api.Domain.Interfaces.Services.Candidato;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Candidato.WhenRequestUpdate
{
  public class Return_BadRequest
  {
    private CandidatosController _controller;

    [Fact(DisplayName = "Its possible perform Updated.")]
    public async Task Its_Possible_Call_Update_Controller()
    {
      var serviceMock = new Mock<ICandidatoService>();
      var name = Faker.Name.FullName();
      var email = Faker.Internet.Email();

      serviceMock.Setup(m => m.Put(It.IsAny<CandidatoDtoUpdate>())).ReturnsAsync(
          new CandidatoDtoUpdateResult
          {
            Id = Guid.NewGuid(),
            NomeCompleto = name,
            Email = email,
            UpdatedAt = DateTime.UtcNow
          }
      );

      _controller = new CandidatosController(serviceMock.Object);
      _controller.ModelState.AddModelError("Email", "É um campo obrigatório");

      var CandidatoDtoUpdate = new CandidatoDtoUpdate
      {
        Id = Guid.NewGuid(),
        NomeCompleto = name,
        Email = email
      };

      var result = await _controller.Put(CandidatoDtoUpdate);

      Assert.True(result is BadRequestObjectResult);
      Assert.False(_controller.ModelState.IsValid);

    }
  }
}
