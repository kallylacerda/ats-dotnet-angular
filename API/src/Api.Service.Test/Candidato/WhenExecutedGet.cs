using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Candidato;
using Api.Domain.Interfaces.Services.Candidato;
using Moq;
using Xunit;

namespace Api.Service.Test.Candidato
{
    public class WhenExecutedGet : CandidatoTests
    {
        private ICandidatoService _service;
        private Mock<ICandidatoService> _serviceMock;

        [Fact(DisplayName = "Its possible execute GET method.")]
        public async Task Its_Possible_Execute_Get_Method()
        {
            _serviceMock = new Mock<ICandidatoService>();
            _serviceMock.Setup(m => m.Get(IdCandidato)).ReturnsAsync(CandidatoDtoCompleto);
            _service = _serviceMock.Object;

            var result = await _service.Get(IdCandidato);
            Assert.NotNull(result);
            Assert.Equal(IdCandidato, result.Id);
            Assert.Equal(NomeCompletoCandidato, result.NomeCompleto);

            _serviceMock = new Mock<ICandidatoService>();
            _serviceMock.Setup(m => m.Get(It.IsAny<Guid>())).Returns(Task.FromResult((CandidatoDtoCompleto)null));
            _service = _serviceMock.Object;

            var _record = await _service.Get(IdCandidato);
            Assert.Null(_record);
        }
    }
}
