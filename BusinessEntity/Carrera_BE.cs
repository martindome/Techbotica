using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    [Serializable]
    public class Carrera_BE
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public List<Curso_BE> Cursos { get; set; }
        
        public Carrera_BE()
        {
            Cursos = new List<Curso_BE>();
        }
    }
}
