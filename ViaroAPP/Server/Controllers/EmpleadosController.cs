using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViaroAPP.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System.Data.SqlClient;
using System.Data.Sql;
using Microsoft.Extensions.Hosting.Internal;
using ViaroAPP.Shared;
using System.Data;



namespace ViaroAPP.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmpleadosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Empleado>>> GetEmpleados()
        {
            var listEmpleados = await _context.Empleados.ToListAsync();
            return Ok(listEmpleados);
        }

        [HttpGet("{codigo}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(string codigo)
        {
            var e = await _context.Empleados.FindAsync(codigo);
            if (e == null)
                return NotFound();

            return new Empleado
            {
                codigo = e.Codigo,
                nombre = e.Nombre,
                segundoNombre = e.SegundoNombre,
                apellidoPaterno = e.ApellidoPaterno,
                apellidoMaterno = e.ApellidoMaterno,
                cedula = e.Cedula,
                salarioHora = e.SalarioHora,
                idCargo = e.IdCargo ?? 0
            };
        }

        [HttpPost]
        public async Task<ActionResult> CrearEmpleado(Empleado model)
        {
            if (await _context.Empleados.AnyAsync(e => e.Codigo == model.codigo))
                return Conflict("Ya existe un empleado con ese código.");

            var empleado = new Data.Entities.Empleado
            {
                Codigo = model.codigo,
                Nombre = model.nombre,
                SegundoNombre = model.segundoNombre,
                ApellidoPaterno = model.apellidoPaterno,
                ApellidoMaterno = model.apellidoMaterno,
                Cedula = model.cedula,
                SalarioHora = model.salarioHora,
                IdCargo = model.idCargo
            };

            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPut("{codigo}")]
        public async Task<ActionResult> ActualizarEmpleado(string codigo, Empleado model)
        {
            var empleado = await _context.Empleados.FindAsync(codigo);
            if (empleado == null)
                return NotFound();

            empleado.Nombre = model.nombre;
            empleado.SegundoNombre = model.segundoNombre;
            empleado.ApellidoPaterno = model.apellidoPaterno;
            empleado.ApellidoMaterno = model.apellidoMaterno;
            empleado.Cedula = model.cedula;
            empleado.SalarioHora = model.salarioHora;
            empleado.IdCargo = model.idCargo;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{codigo}")]
        public async Task<ActionResult> EliminarEmpleado(string codigo)
        {
            var empleado = await _context.Empleados.FindAsync(codigo);
            if (empleado == null)
                return NotFound();

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("Importar")]
        public async Task<ActionResult> ImportarEmpleados(List<Empleado> empleados)
        {
            var codigosExistentes = await _context.Empleados
                .Select(e => e.Codigo)
                .ToListAsync();

            var nuevosEmpleados = empleados
                .Where(e => !codigosExistentes.Contains(e.codigo))
                .Select(model => new Data.Entities.Empleado
                {
                    Codigo = model.codigo,
                    Nombre = model.nombre,
                    SegundoNombre = model.segundoNombre,
                    ApellidoPaterno = model.apellidoPaterno,
                    ApellidoMaterno = model.apellidoMaterno,
                    Cedula = model.cedula,
                    SalarioHora = model.salarioHora,
                    IdCargo = model.idCargo
                }).ToList();

            _context.Empleados.AddRange(nuevosEmpleados);
            await _context.SaveChangesAsync();

            return Ok($"{nuevosEmpleados.Count} empleados importados correctamente.");
        }


    }
}
