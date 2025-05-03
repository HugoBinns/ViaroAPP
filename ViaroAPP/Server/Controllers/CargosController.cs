using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ViaroAPP.Server.Data;
using ViaroAPP.Shared;

namespace ViaroAPP.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CargosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Cargos>>> GetEmpleados()
        {
            var listCargos = await _context.Cargos.ToListAsync();
            return Ok(listCargos);
        }
    }
}
