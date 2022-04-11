using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TargetTest.Application.ViewModels;

namespace TargetTest.Infrastructure.Persistence.ExternalServices.Interfaces
{
    public interface IIbgeService
    {
        Task<List<EstadoViewModel>> ListaEstados();

        Task<List<MunicipioViewModel>> ListaMunicipios(string UF);
    }
}
