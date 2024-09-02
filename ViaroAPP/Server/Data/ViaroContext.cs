using Microsoft.EntityFrameworkCore;
using ViaroAPP.Shared;

namespace ViaroAPP.Server.Data
{
    public class ViaroContext : DbContext
    {
        public ViaroContext(DbContextOptions<ViaroContext> options) : base(options) { }

        //Tablas
        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Grado> Grado { get; set; }
        public DbSet<AlumnoGrado> AlumnoGrado { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Se definen las llaves de las tablas
            modelBuilder.Entity<Alumno>().HasKey(a => a.id);
            modelBuilder.Entity<Profesor>().HasKey(p => p.id);
            modelBuilder.Entity<Grado>().HasKey(g => g.id);
            modelBuilder.Entity<AlumnoGrado>().HasKey(x => x.id);
        }
    }
}
