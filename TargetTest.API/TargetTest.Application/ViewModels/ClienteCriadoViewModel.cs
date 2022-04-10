using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TargetTest.Application.ViewModels
{
    public class ClienteCriadoViewModel
    {
        public ClienteCriadoViewModel(int id, string nomeCompleto, bool cadastrado, decimal renda)
        {
            Id = id;
            NomeCompleto = nomeCompleto;
            Cadastrado = cadastrado;
            OferecerPlanoVip = renda > 6000;
        }

        public int Id { get; private set; }
        public string NomeCompleto { get; private set; }
        public bool Cadastrado { get; private set; }
        public bool OferecerPlanoVip { get; private set; }
    }
}
