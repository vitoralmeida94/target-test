using System;
using System.Collections.Generic;

#nullable disable

namespace TargetTest.Core.Entities
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Cpf { get; set; }
        public decimal Renda { get; set; }
        public int PlanoId { get; set; }

        public virtual Plano Plano { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
