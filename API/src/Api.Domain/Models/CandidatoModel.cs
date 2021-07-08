using System;

namespace Api.Domain.Models
{
  public class CandidatoModel : BaseModel
  {
    private string _nomeCompleto;
    public string NomeCompleto
    {
      get { return _nomeCompleto; }
      set { _nomeCompleto = value; }
    }

    private string _cpf;
    public string Cpf
    {
      get { return _cpf; }
      set { _cpf = value; }
    }


    private string _email;
    public string Email
    {
      get { return _email; }
      set { _email = value; }
    }

    private string _telefone;
    public string Telefone
    {
      get { return _telefone; }
      set { _telefone = value; }
    }

    private string _descricao;
    public string Descricao
    {
      get { return _descricao; }
      set { _descricao = value; }
    }

    private DateTime _dataNascimento;
    public DateTime DataNascimento
    {
      get { return _dataNascimento; }
      set { _dataNascimento = value; }
    }

    private Guid _enderedoId;
    public Guid EnderecoId
    {
      get { return _enderedoId; }
      set { _enderedoId = value; }
    }

    private EnderecoModel _endereco;
    public EnderecoModel Endereco
    {
      get { return _endereco; }
      set { _endereco = value; }
    }

  }
}
