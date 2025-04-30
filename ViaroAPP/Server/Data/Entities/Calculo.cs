using System.ComponentModel.DataAnnotations;

namespace ViaroAPP.Server.Data.Entities
{
    public class Calculo
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        public string NombreCalculo { get; set; }
    }
}
