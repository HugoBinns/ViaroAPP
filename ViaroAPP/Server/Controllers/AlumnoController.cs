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
    public class AlumnoController : ControllerBase
    {
        private readonly ViaroContext _context;

        public AlumnoController(ViaroContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Alumno>>> GetAlumno()
        {
            var listAlumno = await _context.Alumno.ToListAsync();
            return Ok(listAlumno);
        }

        //Función de insert
        [HttpPut("insert_alumno")]
        public IActionResult InsertAlumno(Alumno alumno)
        {
            try
            {
                using (var connection = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("sp_InsertAlumno", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", alumno.id);
                        cmd.Parameters.AddWithValue("@nombre", alumno.nombre);
                        cmd.Parameters.AddWithValue("@apellidos", alumno.apellidos);
                        cmd.Parameters.AddWithValue("@genero", alumno.Genero);
                        cmd.Parameters.AddWithValue("@fecha_nacimiento", alumno.fecha_nacimiento);
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
        [HttpPut("update_alumno")]
        public IActionResult UpdateAlumno(Alumno alumno)
        {
            try
            {
                using (var connection = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("sp_UpdateAlumno", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", alumno.id);
                        cmd.Parameters.AddWithValue("@nombre", alumno.nombre);
                        cmd.Parameters.AddWithValue("@apellidos", alumno.apellidos);
                        cmd.Parameters.AddWithValue("@genero", alumno.Genero);

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
        [HttpPut("delete_alumno")]
        public IActionResult DeleteAlumno(Alumno alumno)
        {
            try
            {
                using (var connection = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    connection.Open();
                    using (var cmd = new SqlCommand("sp_DeleteAlumno", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@id", alumno.id);
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

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Alumno>>> GetAlumnoById(string id)
        {
            var alumnos = new List<Alumno>();

            using (SqlConnection conn = new SqlConnection(_context.Database.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_SelectAlumno", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", id);

                    conn.Open();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var alumno = new Alumno
                            {
                                id = reader["id"].ToString(),
                                nombre = reader["nombre"]?.ToString(),
                                apellidos = reader["apellidos"]?.ToString(),
                                Genero = reader["Genero"]?.ToString(),
                                fecha_nacimiento = reader["fecha_nacimiento"] as DateTime?
                            };
                            alumnos.Add(alumno);
                        }
                    }
                }
            }

            return Ok(alumnos);
        }
    }
}
