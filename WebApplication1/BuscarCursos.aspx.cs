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
            var location = HttpContext.Current.Request.Url.AbsolutePath;
            if (!IsPostBack)
            {
                FillSpecialities();
                FillCourses();
            }
        }

        private void FillSpecialities()
        {
            // Crear una lista de especialidades dummy
            List<string> specialities = new List<string>
    {
        "Especialidad 1",
        "Especialidad 2",
        "Especialidad 3",
        "Especialidad 4",
        "Especialidad 5"
    };

            // Enlazar la lista de especialidades al DropDownList
            searchSpeciality.DataSource = specialities;
            searchSpeciality.DataBind();
        }

        private void FillCourses()
        {
            // Crear una lista de cursos dummy
            DataTable courses = new DataTable();
            courses.Columns.Add("Nombre");
            courses.Columns.Add("Especialidad");

            // Agregar algunos cursos a la lista
            courses.Rows.Add("Curso 1","Especialidad 1");
            courses.Rows.Add("Curso 2","Especialidad 2");
            courses.Rows.Add("Curso 3","Especialidad 3");

            // Enlazar la lista de cursos al GridView
            coursesGrid.DataSource = courses;
            coursesGrid.DataBind();
        }

        protected void coursesGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Aquí puedes agregar el código para manejar la selección de un curso y redirigir al usuario a la página de detalle del curso
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cursos/DetalleCurso.aspx");
        }
    }
}