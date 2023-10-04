using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class InscripcionCarrera_BE
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdCarrera { get; set; }
        public int IdEstudiante { get; set; }
    }
}
