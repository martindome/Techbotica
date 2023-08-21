using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.Dictado
{
    public partial class NuevoDictador3erPaso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Rellena el GridView de cursos con datos dummy
                

                // Rellena el GridView de tutores con datos dummy
                TutorsGrid.DataSource = new List<object>
        {
            new { TutorName = "Tutor 1", TutorSpecialty = "Especialidad 1" },
            new { TutorName = "Tutor 2", TutorSpecialty = "Especialidad 2" },
            // Agrega más tutores aquí
        };
                TutorsGrid.DataBind();
                AssignedTutorsGrid.DataSource = new List<object>
        {
            new { TutorName = "Tutor 1", TutorSpecialty = "Especialidad 1" },
            new { TutorName = "Tutor 2", TutorSpecialty = "Especialidad 2" },
            // Agrega más tutores aquí
        };
                AssignedTutorsGrid.DataBind();
            }
        }

        protected void ConfirmButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/GestionDictados.aspx");
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/GestionDictados.aspx");
        }
    }
}