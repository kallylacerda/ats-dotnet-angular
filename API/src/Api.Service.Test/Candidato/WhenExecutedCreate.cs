using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Candidato;
using Api.Domain.Interfaces.Services.Candidato;
using Moq;
using Xunit;

namespace Api.Service.Test.Candidato
{
    public class WhenExecutedCreate : CandidatoTests
    {
        private ICandidatoService _service;
        private Mock<ICandidatoService> _serviceMock;

        [Fact(DisplayName = "Its possible execute CREATE method.")]
        public async Task Its_Possible_Execute_Create_Method()
        {
            _serviceMock = new Mock<ICandidatoService>();
            _serviceMock.Setup(m => m.Post(CandidatoDtoCreate)).ReturnsAsync(CandidatoDtoCreateResult);
            _service = _serviceMock.Object;

            var result = await _service.Post(CandidatoDtoCreate);
            Assert.NotNull(result);
            Assert.Equal(IdCandidato, result.Id);
            Assert.Equal(NomeCompletoCandidato, result.NomeCompleto);
            Assert.Equal(EmailCandidato, result.Email);
            Assert.Equal(CandidatoDtoCreateResult.CreatedAt, result.CreatedAt);
        }
    }
}
