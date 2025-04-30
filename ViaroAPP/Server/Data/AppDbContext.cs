using Microsoft.EntityFrameworkCore;
using ViaroAPP.Server.Data.Entities;
using ViaroAPP.Server.Data;

namespace ViaroAPP.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Planilla> Planillas { get; set; }
        public DbSet<Calculo> Calculos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Asiento> Asientos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>()
                .HasIndex(e => e.Cedula)
                .IsUnique();

            modelBuilder.Entity<Empleado>()
                .HasMany(e => e.Planillas)
                .WithOne(p => p.Empleado)
                .HasForeignKey(p => p.CodigoEmpleado)
                .HasPrincipalKey(e => e.Codigo);

            modelBuilder.Entity<Cargo>()
                .HasMany(c => c.Empleados)
                .WithOne(e => e.Cargo)
                .HasForeignKey(e => e.IdCargo);

            modelBuilder.Entity<Calculo>()
                .HasMany(c => c.Planillas)
                .WithOne(p => p.Calculo)
                .HasForeignKey(p => p.IdCalculo);
        }
    }
}
