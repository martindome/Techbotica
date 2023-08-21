using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.MisDictados.Actividad
{
    public partial class Entregas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillDeliveries();
            }
        }

        private void FillDeliveries()
        {
            // Crear una lista de entregas ficticia
            DataTable deliveries = new DataTable();
            deliveries.Columns.Add("Fecha");
            deliveries.Columns.Add("NombreAlumno");

            // Agregar algunas entregas a la lista
            deliveries.Rows.Add("2023-08-20", "Juan Pérez");
            deliveries.Rows.Add("2023-08-19", "María García");

            // Enlazar la lista de entregas al GridView
            deliveriesGrid.DataSource = deliveries;
            deliveriesGrid.DataBind();
        }

        protected void btnViewDelivery_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/MisDictados/Actividad/Entrega/VerEntrega.aspx");
        }
    }
}