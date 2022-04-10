using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTest.Application.ViewModels
{
    public class ClienteViewModel
    {
        public ClienteViewModel(int id, string nomeCompleto, string cpf, decimal renda)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            CPF = cpf;
            Renda = renda;
        }

        public int Id { get; private set; }
        public string NomeCompleto { get; private set; }
        public string CPF { get; private set; }
        public decimal Renda { get; private set; }
    }
}
