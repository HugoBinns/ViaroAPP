using System.ComponentModel.DataAnnotations;

namespace ViaroAPP.Server.Data.Entities
{
    public class Cargo
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        public string NombreCargo { get; set; }
    }
}
