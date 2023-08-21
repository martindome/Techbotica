using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores
{
    public partial class MisCursos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            courses.Columns.Add("Fecha de Inicio");
            courses.Columns.Add("Fecha de Fin");
            courses.Columns.Add("Especialidad");

            // Agregar algunos cursos a la lista
            courses.Rows.Add("Curso 1", DateTime.Now.ToShortDateString(), DateTime.Now.AddDays(30).ToShortDateString(), "Especialidad 1");
            courses.Rows.Add("Curso 2", DateTime.Now.ToShortDateString(), DateTime.Now.AddDays(30).ToShortDateString(), "Especialidad 2");
            courses.Rows.Add("Curso 3", DateTime.Now.ToShortDateString(), DateTime.Now.AddDays(30).ToShortDateString(), "Especialidad 3");

            // Enlazar la lista de cursos al GridView
            coursesGrid.DataSource = courses;
            coursesGrid.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            string courseName = (sender as Button).CommandArgument;
            Response.Redirect("~/Tutores/Curso/EditarCurso.aspx");
            // Lógica para editar el curso con el nombre dado
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string courseName = (sender as Button).CommandArgument;
            Response.Redirect("~/Tutores/GestionCursos.aspx");
            // Lógica para eliminar el curso con el nombre dado
        }

        protected void btnDictation_Click(object sender, EventArgs e)
        {
            string courseName = (sender as Button).CommandArgument;
            Response.Redirect("~/Tutores/GestionDictados.aspx");
            // Lógica para eliminar el curso con el nombre dado
        }
    }
}