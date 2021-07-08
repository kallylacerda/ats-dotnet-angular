using Api.Domain.Dtos.Candidato;
using Api.Domain.Dtos.Endereco;
using Api.Domain.Dtos.Municipio;
using Api.Domain.Dtos.Uf;
using Api.Domain.Entities;
using AutoMapper;

namespace Api.CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            #region Candidato
            CreateMap<CandidatoEntity, CandidatoDto>()
                .ReverseMap();
            CreateMap<CandidatoEntity, CandidatoDtoCompleto>()
                .ReverseMap();
            CreateMap<CandidatoEntity, CandidatoDtoCreateResult>()
                .ReverseMap();
            CreateMap<CandidatoEntity, CandidatoDtoUpdateResult>()
                .ReverseMap();
            #endregion

            #region Endereco
            CreateMap<EnderecoEntity, EnderecoDto>()
                .ReverseMap();
            #endregion

            #region Municipio
            CreateMap<MunicipioEntity, MunicipioDto>()
                .ReverseMap();
            CreateMap<MunicipioEntity, MunicipioDtoCompleto>()
                .ReverseMap();
            #endregion

            #region Uf
            CreateMap<UfEntity, UfDto>()
                .ReverseMap();
            #endregion
        }
    }
}
