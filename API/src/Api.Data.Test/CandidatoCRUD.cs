using System;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repositories;
using Api.Domain.Entities;
using Data.Test;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Api.Data.Test
{
  public class CandidatoCRUD : BaseTestData, IClassFixture<DbTest>
  {
    private ServiceProvider _serviceProvider;

    public CandidatoCRUD(DbTest dbTest)
    {
      _serviceProvider = dbTest.ServiceProvider;
    }

    [Fact(DisplayName = "CRUD de candidato")]
    [Trait("Candidato", "CRUD Candidato Entity Successful")]
    public async Task Is_CRUD_Candidato_Works_Correctly()
    {
      using (var context = _serviceProvider.GetService<MyContext>())
      {
        CandidatoRepository _repository = new CandidatoRepository(context);
        CandidatoEntity _entity = new CandidatoEntity
        {
          Email = Faker.Internet.Email(),
          NomeCompleto = Faker.Name.FullName(),
          Cpf = Faker.RandomNumber.Next(11, 11).ToString(),
          DataNascimento = DateTime.UtcNow,
          EnderecoId = Guid.NewGuid()
        };

        var _createdRecord = await _repository.InsertAsync(_entity);
        Assert.NotNull(_createdRecord);
        Assert.Equal(_entity.Email, _createdRecord.Email);
        Assert.Equal(_entity.NomeCompleto, _createdRecord.NomeCompleto);
        Assert.False(_createdRecord.Id == Guid.Empty);

        _entity.NomeCompleto = Faker.Name.First();
        var _updatedRecord = await _repository.UpdateAsync(_entity);
        Assert.NotNull(_updatedRecord);
        Assert.Equal(_entity.NomeCompleto, _updatedRecord.NomeCompleto);
        Assert.Equal(_entity.Email, _updatedRecord.Email);

        var _existsRecord = await _repository.ExistAsync(_updatedRecord.Id);
        Assert.True(_existsRecord);

        var _selectedRecord = await _repository.SelectAsync(_updatedRecord.Id);
        Assert.NotNull(_selectedRecord);
        Assert.Equal(_updatedRecord.NomeCompleto, _selectedRecord.NomeCompleto);
        Assert.Equal(_updatedRecord.Email, _selectedRecord.Email);

        var _allRecords = await _repository.SelectAsync();
        Assert.NotNull(_allRecords);
        Assert.True(_allRecords.Count() > 0);

        var _deletedRecord = await _repository.DeleteAsync(_selectedRecord.Id);
        Assert.True(_deletedRecord);
      }
    }
  }
}
