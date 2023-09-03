using BusinessEntity;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Curso_BLL
    {
        Curso_DAL mapper = new Curso_DAL();

        public List<Curso_BE> ListarCursos()
        {
            return mapper.listar_cursos();
        }

        public void NuevoCurso(Curso_BE curso)
        {
            mapper.nuevo_curso(curso);
        }

        public void ActualizarCurso(Curso_BE curso)
        {
            mapper.actualizar_curso(curso);
        }

        public void EliminarCurso(Curso_BE curso)
        {
            mapper.eliminar_curso(curso);
        }

        public List<Curso_BE> ListarCursosCarrera(Carrera_BE carrera)
        {
            return mapper.listar_cursos_carrera(carrera.Id);
        }
    }
}
