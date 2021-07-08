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
  public class Return_Created
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

      Mock<IUrlHelper> url = new Mock<IUrlHelper>();
      url.Setup(x => x.Link(It.IsAny<string>(), It.IsAny<object>())).Returns("http://localhost:5000/");

      _controller.Url = url.Object;

      var CandidatoDtoCreate = new CandidatoDtoCreate
      {
        NomeCompleto = name,
        Email = email
      };

      var result = await _controller.Post(CandidatoDtoCreate);

      Assert.True(result is CreatedResult);

      var resultValue = ((CreatedResult)result).Value as CandidatoDtoCreateResult;

      Assert.NotNull(resultValue);
      Assert.Equal(resultValue.NomeCompleto, CandidatoDtoCreate.NomeCompleto);
      Assert.Equal(resultValue.Email, CandidatoDtoCreate.Email);
    }
  }
}
