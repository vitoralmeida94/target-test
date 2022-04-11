using System;
using System.Collections.Generic;

#nullable disable

namespace TargetTest.Core.Entities
{
    public partial class Cliente
    {
        public Cliente(string nomeCompleto, DateTime dataNascimento, string cpf, decimal renda, int? planoId)
        {
            NomeCompleto = nomeCompleto;
            DataNascimento = dataNascimento;
            Cpf = cpf;
            Renda = renda;
            PlanoId = planoId;
            DataCriacao = DateTime.Now;
        }

        public int Id { get; private set; }
        public string NomeCompleto { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Cpf { get; private set; }
        public decimal Renda { get; private set; }
        public int? PlanoId { get; private set; }
        public DateTime DataCriacao { get; private set; }

        public virtual Plano Plano { get; set; }
        public virtual Endereco Endereco { get; set; }

        public void AplicaPlano(int planoId)
        {
            PlanoId = planoId;
        }
    }
}
