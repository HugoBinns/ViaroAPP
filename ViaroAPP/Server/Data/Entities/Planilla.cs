using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ViaroAPP.Server.Data.Entities
{
    public class Planilla
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required, StringLength(4)]
        public string CodigoEmpleado { get; set; }

        [ForeignKey("CodigoEmpleado")]
        public Empleado Empleado { get; set; }

        public int? IdCalculo { get; set; }

        [ForeignKey("IdCalculo")]
        public Calculo Calculo { get; set; }

        public DateTime? FechaPlanilla { get; set; }

        public int? HorasTrabajadas { get; set; }

        public float? Sobretiempo { get; set; }

        public float? PrimaProducción { get; set; }

        public float? TotalIngresos { get; set; }

        public float? DescuentoAcreedores { get; set; }

        public float? SeguroSocial { get; set; }

        public float? SeguroEducativo { get; set; }

        public float? Sinticop { get; set; }

        public float? DescuentoSeguro { get; set; }

        public float? ImpuestoSobreRenta { get; set; }

        public float? TotalDescuentos { get; set; }

        public float? Total { get; set; }
    }
}
