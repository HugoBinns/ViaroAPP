﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViaroAPP.Shared
{
    //Entidad de la tabla profesor
    public class Profesor
    {
        public string id { get; set; }
        public string? nombre { get; set; }
        public string? apellidos { get; set; }
        public string? genero { get; set; }
    }
}
