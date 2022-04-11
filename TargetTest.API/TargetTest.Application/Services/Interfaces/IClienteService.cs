using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTest.Application.InputModels;
using TargetTest.Application.ViewModels;

namespace TargetTest.Application.Services.Interfaces
{
    public interface IClienteService
    {
        ClienteCriadoViewModel Inserir(CriacaoClienteInputModel inputModel);

        List<ClienteViewModel> ListaPelaRenda(decimal renda);

        List<ClienteViewModel> ListaClientesPorPeriodo(ListaPeriodoClienteInputModel inputModel);

        void AplicarVIP(int clienteId);

        bool AtualizaEnderecoCliente(int id,AtualizaEnderecoInputModel inputModel);

        ClienteEnderecoViewModel ListaEnderecoCliente(int clienteId);
    }
}
