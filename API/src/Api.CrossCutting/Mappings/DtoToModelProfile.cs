using Api.Domain.Dtos.Candidato;
using Api.Domain.Dtos.Endereco;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using Api.Domain.Models;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            #region Candidato
            CreateMap<CandidatoDto, CandidatoModel>()
                .ReverseMap();
            CreateMap<CandidatoDtoCompleto, CandidatoModel>()
                .ReverseMap();
            CreateMap<CandidatoDtoCreate, CandidatoModel>()
                .ReverseMap();
            CreateMap<CandidatoDtoUpdate, CandidatoModel>()
                .ReverseMap();
            #endregion

            #region Endereco
            CreateMap<EnderecoDto, EnderecoModel>()
                .ReverseMap();
            CreateMap<EnderecoDtoCreate, EnderecoModel>()
                .ReverseMap();
            CreateMap<EnderecoDtoUpdate, EnderecoModel>()
                .ReverseMap();
            #endregion

            #region Municipio
            CreateMap<MunicipioDto, MunicipioModel>()
                .ReverseMap();
            CreateMap<MunicipioDtoCompleto, MunicipioModel>()
                .ReverseMap();
            #endregion

            #region Uf
            CreateMap<UfDto, UfModel>()
                .ReverseMap();
            #endregion
        }
    }
}
