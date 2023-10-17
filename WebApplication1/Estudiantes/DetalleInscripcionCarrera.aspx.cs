using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using BusinessEntity;
using BusinessEntity.Composite;

namespace WebApplication1.Estudiantes
{
    public partial class DetalleInscripcionCarrera : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Estudiante/Inscripciones")))
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }
            else
            {
                if (!IsPostBack)
                {
                    if (Session["id_inscripcion_carrera"] == null)
                    {
                        Response.Write("<script>alert('No se encuentra la inscripcion');window.location.href = '/Default.aspx';</script>");
                    }
                    int idInscripcion = int.Parse(Session["id_inscripcion_carrera"].ToString());
                    InscripcionCarrera_BE inscripcion = new Carrera_BLL().ListarInscripciones().SingleOrDefault(i => i.Id == idInscripcion);
                    Carrera_BE carrera = new Carrera_BLL().ListarCarreras().SingleOrDefault(c => c.Id == inscripcion.IdCarrera);
                    lblCarreraName.Text = carrera.Nombre;
                    lblCarreraDescription.Text = carrera.Descripcion;
                    CargarCarreras();

                }
            }
        }

        private void CargarCarreras()
        {
            //parse from session the id of the inscripcion
            int idInscripcion = int.Parse(Session["id_inscripcion_carrera"].ToString());
            // get the inscripcion from the db
            InscripcionCarrera_BE inscripcion = new Carrera_BLL().ListarInscripciones().SingleOrDefault(i => i.Id == idInscripcion);
            // get the careeer from the database using the inscripcion
            Carrera_BE carrera = new Carrera_BLL().ListarCarreras().SingleOrDefault(c => c.Id == inscripcion.IdCarrera);
            // fill the grid with the courses of the career
            coursesGrid.DataSource = carrera.Cursos;
            coursesGrid.DataBind();
        }

        protected void btnUnenroll_Click(object sender, EventArgs e)
        {
            // Obtener el ID de la inscripción de la carrera desde la sesión.
            int idInscripcion = int.Parse(Session["id_inscripcion_carrera"].ToString());

            // Aquí deberías tener una validación adicional para asegurarte de que el ID es válido y que la inscripción pertenece al usuario actual.

            // Crear una instancia de tu BLL.
            Carrera_BLL carreraBll = new Carrera_BLL();

            // Encontrar la inscripción específica.
            InscripcionCarrera_BE inscripcion = carreraBll.ListarInscripciones().SingleOrDefault(i => i.Id == idInscripcion);

            // Llamar al método para eliminar la inscripción.
            if (inscripcion != null)
            {
                carreraBll.EliminarInscripcion(inscripcion); // Asume que este método acepta el objeto de inscripción y realiza la lógica de eliminación.

                // Después de desinscribir, redirige al usuario a una página de confirmación o de vuelta a la lista de carreras.
                Response.Redirect("~/Estudiantes/GestionarInscripciones.aspx");
            }
            else
            {
                // Si algo va mal, manejar aquí. Por ejemplo, mostrar un mensaje de error.
            }
        }

    }
}