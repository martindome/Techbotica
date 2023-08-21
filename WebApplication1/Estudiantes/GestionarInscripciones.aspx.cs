using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Estudiantes
{
    public partial class GestionarInscripciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Simulamos datos para las Carreras
                var dummyCareers = new List<dynamic>
        {
            new { Nombre = "Carrera 1" },
            new { Nombre = "Carrera 2" },
            new { Nombre = "Carrera 3" }
        };
                careersGrid.DataSource = dummyCareers;
                careersGrid.DataBind();

                // Simulamos datos para los Cursos
                var dummyCourses = new List<dynamic>
        {
            new { Nombre = "Curso 1", FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(10), Especialidad = "Especialidad 1", Estado = "Activo" },
            new { Nombre = "Curso 2", FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(10), Especialidad = "Especialidad 2", Estado = "Activo" },
            new {  Nombre = "Curso 3", FechaInicio = DateTime.Now, FechaFin = DateTime.Now.AddDays(10), Especialidad = "Especialidad 3", Estado = "Activo" }
        };
                coursesGrid.DataSource = dummyCourses;
                coursesGrid.DataBind();
            }
        }

        protected void btnSelectCurso_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Estudiantes/DetalleInscripcionCurso.aspx");
        }

        protected void btnSelectCarrera_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Estudiantes/DetalleInscripcionCarrera.aspx");
        }
    }
}