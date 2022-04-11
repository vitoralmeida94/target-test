using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TargetTest.Infrastructure.Persistence.ExternalServices.Interfaces;

namespace TargetTest.API.Controllers
{
    [Route("api/ibge")]
    public class IbgeController : ControllerBase
    {
        private readonly IIbgeService _ibgeService;
        public IbgeController(IIbgeService ibgeService)
        {
            _ibgeService = ibgeService;
        }

        [HttpGet("estados")]
        public async Task<IActionResult> GetEstados()
        {
            try
            {
                var listaEstados = await _ibgeService.ListaEstados();

                return Ok(listaEstados);
            }
            catch 
            {
                return StatusCode(500, "Ocorreu um erro ao consultar os estados no IBGE.");
            }
        }

        [HttpGet("municipios/{uf}")]
        public async Task<IActionResult> GetEstados([FromRoute] string uf)
        {
            try
            {
                if (string.IsNullOrEmpty(uf))
                    return BadRequest("Preencha a UF para realizar a busca.");

                var listaMunicipios = await _ibgeService.ListaMunicipios(uf);

                return Ok(listaMunicipios);
            }
            catch
            {
                return StatusCode(500, "Ocorreu um erro ao consultar os municipios no IBGE.");
            }
        }
    }
}
