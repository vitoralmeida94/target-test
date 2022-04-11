using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TargetTest.Application.ViewModels;
using TargetTest.Infrastructure.Persistence.ExternalServices.Interfaces;

namespace TargetTest.Application.ExternalServices.Implemetations
{
    public class IbgeService : IIbgeService
    {
        private string _urlEstados = "https://servicodados.ibge.gov.br/api/v1/localidades/estados/";
        public async Task<List<EstadoViewModel>> ListaEstados()
        {
            var listaEstados = new List<EstadoViewModel>();
            using (var httpClient = new HttpClient())
            {
                var responseMessage = await httpClient.GetAsync(_urlEstados);

                var json = await responseMessage.Content.ReadAsStringAsync();

                listaEstados = JsonConvert.DeserializeObject<List<EstadoViewModel>>(json);
            }

            return listaEstados;
        }

        public async Task<List<MunicipioViewModel>> ListaMunicipios(string UF)
        {
            var urlMunicipios = $"https://servicodados.ibge.gov.br/api/v1/localidades/estados/{UF}/municipios";
            var listaMunicipios = new List<MunicipioViewModel>();
            using (var httpClient = new HttpClient())
            {
                var responseMessage = await httpClient.GetAsync(urlMunicipios);

                var json = await responseMessage.Content.ReadAsStringAsync();

                listaMunicipios = JsonConvert.DeserializeObject<List<MunicipioViewModel>>(json);
            }

            return listaMunicipios;
        }
    }
}
