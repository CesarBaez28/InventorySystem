﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Comun
{
    public class DetallesSalida
    {
        public int codigo_salida { get; set; }
        public int codigo_servicio { get; set; }
        public int codigo_cliente { get; set; }
        public int codigo_usuario { get; set; }
        public float precio { get; set; }
        public int cantidad { get; set; }
    }
}
