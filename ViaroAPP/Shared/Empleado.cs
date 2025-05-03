using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaroAPP.Shared
{
    //Entidad de la tabla alumno
    public class Empleado
    {
        public string codigo { get; set; }
        public string? nombre { get; set; }
        public string? segundoNombre { get; set; }
        public string? apellidoPaterno { get; set; }
        public string? apellidoMaterno { get; set; }
        public string? cedula { get ; set; }
        public float? salarioHora { get; set; }
        public int idCargo { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj is Empleado other)
            {
                return codigo == other.codigo;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return codigo.GetHashCode();
        }
    }
}

