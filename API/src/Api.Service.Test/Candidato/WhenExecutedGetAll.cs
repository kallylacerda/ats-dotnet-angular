using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Dtos.Candidato;
using Api.Domain.Interfaces.Services.Candidato;
using Moq;
using Xunit;

namespace Api.Service.Test.Candidato
{
    public class WhenExecutedGetAll : CandidatoTests
    {
        private ICandidatoService _service;
        private Mock<ICandidatoService> _serviceMock;

        [Fact(DisplayName = "Its possible execute GET All method.")]
        public async Task Its_Possible_Execute_Get_All_Method()
        {
            _serviceMock = new Mock<ICandidatoService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(listCandidatoDto);
            _service = _serviceMock.Object;

            var result = await _service.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count() == 10);

            var _listResult = new List<CandidatoDto>();
            _serviceMock = new Mock<ICandidatoService>();
            _serviceMock.Setup(m => m.GetAll()).ReturnsAsync(_listResult.AsEnumerable);
            _service = _serviceMock.Object;

            var _resultEmpty = await _service.GetAll();
            Assert.Empty(_resultEmpty);
            Assert.True(_resultEmpty.Count() == 0);
        }
    }
}
