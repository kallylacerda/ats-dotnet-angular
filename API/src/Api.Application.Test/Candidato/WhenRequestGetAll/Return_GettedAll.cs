using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Candidato;
using Api.Domain.Interfaces.Services.Candidato;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Candidato.WhenRequestGetAll
{
  public class Return_GettedAll
  {
    private CandidatosController _controller;

    [Fact(DisplayName = "Its possible perform All Getted.")]
    public async Task Its_Possible_Call_GetAll_Controller()
    {
      var serviceMock = new Mock<ICandidatoService>();

      serviceMock.Setup(m => m.GetAll()).ReturnsAsync(
          new List<CandidatoDto>
          {
                    new CandidatoDto
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreatedAt = DateTime.UtcNow
                    },
                    new CandidatoDto
                    {
                        Id = Guid.NewGuid(),
                        NomeCompleto = Faker.Name.FullName(),
                        Email = Faker.Internet.Email(),
                        CreatedAt = DateTime.UtcNow
                    }
          }
      );

      _controller = new CandidatosController(serviceMock.Object);

      var result = await _controller.GetAll();

      Assert.True(result is OkObjectResult);

      var resultValue = ((OkObjectResult)result).Value as IEnumerable<CandidatoDto>;

      Assert.NotNull(resultValue);
      Assert.True(resultValue.Count() == 2);
    }

  }
}
