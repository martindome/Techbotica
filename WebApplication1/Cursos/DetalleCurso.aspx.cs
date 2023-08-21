using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Cursos
{
    public partial class DetalleCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDictations();
            }
        }

        private void FillDictations()
        {
            // Crear una tabla de dictados dummy
            DataTable dictations = new DataTable();
            dictations.Columns.Add("Fecha de Inicio");
            dictations.Columns.Add("Fecha de Fin");
            dictations.Columns.Add("Horarios");
            dictations.Columns.Add("Tutores");

            // Agregar algunos dictados a la lista
            dictations.Rows.Add(DateTime.Now.AddDays(30).ToShortDateString(), DateTime.Now.AddDays(60).ToShortDateString(), "Lunes y Miércoles 10:00 - 12:00", "Tutor 1, Tutor 2");
            dictations.Rows.Add(DateTime.Now.AddDays(60).ToShortDateString(), DateTime.Now.AddDays(90).ToShortDateString(), "Martes y Jueves 15:00 - 17:00", "Tutor 3, Tutor 4");
            dictations.Rows.Add(DateTime.Now.AddDays(90).ToShortDateString(), DateTime.Now.AddDays(120).ToShortDateString(), "Lunes y Miércoles 20:00 - 22:00", "Tutor 5, Tutor 6");

            // Enlazar la lista de dictados al GridView
            lecturesGrid.DataSource = dictations;
            lecturesGrid.DataBind();
        }

        protected void lecturesGrid_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Enroll")
            {
                // Aquí puedes agregar el código para manejar la inscripción de un usuario en un dictado específico
            }
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cursos/DetalleDictado.aspx");
        }
    }
}