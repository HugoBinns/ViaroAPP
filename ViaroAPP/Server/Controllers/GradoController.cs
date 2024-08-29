using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViaroAPP.Server.Data;
using ViaroAPP.Shared;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;

namespace ViaroAPP.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradoController : ControllerBase
    {
        private readonly ViaroContext _context;

        public GradoController(ViaroContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Grado>>> GetGrado()
        {
            var listGrado = await _context.Grado.ToListAsync();
            return Ok(listGrado);
        }


        //Función de insert
        [HttpPut("insert_Grado")]
        public IActionResult InsertGrado(Grado Grado)
        {
            try
            {
                using (var connection = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("sp_InsertGrado", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", Grado.id);
                        cmd.Parameters.AddWithValue("@nombre", Grado.nombre);
                        cmd.Parameters.AddWithValue("@apellidos", Grado.profesorid);
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
        [HttpPut("update_Grado")]
        public IActionResult UpdateGrado(Grado Grado)
        {
            try
            {
                using (var connection = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("sp_UpdateGrado", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", Grado.id);
                        cmd.Parameters.AddWithValue("@nombre", Grado.nombre);
                        cmd.Parameters.AddWithValue("@apellidos", Grado.profesorid);
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
        [HttpDelete("delete_Grado")]
        public IActionResult DeleteGrado(Grado Grado)
        {
            try
            {
                using (var connection = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("sp_DeleteGrado", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", Grado.id);
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
