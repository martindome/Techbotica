using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.MisDictados
{
    public partial class Dictado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Crear tablas con columnas para Materiales y Actividades.
                DataTable materiales = new DataTable();
                DataTable actividades = new DataTable();

                materiales.Columns.Add("Nombre");
                actividades.Columns.Add("Nombre");

                // Agregar algunas filas con datos dummy.
                materiales.Rows.Add("Material 1");
                materiales.Rows.Add("Material 2");
                materiales.Rows.Add("Material 3");

                actividades.Rows.Add("Actividad 1");
                actividades.Rows.Add("Actividad 2");
                actividades.Rows.Add("Actividad 3");

                // Enlazar las tablas a los GridView.
                materialsGrid.DataSource = materiales;
                materialsGrid.DataBind();

                activitiesGrid.DataSource = actividades;
                activitiesGrid.DataBind();
            }
        }

        protected void btnViewMaterial_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/MisDictados/Material/VerMaterial.aspx");
        }

        protected void btnEditMaterial_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/MisDictados/Material/EditarMaterial.aspx");
        }

        protected void btnDeleteMaterial_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/MisDictados/Dictado.aspx");
        }

        protected void btnViewActivity_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/MisDictados/Actividad/VerActividad.aspx");
        }

        protected void btnEditActivity_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/MisDictados/Actividad/EditarActividad.aspx");
        }

        protected void btnDeleteActivity_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/MisDictados/Dictado.aspx");
        }

        protected void btnViewDeliveries_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/MisDictados/Actividad/Entrega/Entregas.aspx");
        }

        protected void btnNewMaterial_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/MisDictados/Material/NuevoMaterial.aspx");
        }

        protected void btnNewActivity_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/MisDictados/Actividad/NuevaActividad.aspx");
        }
    }
}