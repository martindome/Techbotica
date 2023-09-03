using BusinessEntity.Composite;
using BusinessEntity;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.Curso
{
    public partial class NuevoCursoGenerico : System.Web.UI.Page
    {
        Curso_BLL mapper_curso = new Curso_BLL();
        Carrera_BLL mapper_carrera = new Carrera_BLL();
        List<Carrera_BE> carrerasAsignadas = new List<Carrera_BE>();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Tutores/GestionarCursos")))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }
            else
            {
                if (!IsPostBack)
                {
                    ViewState["carrerasasignadas"] = carrerasAsignadas;
                    CargarCarreras();
                    CargarEspecialidades();
                }
            }
        }

        protected void btnCreateCourse_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                carrerasAsignadas = (List<Carrera_BE>)ViewState["carrerasasignadas"];

                // Obtiene la especialidad seleccionada a partir de su ID
                int idEspecialidadSeleccionada = int.Parse(ddlEspecialidad.SelectedValue);
                Especialidad_BE especialidadSeleccionada = new Especialidad_BLL().ListarEspecialidades().FirstOrDefault(es => es.IdEspecialidad == idEspecialidadSeleccionada);

                Curso_BE nuevoCurso = new Curso_BE
                {
                    Nombre = CourseName.Text,
                    Descripcion = CourseDescription.Text,
                    Especialidad = especialidadSeleccionada
                };

                // Guardar el nuevo curso
                mapper_curso.NuevoCurso(nuevoCurso);

                // Asignar las carreras al curso
                foreach (Carrera_BE carrera in carrerasAsignadas)
                {
                    mapper_curso.AgregarCarreraCurso(nuevoCurso, carrera);
                }

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Curso creado con éxito');window.location.href = '/Tutores/GestionCursos.aspx'", true);
            }
        }

        protected void btnRemoveCareer_Click(object sender, EventArgs e)
        {
            carrerasAsignadas = (List<Carrera_BE>)ViewState["carrerasasignadas"];
            if (AssignedCareers.SelectedItem != null)
            {
                int carreraId = int.Parse(AssignedCareers.SelectedValue);
                Carrera_BE carrera = carrerasAsignadas.FirstOrDefault(c => c.Id == carreraId);

                if (carrera != null)
                {
                    carrerasAsignadas.Remove(carrera);
                    ViewState["carrerasasignadas"] = carrerasAsignadas;
                }

                CargarCarreras();
            }
        }

        protected void btnAssignCareer_Click(object sender, EventArgs e)
        {
            carrerasAsignadas = (List<Carrera_BE>)ViewState["carrerasasignadas"];
            if (AvailableCareers.SelectedItem != null)
            {
                int carreraId = int.Parse(AvailableCareers.SelectedValue);
                Carrera_BE carrera = mapper_carrera.ListarCarreras().FirstOrDefault(c => c.Id == carreraId);

                carrerasAsignadas.Add(carrera);
                ViewState["carrerasasignadas"] = carrerasAsignadas;
                CargarCarreras();
            }
        }

        private void CargarCarreras()
        {
            carrerasAsignadas = (List<Carrera_BE>)ViewState["carrerasasignadas"];
            List<Carrera_BE> todasLasCarreras = mapper_carrera.ListarCarreras();

            var carrerasDisponibles = todasLasCarreras.Where(c => !carrerasAsignadas.Any(ac => ac.Id == c.Id)).ToList();

            AvailableCareers.DataSource = carrerasDisponibles;
            AvailableCareers.DataTextField = "Nombre";
            AvailableCareers.DataValueField = "Id";
            AvailableCareers.DataBind();

            AssignedCareers.DataSource = carrerasAsignadas;
            AssignedCareers.DataTextField = "Nombre";
            AssignedCareers.DataValueField = "Id";
            AssignedCareers.DataBind();

            ViewState["carrerasasignadas"] = carrerasAsignadas;
        }

        private void CargarEspecialidades()
        {
            Especialidad_BLL especialidadBLL = new Especialidad_BLL();
            List<Especialidad_BE> listaEspecialidades = especialidadBLL.ListarEspecialidades();

            ddlEspecialidad.DataSource = listaEspecialidades;
            ddlEspecialidad.DataTextField = "Nombre";  // Asumiendo que tu clase Especialidad_BE tiene un atributo "NombreEspecialidad"
            ddlEspecialidad.DataValueField = "IdEspecialidad";                 // y un atributo "Id"
            ddlEspecialidad.DataBind();
        }


        protected void btnBackToCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/GestionCursos.aspx");
        }
    }
}