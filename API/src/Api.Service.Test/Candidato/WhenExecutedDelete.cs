using System;
using System.Threading.Tasks;
using Api.Domain.Dtos.Candidato;
using Api.Domain.Interfaces.Services.Candidato;
using Moq;
using Xunit;

namespace Api.Service.Test.Candidato
{
    public class WhenExecutedDelete : CandidatoTests
    {
        private ICandidatoService _service;
        private Mock<ICandidatoService> _serviceMock;

        [Fact(DisplayName = "Its possible execute DELETE method.")]
        public async Task Its_Possible_Execute_Delete_Method()
        {
            _serviceMock = new Mock<ICandidatoService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(true);
            _service = _serviceMock.Object;

            var result = await _service.Delete(IdCandidato);
            Assert.True(result);

            _serviceMock = new Mock<ICandidatoService>();
            _serviceMock.Setup(m => m.Delete(It.IsAny<Guid>())).ReturnsAsync(false);
            _service = _serviceMock.Object;

            result = await _service.Delete(Guid.NewGuid());
            Assert.False(result);
        }
    }
}
