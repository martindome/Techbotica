using BusinessEntity;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Dictado_BLL
    {
        Dictado_DAL mapper = new Dictado_DAL();

        public List<Dictado_BE> ListarDictados()
        {
            return mapper.listar_dictados();
        }

        public List<Dictado_BE> ListarDictados(Curso_BE curso)
        {
            return mapper.listar_dictados_curso(curso.Id);
        }

        public List<Horario_BE> ListarHorariosDictado(Dictado_BE dictado)
        {
            return mapper.listar_horarios_dictado(dictado.Id);
        }

        public void NuevoDictado(Dictado_BE dictado)
        {
            mapper.nuevo_dictado(dictado);
        }

        public void ActualizarDictado(Dictado_BE dictado)
        {
            mapper.actualizar_dictado(dictado);
        }

        public void EliminarDictado(Dictado_BE dictado)
        {
            mapper.eliminar_dictado(dictado);
        }

        public void NuevoHorario(Horario_BE horario)
        {
            mapper.nuevo_horario(horario);
        }

        public void ActualizarHorario(Horario_BE horario)
        {
            mapper.actualizar_horario(horario); 
        }

        public void EliminarHorario(Horario_BE horario)
        {
            mapper.eliminar_horario(horario);
        }

        public List<Dictado_BE> ListarDictadosCurso(Curso_BE curso)
        {
            return mapper.listar_dictados_curso(curso.Id);
        }

        public List<Dictado_BE> ListarDictadosPorTutor(Usuario_BE tutor)
        {
            return mapper.listar_dictados_por_tutor(tutor.IdUsuario);
        }

        public void AgregarDictadoUsuario(Dictado_BE d, Usuario_BE u)
        {
            mapper.agregar_usuario_dictado(d.Id, u.IdUsuario);
        }

        public void EliminarDictadoUsuario(Dictado_BE d, Usuario_BE u)
        {
            mapper.eliminar_usuario_dictado(d.Id, u.IdUsuario);
        }

        public List<InscripcionCurso_BE> ListarInscripciones()
        {
            return mapper.listar_inscripcion();
        }

        public InscripcionCurso_BE NuevaInscripcion(int id_estudiante, int id_dictado, int id_curso)
        {
            return mapper.nueva_inscripcion(id_estudiante, id_dictado, id_curso);
        }

        public void EliminarInscripcion (InscripcionCurso_BE i)
        {
            mapper.eliminar_inscripcion(i.Id);
        }

        public List<InscripcionCurso_BE> ListarInscripcionesPorEstudiante(int idUsuario)
        {
            return mapper.ListarInscripcionesPorEstudiante(idUsuario);
        }

        //create the method ListarInscriocionesPorDictado
        public List<InscripcionCurso_BE> ListarInscripcionesPorDictado(int idDictado)
        {
            return mapper.ListarInscripcionesPorDictado(idDictado);
        }

        public List<Dictado_BE> ListarDictadosPorFechas(Curso_BE curso, DateTime fechaInicio, DateTime fechaFin)
        {
            List<Dictado_BE> todosDictados = ListarDictadosCurso(curso);

            List<Dictado_BE> dictadosFiltrados = todosDictados.Where(d =>
                d.FechaInicio >= fechaInicio &&
                d.FechaInicio <= fechaFin).ToList();

            return dictadosFiltrados;
        }
    }
}
