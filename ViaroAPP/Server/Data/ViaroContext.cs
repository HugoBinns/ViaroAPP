using Microsoft.EntityFrameworkCore;
using ViaroAPP.Shared;

namespace ViaroAPP.Server.Data
{
    public class ViaroContext : DbContext
    {
        public ViaroContext(DbContextOptions<ViaroContext> options) : base(options) { }

        //Tablas
        public DbSet<Empleado> Alumno { get; set; }
        public DbSet<Planilla> Grado { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Se definen las llaves de las tablas
            modelBuilder.Entity<Empleado>().HasKey(a => a.id);
            modelBuilder.Entity<Planilla>().HasKey(g => g.id);
        }
    }
}
