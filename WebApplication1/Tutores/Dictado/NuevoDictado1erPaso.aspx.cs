using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.Dictado
{
    public partial class NuevoDictadoInteractivo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Rellena el GridView de cursos con datos dummy
                CoursesGrid.DataSource = new List<object>
        {
            new { CourseName = "Curso 1", Specialty = "Especialidad 1" },
            new { CourseName = "Curso 2", Specialty = "Especialidad 2" },
            // Agrega más cursos aquí
        };
            }
        }

        protected void NextPageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/Dictado/NuevoDictado2doPaso.aspx");
        }
    }
}