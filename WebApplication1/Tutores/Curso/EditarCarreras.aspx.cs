using BusinessEntity;
using BusinessEntity.Composite;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.Curso
{
    public partial class EditarCarreras : System.Web.UI.Page
    {
        Curso_BLL cursoBll = new Curso_BLL();
        Carrera_BLL Carrera_BLL = new Carrera_BLL();
        Curso_BE cursoBE;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Tutores/GestionarCursos")))
            {
                // Mostrar error si no hay curso a editar.
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Curso inexistente');window.location.href = '/Default.aspx'", true);
            }
            else
            {
                if (Session["id_curso_editar"] == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Curso inexistente');window.location.href = '/Default.aspx'", true);
                }
                if (!IsPostBack)
                {

                    cursoBE = (Curso_BE)cursoBll.ListarCursos().FirstOrDefault(item => item.Id == int.Parse(Session["id_curso_editar"].ToString()));
                    ViewState["cursoBE"] = cursoBE;
                    CargarCarreras();
                }
            }
            // Mismo manejo de sesión que en la otra página...
            
        }

        private void CargarCarreras()
        {
            List<Carrera_BE> todasLasCarreras = Carrera_BLL.ListarCarreras();
            List<Carrera_BE> carrerasAsignadas = cursoBll.ListarCarrerasPorCurso(cursoBE);
            //List<Carrera_BE> carrerasAsignadas = Carrera_BLL.ListarCarrerasPorCurso(cursoBE);  // Necesitarías este método en Carrera_BLL

            var carrerasDisponibles = todasLasCarreras.Where(c => !carrerasAsignadas.Any(ac => ac.Id == c.Id)).ToList();

            AvailableCareers.DataSource = carrerasDisponibles;
            AvailableCareers.DataTextField = "Nombre";
            AvailableCareers.DataValueField = "Id";
            AvailableCareers.DataBind();

            AssignedCareers.DataSource = carrerasAsignadas;
            AssignedCareers.DataTextField = "Nombre";
            AssignedCareers.DataValueField = "Id";
            AssignedCareers.DataBind();
        }

        protected void btnAssignCareer_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado alguna carrera en el ListBox de carreras disponibles
            if (AvailableCareers.SelectedItem != null)
            {
                // Obtener el ID de la carrera seleccionada
                int carreraId = int.Parse(AvailableCareers.SelectedValue);

                // Obtener el objeto carrera a partir del ID
                Carrera_BE carrera = Carrera_BLL.ListarCarreras().FirstOrDefault(c => c.Id == carreraId);

                // Obtener el objeto curso desde ViewState
                cursoBE = (Curso_BE)ViewState["cursoBE"];

                // Asignar la carrera al curso
                new Curso_BLL().AgregarCarreraCurso(cursoBE, carrera);

                // Recargar los ListBox para reflejar los cambios
                CargarCarreras();
            }
        }

        protected void btnRemoveCareer_Click(object sender, EventArgs e)
        {
            // Verificar si se ha seleccionado alguna carrera en el ListBox de carreras asignadas
            if (AssignedCareers.SelectedItem != null)
            {
                // Obtener el ID de la carrera seleccionada
                int carreraId = int.Parse(AssignedCareers.SelectedValue);

                // Obtener el objeto carrera a partir del ID
                Carrera_BE carrera = Carrera_BLL.ListarCarreras().FirstOrDefault(c => c.Id == carreraId);

                // Obtener el objeto curso desde ViewState
                cursoBE = (Curso_BE)ViewState["cursoBE"];

                // Desasignar la carrera del curso
                new Curso_BLL().EliminarCarreraCurso(cursoBE, carrera);

                // Recargar los ListBox para reflejar los cambios
                CargarCarreras();
            }
        }

        protected void btnBackToCourses_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/Curso/EditarCurso.aspx"); 
        }

        
    }
}