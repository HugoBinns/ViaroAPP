using System.ComponentModel.DataAnnotations;

namespace ViaroAPP.Server.Data.Entities
{
    public class Asiento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string CodigoAsiento { get; set; }

        [StringLength(255)]
        public string Descripcion { get; set; }

        public float? Debito { get; set; }

        public float? Credito { get; set; }
    }
}
