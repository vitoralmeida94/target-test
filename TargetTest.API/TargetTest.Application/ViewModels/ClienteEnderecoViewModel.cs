using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTest.Application.ViewModels
{
    public class ClienteEnderecoViewModel
    {
        public ClienteEnderecoViewModel(int clienteId, string nomeCompleto, string logradouro, string bairro, string cep, string cidade, string uf, string complemento)
        {
            ClienteId = clienteId;
            NomeCompleto = nomeCompleto;
            Logradouro = logradouro;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Uf = uf;
            Complemento = complemento;
        }

        public int ClienteId { get; private set; }
        public string NomeCompleto { get; private set; }
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Uf { get; private set; }
        public string Complemento { get; private set; }
    }
}
