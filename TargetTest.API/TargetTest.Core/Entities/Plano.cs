using System;
using System.Collections.Generic;

#nullable disable

namespace TargetTest.Core.Entities
{
    public partial class Plano
    {
        public Plano(int id, string nome, string descricao, decimal valor)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Clientes = new HashSet<Cliente>();
        }

        public Plano(string nome, string descricao, decimal valor)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
            Clientes = new HashSet<Cliente>();
        }

        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
