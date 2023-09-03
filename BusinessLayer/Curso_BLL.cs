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

        public void AgregarCarreraCurso(Curso_BE cursoBE, Carrera_BE carrera)
        {
            new Carrera_BLL().AgregarCursoCarrera(carrera, cursoBE);
        }

        public void EliminarCarreraCurso(Curso_BE cursoBE, Carrera_BE carrera)
        {
            new Carrera_BLL().EliminarCursoCarrera(carrera, cursoBE);
        }

        public List<Carrera_BE> ListarCarrerasPorCurso(Curso_BE cursoBE)
        {
            List<Carrera_BE> carreras = new Carrera_BLL().ListarCarreras();

            // Filtrar las carreras que contienen el curso específico
            var carrerasConCurso = carreras.Where(carrera => carrera.Cursos.Any(curso => curso.Id == cursoBE.Id)).ToList();

            return carrerasConCurso;
        }
    }
}
