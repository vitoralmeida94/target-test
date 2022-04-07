using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TargetTest.Infrastructe.Persistence;

namespace TargetTest.API.Controllers
{
    [Route("api/planos")]
    public class PlanosController : ControllerBase
    {
        private readonly TargetDbContext _context;
        public PlanosController(TargetDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public  IActionResult Get()
        {
            var planos = _context.Planos.ToList();
            return Ok(planos);
        }
    }
}
