using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ViaroAPP.Shared;

namespace ViaroAPP.Server.Data.Entities
{
    public class Empleado
    {
        [Key]
        [StringLength(4)]
        public string Codigo { get; set; }

        [Required, StringLength(20)]
        public string Nombre { get; set; }

        [StringLength(20)]
        public string SegundoNombre { get; set; }

        [StringLength(20)]
        public string ApellidoPaterno { get; set; }

        [StringLength(20)]
        public string ApellidoMaterno { get; set; }

        [Required, StringLength(15)]
        public string Cedula { get; set; }

        public float? SalarioHora { get; set; }

        public int? IdCargo { get; set; }

        [ForeignKey("IdCargo")]
        public Cargo Cargo { get; set; }

        public ICollection<Planilla> Planillas { get; set; }
    }
}
