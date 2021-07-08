using System;
using System.Collections.Generic;
using System.Linq;
using Api.Domain.Dtos.Candidato;
using Api.Domain.Entities;
using Api.Domain.Models;
using Service.Test;
using Xunit;

namespace Api.Service.Test.AutoMapper
{
    public class CandidatoMapper : BaseTestService
    {
        [Fact(DisplayName = "Its possible mapper models")]
        public void Its_Possible_Mapper_Models()
        {
            var model = new CandidatoModel
            {
                Id = Guid.NewGuid(),
                NomeCompleto = Faker.Name.FullName(),
                Email = Faker.Internet.Email(),
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            var listEntity = new List<CandidatoEntity>();
            for (int i = 0; i < 5; i++)
            {
                var entity = new CandidatoEntity
                {
                    Id = Guid.NewGuid(),
                    NomeCompleto = Faker.Name.FullName(),
                    Email = Faker.Internet.Email(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };
                listEntity.Add(entity);
            }

            // Model => Entity
            var entityFromModel = Mapper.Map<CandidatoEntity>(model);
            Assert.Equal(entityFromModel.Id, model.Id);
            Assert.Equal(entityFromModel.NomeCompleto, model.NomeCompleto);
            Assert.Equal(entityFromModel.Email, model.Email);
            Assert.Equal(entityFromModel.CreatedAt, model.CreatedAt);
            Assert.Equal(entityFromModel.UpdatedAt, model.UpdatedAt);

            // Entity => Dto
            var dtoFromEntity = Mapper.Map<CandidatoDto>(entityFromModel);
            Assert.Equal(dtoFromEntity.Id, entityFromModel.Id);
            Assert.Equal(dtoFromEntity.NomeCompleto, entityFromModel.NomeCompleto);
            Assert.Equal(dtoFromEntity.Email, entityFromModel.Email);
            Assert.Equal(dtoFromEntity.CreatedAt, entityFromModel.CreatedAt);

            var listDtoFromListEntity = Mapper.Map<List<CandidatoDto>>(listEntity);
            Assert.True(listDtoFromListEntity.Count() == listEntity.Count());
            for (int i = 0; i < listDtoFromListEntity.Count(); i++)
            {
                Assert.Equal(listDtoFromListEntity[i].Id, listEntity[i].Id);
                Assert.Equal(listDtoFromListEntity[i].NomeCompleto, listEntity[i].NomeCompleto);
                Assert.Equal(listDtoFromListEntity[i].Email, listEntity[i].Email);
                Assert.Equal(listDtoFromListEntity[i].CreatedAt, listEntity[i].CreatedAt);
            }

            var dtoCreateResultFromEntity = Mapper.Map<CandidatoDtoCreateResult>(entityFromModel);
            Assert.Equal(dtoCreateResultFromEntity.Id, entityFromModel.Id);
            Assert.Equal(dtoCreateResultFromEntity.NomeCompleto, entityFromModel.NomeCompleto);
            Assert.Equal(dtoCreateResultFromEntity.Email, entityFromModel.Email);
            Assert.Equal(dtoCreateResultFromEntity.CreatedAt, entityFromModel.CreatedAt);

            var dtoUpdateResultFromEntity = Mapper.Map<CandidatoDtoUpdateResult>(entityFromModel);
            Assert.Equal(dtoUpdateResultFromEntity.Id, entityFromModel.Id);
            Assert.Equal(dtoUpdateResultFromEntity.NomeCompleto, entityFromModel.NomeCompleto);
            Assert.Equal(dtoUpdateResultFromEntity.Email, entityFromModel.Email);
            Assert.Equal(dtoUpdateResultFromEntity.UpdatedAt, entityFromModel.UpdatedAt);

            // Dto => Model
            var modelFromDto = Mapper.Map<CandidatoModel>(dtoFromEntity);
            Assert.Equal(modelFromDto.Id, dtoFromEntity.Id);
            Assert.Equal(modelFromDto.NomeCompleto, dtoFromEntity.NomeCompleto);
            Assert.Equal(modelFromDto.Email, dtoFromEntity.Email);
            Assert.Equal(modelFromDto.CreatedAt, dtoFromEntity.CreatedAt);

            var dtoCreateFromModel = Mapper.Map<CandidatoDtoCreate>(modelFromDto);
            Assert.Equal(dtoCreateFromModel.NomeCompleto, modelFromDto.NomeCompleto);
            Assert.Equal(dtoCreateFromModel.Email, modelFromDto.Email);

            var dtoUpdateFromModel = Mapper.Map<CandidatoDtoUpdate>(modelFromDto);
            Assert.Equal(dtoUpdateFromModel.Id, modelFromDto.Id);
            Assert.Equal(dtoUpdateFromModel.NomeCompleto, modelFromDto.NomeCompleto);
            Assert.Equal(dtoUpdateFromModel.Email, modelFromDto.Email);
        }
    }
}
