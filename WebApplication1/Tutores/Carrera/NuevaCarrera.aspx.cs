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
    public partial class NuevaCarrera : System.Web.UI.Page
    {
        Carrera_BLL mapper_carrera = new Carrera_BLL();
        Curso_BLL mapper_curso = new Curso_BLL();
        Empresa_BE empresabe = new Empresa_BE();
        List<Curso_BE> cursosAsignados = new List<Curso_BE>();
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
                    ViewState["carrerabe"] = empresabe;
                    ViewState["cursosasignados"] = cursosAsignados;
                    CargarCursos();
                }
            }
            
            
        }

        protected void btnCreateCareer_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                cursosAsignados = (List<Curso_BE>)ViewState["cursosasignados"];
                Carrera_BE nuevaCarrera = new Carrera_BE
                {
                    Nombre = CareerName.Text,
                    Descripcion = CareerDescription.Text
                };

                // Guardar la nueva carrera
                mapper_carrera.NuevaCarrera(nuevaCarrera);

                // Ahora que la carrera se ha creado, asignamos los cursos
                foreach (Curso_BE curso in cursosAsignados)
                {
                    mapper_carrera.AgregarCursoCarrera(nuevaCarrera, curso);
                }

                // Redirigir al usuario o mostrar un mensaje de éxito
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Carrera creada con éxito');window.location.href = '/Tutores/GestionCarreras.aspx'", true);
            }
        }
            

        protected void btnRemoveCourse_Click(object sender, EventArgs e)
        {
            cursosAsignados = (List<Curso_BE>)ViewState["cursosasignados"];
            if (AssignedCourses.SelectedItem != null)
            {
                int cursoId = int.Parse(AssignedCourses.SelectedValue);
                Curso_BE curso = cursosAsignados.FirstOrDefault(c => c.Id == cursoId);

                if (curso != null)
                {
                    cursosAsignados.Remove(curso);
                    ViewState["cursosasignados"] = cursosAsignados;
                }

                CargarCursos();
            }
        }

        protected void btnAssignCourse_Click(object sender, EventArgs e)
        {
            cursosAsignados = (List<Curso_BE>)ViewState["cursosasignados"];
            if (AvailableCourses.SelectedItem != null)
            {
                int cursoId = int.Parse(AvailableCourses.SelectedValue);
                Curso_BE curso = mapper_curso.ListarCursos().FirstOrDefault(c => c.Id == cursoId);

                cursosAsignados.Add(curso);
                ViewState["cursosasignados"] = cursosAsignados;
                CargarCursos();
            }
        }

        private void CargarCursos()
        {
            cursosAsignados = (List<Curso_BE>)ViewState["cursosasignados"];
            List<Curso_BE> todosLosCursos = mapper_curso.ListarCursos();

            var cursosDisponibles = todosLosCursos.Where(c => !cursosAsignados.Any(ac => ac.Id == c.Id)).ToList();

            AvailableCourses.DataSource = cursosDisponibles;
            AvailableCourses.DataTextField = "Nombre";
            AvailableCourses.DataValueField = "Id";
            AvailableCourses.DataBind();

            AssignedCourses.DataSource = cursosAsignados;
            AssignedCourses.DataTextField = "Nombre";
            AssignedCourses.DataValueField = "Id";
            AssignedCourses.DataBind();

            ViewState["cursosasignados"] = cursosAsignados;
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/GestionCarreras.aspx");
        }
    }
}