using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaroAPP.Shared
{
    //Entidad de la tabla alumno
    public class Alumno
    {
        public string id { get; set; }
        public string? nombre { get; set; }
        public string? apellidos { get; set; }
        public string? Genero { get; set; }
        public DateTime? fecha_nacimiento { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Alumno other)
            {
                return id == other.id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
    }
}

