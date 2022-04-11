using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TargetTest.Application.ViewModels;
using TargetTest.Infrastructe.Persistence;

namespace TargetTest.API.Controllers
{
    [Route("api/plano")]
    public class PlanoController : ControllerBase
    {
        private readonly TargetDbContext _context;
        public PlanoController(TargetDbContext context)
        {
            _context = context;
        }


        [HttpGet("vip")]
        public IActionResult Get()
        {
            var planoVIP = _context.Planos.FirstOrDefault(x => x.Nome == "VIP");

            return Ok(new PlanoViewModel(planoVIP.Nome,planoVIP.Descricao,planoVIP.Valor));
        }
    }
}
