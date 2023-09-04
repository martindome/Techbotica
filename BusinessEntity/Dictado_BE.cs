using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class Dictado_BE
    {
        public int Id { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string Enlace { get; set; }
        public Curso_BE Curso { get; set; }
        public string TipoDictado { get; set; }
        public List<Horario_BE> Horarios { get; set; }
        public int Cupo;
        public List<Usuario_BE> Tutores { get; set; }
    }
}
