using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Application.Controllers;
using Api.Domain.Dtos.Candidato;
using Api.Domain.Interfaces.Services.Candidato;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Api.Application.Test.Candidato.WhenRequestGetAll
{
  public class Return_BadRequest
  {
    private CandidatosController _controller;

    [Fact(DisplayName = "Its possible perform Getted.")]
    public async Task Its_Possible_Call_Get_Controller()
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
      _controller.ModelState.TryAddModelError("Id", "Formato inválido");

      var result = await _controller.GetAll();

      Assert.True(result is BadRequestObjectResult);
    }

  }
}
