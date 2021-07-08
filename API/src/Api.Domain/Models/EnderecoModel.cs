namespace Api.Domain.Models
{
    public class EnderecoModel : BaseModel
    {
        private string _cep;
        public string Cep
        {
            get { return _cep; }
            set { _cep = value; }
        }

        private string _logradouro;
        public string Logradouro
        {
            get { return _logradouro; }
            set { _logradouro = value; }
        }

        private string _numero;
        public string Numero
        {
            get { return _numero; }
            set
            {
                _numero = string.IsNullOrEmpty(value) ? "S/N" : value;
            }
        }

        private ushort _municipioId;
        public ushort MunicipioId
        {
            get { return _municipioId; }
            set { _municipioId = value; }
        }

    }
}
