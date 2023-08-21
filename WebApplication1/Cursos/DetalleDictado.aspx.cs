using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Cursos
{
    public partial class DetalleDictado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadCourseDetails();
            }
        }

        private void LoadCourseDetails()
        {
            // Aquí cargarías los detalles del curso desde la base de datos
            // Por ahora, lo haré con datos de ejemplo
            lblCourseName.Text = "Curso Interactivo 1";
            lblCourseDescription.Text = "Descripción del curso interactivo 1.";
            lblCourseSpeciality.Text = "Especialidad 1";
            lblStartDate.Text = DateTime.Now.ToShortDateString();
            lblEndDate.Text = DateTime.Now.AddDays(30).ToShortDateString();
            lblAvailableSpots.Text = "30";
            lblTutors.Text = "Tutor 1, Tutor 2";
            lblSchedule.Text = "Lunes 10:00 - 12:00, Miércoles 14:00 - 16:00";
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            if (Request.UrlReferrer != null)
            {
                Response.Redirect(Request.UrlReferrer.ToString());
            }
            else
            {
                // Si no hay una URL de referencia, puedes redirigir a una página predeterminada
                Response.Redirect("~/Default.aspx");
            }
        }

        protected void btnInscribir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Cursos/ConfirmacionInscripcion");
        }

        protected void btnTutores_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ConsultarTutores.aspx");
        }
    }
}