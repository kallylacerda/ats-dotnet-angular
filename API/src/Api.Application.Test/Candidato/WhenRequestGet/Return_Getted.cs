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
  public class Return_Getted
  {
    private CandidatosController _controller;

    [Fact(DisplayName = "Its possible perform Getted.")]
    public async Task Its_Possible_Call_Get_Controller()
    {
      var serviceMock = new Mock<ICandidatoService>();
      var cpf = Faker.RandomNumber.Next(11, 11).ToString();
      var telefone = Faker.RandomNumber.Next(9, 9).ToString();
      var nomeCompleto = Faker.Name.FullName();
      var email = Faker.Internet.Email();

      serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).ReturnsAsync(
          new CandidatoDtoCompleto
          {
            Id = Guid.NewGuid(),
            Cpf = cpf,
            NomeCompleto = nomeCompleto,
            Email = email,
            Telefone = email,
            CreatedAt = DateTime.UtcNow
          }
      );

      _controller = new CandidatosController(serviceMock.Object);

      var result = await _controller.Get(Guid.NewGuid());

      Assert.True(result is OkObjectResult);

      var resultValue = ((OkObjectResult)result).Value as CandidatoDtoCompleto;

      Assert.NotNull(resultValue);
      Assert.Equal(nomeCompleto, resultValue.NomeCompleto);
      Assert.Equal(email, resultValue.Email);
    }

  }
}
