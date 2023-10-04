using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class InscripcionCurso_BE
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public int IdDictado { get; set; }

        public int IdCurso { get; set; }
        public int IdEstudiante { get; set; }
    }
}
