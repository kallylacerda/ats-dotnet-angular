using System;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Candidato;
using Api.Domain.Interfaces.Services.Candidato;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Candidato.WhenRequestCreate
{
  public class Return_BadRequest
  {
    private CandidatosController _controller;

    [Fact(DisplayName = "Its possible perform Created.")]
    public async Task Its_Possible_Call_Create_Controller()
    {
      var serviceMock = new Mock<ICandidatoService>();
      var name = Faker.Name.FullName();
      var email = Faker.Internet.Email();

      serviceMock.Setup(m => m.Post(It.IsAny<CandidatoDtoCreate>())).ReturnsAsync(
          new CandidatoDtoCreateResult
          {
            Id = Guid.NewGuid(),
            NomeCompleto = name,
            Email = email,
            CreatedAt = DateTime.UtcNow
          }
      );

      _controller = new CandidatosController(serviceMock.Object);
      _controller.ModelState.TryAddModelError("Name", "É um campo obrigatório");

      Mock<IUrlHelper> url = new Mock<IUrlHelper>();
      url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000/");

      _controller.Url = url.Object;

      var CandidatoDtoCreate = new CandidatoDtoCreate
      {
        NomeCompleto = name,
        Email = email
      };

      var result = await _controller.Post(CandidatoDtoCreate);

      Assert.True(result is BadRequestObjectResult);
      Assert.False(_controller.ModelState.IsValid);
    }
  }
}
