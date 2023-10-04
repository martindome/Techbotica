using BusinessEntity.Composite;
using BusinessEntity;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class BuscarCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["id_curso_inscribir"] = null;
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Tutores/GestionarCursos")))
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }
            else
            {
                if (!IsPostBack)
                {
                    CargarCursos();
                    Especialidad_BLL ebll = new Especialidad_BLL();
                    searchSpeciality.DataSource = ebll.ListarEspecialidades();
                    searchSpeciality.DataTextField = "Nombre";
                    searchSpeciality.DataValueField = "IdEspecialidad";
                    searchSpeciality.DataBind();
                }
            }
        }

        private void CargarCursos()
        {

            Usuario_BE usuario = (Usuario_BE)Session["usuario"];
            if (usuario != null)
            {
                int idUsuario = usuario.IdUsuario;

                // Obtener todas las inscripciones del usuario
                Curso_BLL cursoBll = new Curso_BLL();
                Dictado_BLL dictadoBll = new Dictado_BLL();
                List<InscripcionCurso_BE> inscripciones = dictadoBll.ListarInscripcionesPorEstudiante(idUsuario);
                List<int> cursosInscritosIds = inscripciones.Select(i => i.IdCurso).ToList();


                string terminoBusquedaNombre = searchName.Text.Trim().ToLower();
                string terminoBusquedaCarrera = searchCareer.Text.Trim().ToLower();
                int? idEspecialidadSeleccionada = null;
                if (!string.IsNullOrEmpty(searchSpeciality.SelectedValue))
                {
                    idEspecialidadSeleccionada = int.Parse(searchSpeciality.SelectedValue);
                }

                List<Curso_BE> todosLosCursos = cursoBll.ListarCursos();

                var cursosFiltrados = todosLosCursos;

                // Filtrar por Nombre
                if (!string.IsNullOrEmpty(terminoBusquedaNombre))
                {
                    cursosFiltrados = cursosFiltrados.Where(c => c.Nombre.ToLower().Contains(terminoBusquedaNombre)).ToList();
                }

                if (!string.IsNullOrEmpty(terminoBusquedaCarrera))
                {
                    Carrera_BLL carreraBLL = new Carrera_BLL();

                    // Obtener las carreras que coinciden con el término de búsqueda
                    var carrerasCoincidentes = carreraBLL.ListarCarreras()
                        .Where(car => car.Nombre.ToLower().Contains(terminoBusquedaCarrera))
                        .ToList();

                    // Por cada carrera, obtener los cursos relacionados
                    List<Curso_BE> cursosPorCarrera = new List<Curso_BE>();
                    foreach (var carrera in carrerasCoincidentes)
                    {
                        var cursosDeLaCarrera = cursoBll.ListarCursosCarrera(carrera);
                        cursosPorCarrera.AddRange(cursosDeLaCarrera);
                    }

                    // Finalmente, filtrar la lista cursosFiltrados para quedarte sólo con aquellos cursos que están en la lista cursosPorCarrera
                    cursosFiltrados = cursosFiltrados.Where(c => cursosPorCarrera.Select(curso => curso.Id).Contains(c.Id)).ToList();
                }

                // Filtrar por Especialidad
                if (idEspecialidadSeleccionada.HasValue)
                {
                    cursosFiltrados = cursosFiltrados.Where(c => c.Especialidad.IdEspecialidad == idEspecialidadSeleccionada.Value).ToList();
                }

                cursosFiltrados = cursosFiltrados.Where(c => !cursosInscritosIds.Contains(c.Id)).ToList();

                coursesGrid.DataSource = cursosFiltrados;
                coursesGrid.DataBind();
            }



        }

        protected void btnDictation_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Recuperando el índice de la fila desde el CommandArgument del botón
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Obteniendo el valor de Id del curso usando DataKeys
            int idCurso = Convert.ToInt32(coursesGrid.DataKeys[rowIndex].Value);

            // Almacena el ID del curso en una variable de sesión para usarlo en la página de edición
            Session["id_curso_inscribir"] = idCurso;

            Response.Redirect("~/Cursos/DetalleCurso.aspx");
            // Lógica para eliminar el curso con el nombre dado
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            CargarCursos();
        }
    }
}