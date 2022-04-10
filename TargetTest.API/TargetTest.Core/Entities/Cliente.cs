using System;
using System.Collections.Generic;

#nullable disable

namespace TargetTest.Core.Entities
{
    public partial class Cliente
    {
        public int Id { get; private set; }
        public string NomeCompleto { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Cpf { get; private set; }
        public decimal Renda { get; private set; }
        public int PlanoId { get; private set; }

        public virtual Plano Plano { get; private set; }
        public virtual Endereco Endereco { get; private set; }
    }
}
