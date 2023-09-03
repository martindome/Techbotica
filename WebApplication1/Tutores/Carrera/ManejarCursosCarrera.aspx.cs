using BusinessEntity;
using BusinessEntity.Composite;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.Carrera
{
    public partial class ManejarCursosCarrera : System.Web.UI.Page
    {
        Curso_BLL cursoBll = new Curso_BLL();
        Carrera_BLL Carrera_BLL = new Carrera_BLL();
        Carrera_BE carrerabe;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Tutores/GestionarCarreras")))
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }
            else
            {
                if (!IsPostBack)
                {
                    if (Session["id_carrera_editar"] == null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Carrera inexistente');window.location.href = '/Default.aspx'", true);
                    }
                    carrerabe = (Carrera_BE)Carrera_BLL.ListarCarreras().FirstOrDefault(item => item.Id == int.Parse(Session["id_carrera_editar"].ToString()));
                    ViewState["carrerabe"] = carrerabe;
                    CargarCursos();
                }
            }
            
        }

        protected void btnAssignCourse_Click(object sender, EventArgs e)
        {
            if (AvailableCourses.SelectedItem != null)
            {
                int cursoId = int.Parse(AvailableCourses.SelectedValue);
                Curso_BE curso = cursoBll.ListarCursos().FirstOrDefault(c => c.Id == cursoId);

                // Asignar curso a la carrera
                carrerabe = (Carrera_BE)ViewState["carrerabe"];
                Carrera_BLL.AgregarCursoCarrera(carrerabe, curso);

                // Recargar los ListBox
                CargarCursos();
            }
        }

        protected void btnRemoveCourse_Click(object sender, EventArgs e)
        {
            if (AssignedCourses.SelectedItem != null)
            {
                int cursoId = int.Parse(AssignedCourses.SelectedValue);
                Curso_BE curso = cursoBll.ListarCursos().FirstOrDefault(c => c.Id == cursoId);

                // Desasignar curso de la carrera
                carrerabe = (Carrera_BE)ViewState["carrerabe"];
                Carrera_BLL.EliminarCursoCarrera(carrerabe, curso);

                // Recargar los ListBox
                CargarCursos();
            }
        }

        private void CargarCursos()
        {
            List<Curso_BE> todosLosCursos = cursoBll.ListarCursos();
            List<Curso_BE> cursosAsignados = cursoBll.ListarCursosCarrera(carrerabe);

            // Filtrar los cursos disponibles
            var cursosDisponibles = todosLosCursos.Where(c => !cursosAsignados.Any(ac => ac.Id == c.Id)).ToList();

            AvailableCourses.DataSource = cursosDisponibles;
            AvailableCourses.DataTextField = "Nombre";
            AvailableCourses.DataValueField = "Id";
            AvailableCourses.DataBind();

            AssignedCourses.DataSource = cursosAsignados;
            AssignedCourses.DataTextField = "Nombre";
            AssignedCourses.DataValueField = "Id";
            AssignedCourses.DataBind();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/Carrera/EditarCarrera.aspx");
        }
    }
}