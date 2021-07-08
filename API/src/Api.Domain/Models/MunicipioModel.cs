namespace Api.Domain.Models
{
    public class MunicipioModel
    {
        private ushort _id;
        public ushort Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _nome;
        public string Nome
        {
            get { return _nome; }
            set { _nome = value; }
        }

        private byte _ufId;
        public byte UfId
        {
            get { return _ufId; }
            set { _ufId = value; }
        }

    }
}
