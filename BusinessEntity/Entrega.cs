using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class Entrega
    {
        public Usuario_BE Estudiante { get; set; }
        public Dictado_BE Dictado { get; set; }
        public DateTime Fecha { get; set; }
        public byte[] Archivo { get; set; }

    }
}
