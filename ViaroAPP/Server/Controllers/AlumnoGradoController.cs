using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViaroAPP.Server.Data;
using ViaroAPP.Shared;
using Microsoft.EntityFrameworkCore;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;

namespace ViaroAPP.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoGradoController : ControllerBase
    {
        private readonly ViaroContext _context;
        private readonly IConfiguration _settings;

        public AlumnoGradoController(ViaroContext context, IConfiguration settings)
        {
            _context = context;
            _settings = settings;
        }

        //Función de select
        [HttpGet]
        public async Task<ActionResult<List<AlumnoGrado>>> GetAlumnoGrado()
        {
            var listAlumnoGrado = await _context.AlumnoGrado.ToListAsync();
            return Ok(listAlumnoGrado);
        }
        //Función de insert
        [HttpPut("insert_AlumnoGrado")]
        public IActionResult InsertAlumnoGrado(AlumnoGrado AlumnoGrado)
        {
            try
            {
                using (var connection = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("sp_InsertAlumnoGrado", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", AlumnoGrado.id);
                        cmd.Parameters.AddWithValue("@alumnoid", AlumnoGrado.alumnoid);
                        cmd.Parameters.AddWithValue("@gradoid", AlumnoGrado.gradoid);
                        cmd.Parameters.AddWithValue("@seccion", AlumnoGrado.seccion);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return NoContent();
        }
        //Función de update
        [HttpPut("update_AlumnoGrado")]
        public IActionResult UpdateAlumnoGrado(AlumnoGrado AlumnoGrado)
        {
            try
            {
                using (var connection = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("sp_UpdateAlumnoGrado", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", AlumnoGrado.id);
                        cmd.Parameters.AddWithValue("@alumnoid", AlumnoGrado.alumnoid);
                        cmd.Parameters.AddWithValue("@gradoid", AlumnoGrado.gradoid);
                        cmd.Parameters.AddWithValue("@seccion", AlumnoGrado.seccion);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return NoContent();
        }
        //Función de delete
        [HttpDelete("delete_AlumnoGrado")]
        public IActionResult DeleteAlumnoGrado(AlumnoGrado AlumnoGrado)
        {
            try
            {
                using (var connection = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("sp_DeleteAlumnoGrado", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", AlumnoGrado.id);
                        cmd.ExecuteNonQuery();
                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return NoContent();
        }

    }
}
