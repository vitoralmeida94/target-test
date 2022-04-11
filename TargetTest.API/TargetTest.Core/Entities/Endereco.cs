using System;
using System.Collections.Generic;

#nullable disable

namespace TargetTest.Core.Entities
{
    public partial class Endereco
    {
        public Endereco(int clientId, string logradouro, string bairro, string cep, string cidade, string uf, string complemento)
        {
            ClientId = clientId;
            Logradouro = logradouro;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Uf = uf;
            Complemento = complemento;
        }

        public int ClientId { get; private set; }
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Cep { get; private set; }
        public string Cidade { get; private set; }
        public string Uf { get; private set; }
        public string Complemento { get; private set; }

        public virtual Cliente Client { get; set; }

        public void AtualizaEndereco(string logradouro, string bairro, string cep, string cidade, string uf, string complemento)
        {
            Logradouro = logradouro;
            Bairro= bairro;
            Cep= cep;
            Cidade= cidade;
            Uf = uf;
            Complemento = complemento;
        }
    }
}
