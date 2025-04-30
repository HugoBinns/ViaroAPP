using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaroAPP.Shared
{
    //Entidad de la tabla grado
    public class Planilla
    {
        public string id { get; set; }
        public string? nombre { get; set; }
        public string profesorid { get; set; }

        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Planilla other = (Planilla)obj;
            return (id == other.id);
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
    }
}
