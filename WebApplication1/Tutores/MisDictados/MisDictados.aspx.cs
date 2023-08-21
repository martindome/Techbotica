using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.MisDictados
{
    public partial class MisDictaods : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Crear la tabla con columnas.
                DataTable dictados = new DataTable();
                dictados.Columns.Add("Curso");
                dictados.Columns.Add("FechaInicio");
                dictados.Columns.Add("FechaFin");
                dictados.Columns.Add("Horario");

                // Agregar algunas filas con datos dummy.
                dictados.Rows.Add("Matemáticas", "01/07/2023", "30/11/2023", "Lunes 18:00 - 21:00");
                dictados.Rows.Add("Matematicas", "01/07/2023", "30/11/2023", "Martes 18:00 - 21:00");
                dictados.Rows.Add("Robotica", "01/07/2023", "30/11/2023", "Lunes 18:00 - 21:00");

                // Enlazar el GridView con la tabla de datos.
                dictationsGrid.DataSource = dictados;
                dictationsGrid.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            // Implementar la lógica de búsqueda aquí.
        }

        protected void btnSelect_Click(object sender, EventArgs e)
        {
            // Implementar la lógica de selección aquí.
            // El sender es el botón que fue clickeado.
            // Para encontrar la fila del GridView asociada al botón, puedes usar:
            // GridViewRow row = (GridViewRow)(((Button)sender).NamingContainer);
        }

        protected void btnSelect_Click1(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/MisDictados/Dictado.aspx");
        }
    }
}