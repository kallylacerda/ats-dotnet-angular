using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Candidato;
using Api.Domain.Interfaces.Services.Candidato;
using Moq;
using Xunit;

namespace Api.Service.Test.Candidato
{
    public class WhenExecutedUpdate : CandidatoTests
    {
        private ICandidatoService _service;
        private Mock<ICandidatoService> _serviceMock;

        [Fact(DisplayName = "Its possible execute UPDATE method.")]
        public async Task Its_Possible_Execute_Update_Method()
        {
            _serviceMock = new Mock<ICandidatoService>();
            _serviceMock.Setup(m => m.Post(CandidatoDtoCreate)).ReturnsAsync(CandidatoDtoCreateResult);
            _service = _serviceMock.Object;

            var resultCreate = await _service.Post(CandidatoDtoCreate);
            Assert.NotNull(resultCreate);
            Assert.Equal(IdCandidato, resultCreate.Id);
            Assert.Equal(NomeCompletoCandidato, resultCreate.NomeCompleto);
            Assert.Equal(EmailCandidato, resultCreate.Email);
            Assert.Equal(CandidatoDtoCreateResult.CreatedAt, resultCreate.CreatedAt);

            _serviceMock = new Mock<ICandidatoService>();
            _serviceMock.Setup(m => m.Put(CandidatoDtoUpdate)).ReturnsAsync(CandidatoDtoUpdateResult);
            _service = _serviceMock.Object;

            var result = await _service.Put(CandidatoDtoUpdate);
            Assert.NotNull(result);
            Assert.Equal(IdCandidato, result.Id);
            Assert.Equal(NomeCompletoCandidatoUpdated, result.NomeCompleto);
            Assert.Equal(EmailCandidatoUpdated, result.Email);
            Assert.Equal(CandidatoDtoUpdateResult.UpdatedAt, result.UpdatedAt);
        }
    }
}
