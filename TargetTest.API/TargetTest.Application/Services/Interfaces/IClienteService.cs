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

        List<ClienteViewModel> ListaPelaRenda(ListaClientePorRendaInputModel inputModel);

        List<ClienteViewModel> ListaClientesPorPeriodo(ListaPeriodoClienteInputModel inputModel);


    }
}
