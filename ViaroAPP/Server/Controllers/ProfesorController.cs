using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViaroAPP.Server.Data;
using ViaroAPP.Shared;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;

namespace ViaroAPP.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private readonly ViaroContext _context;

        public ProfesorController(ViaroContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Profesor>>> GetProfesor()
        {
            var listProfesor = await _context.Profesor.ToListAsync();
            return Ok(listProfesor);
        }

        //Función de insert
        [HttpPut("insert_Profesor")]
        public IActionResult InsertProfesor(Profesor Profesor)
        {
            try
            {
                using (var connection = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("sp_InsertProfesor", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", Profesor.id);
                        cmd.Parameters.AddWithValue("@nombre", Profesor.nombre);
                        cmd.Parameters.AddWithValue("@apellidos", Profesor.apellidos);
                        cmd.Parameters.AddWithValue("@genero", Profesor.genero);
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
        [HttpPut("update_Profesor")]
        public IActionResult UpdateProfesor(Profesor Profesor)
        {
            try
            {
                using (var connection = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("sp_UpdateProfesor", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", Profesor.id);
                        cmd.Parameters.AddWithValue("@nombre", Profesor.nombre);
                        cmd.Parameters.AddWithValue("@apellidos", Profesor.apellidos);
                        cmd.Parameters.AddWithValue("@genero", Profesor.genero);

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
        [HttpDelete("delete_Profesor")]
        public IActionResult DeleteProfesor(Profesor Profesor)
        {
            try
            {
                using (var connection = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("sp_DeleteProfesor", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", Profesor.id);
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
