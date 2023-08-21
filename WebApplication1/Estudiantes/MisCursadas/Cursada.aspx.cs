using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Estudiantes.Cursadas
{
    public partial class Cursada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Llena los datos de prueba en el GridView de materiales
                DataTable dtMaterials = new DataTable();
                dtMaterials.Columns.AddRange(new DataColumn[1] { new DataColumn("Nombre", typeof(string)) });
                dtMaterials.Rows.Add("Material 1");
                dtMaterials.Rows.Add("Material 2");
                materialsGrid.DataSource = dtMaterials;
                materialsGrid.DataBind();

                // Llena los datos de prueba en el GridView de actividades
                DataTable dtActivities = new DataTable();
                dtActivities.Columns.AddRange(new DataColumn[1] { new DataColumn("Nombre", typeof(string)) });
                dtActivities.Rows.Add("Actividad 1");
                dtActivities.Rows.Add("Actividad 2");
                activitiesGrid.DataSource = dtActivities;
                activitiesGrid.DataBind();

                // Llena la información adicional
                startDate.Text = "01/01/2023";
                endDate.Text = "01/06/2023";
                schedule.Text = "8:00 AM - 10:00 AM";
                tutors.Text = "Tutor 1, Tutor 2";
            }
        }

        protected void btnViewMaterial_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Estudiantes/MisCursadas/VerMaterial.aspx");
        }

        protected void btnViewActivity_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Estudiantes/MisCursadas/VerActividad.aspx");
        }
    }
}