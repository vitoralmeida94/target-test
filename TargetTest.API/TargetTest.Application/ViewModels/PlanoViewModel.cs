using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTest.Application.ViewModels
{
    public class PlanoViewModel
    {
        public PlanoViewModel(string nome, string descricao, decimal valor)
        {
            Nome = nome;
            Descricao = descricao;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Valor { get; private set; }
    }
}
