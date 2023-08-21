using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Estudiantes.Cursadas
{
    public partial class VerActividad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Aquí debes reemplazar estos valores por los reales
                string activityName = "Nombre de la Actividad";
                string pdfUrl = "Material.pdf";

                activityNameLabel.Text = activityName;

                // Incrustar el visualizador de PDF en HTML
                pdfViewer.Text = string.Format("<embed src=\"{0}\" type=\"application/pdf\" width=\"800px\" height=\"600px\" />", pdfUrl);

                // Añadir valores de prueba a la lista de entregas
                deliveriesGrid.DataSource = new List<object>
        {
            new { FechaEntrega = DateTime.Now.ToString("dd/MM/yyyy") },
            new { FechaEntrega = DateTime.Now.AddDays(-1).ToString("dd/MM/yyyy") }
        };
                deliveriesGrid.DataBind();
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            // Aquí debes reemplazar este valor por el real
            string pdfUrl = "Material.pdf";

            // Lógica para descargar el archivo PDF
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Actividad.pdf");
            Response.TransmitFile(Server.MapPath(pdfUrl));
            Response.End();
        }

        protected void btnNewDelivery_Click(object sender, EventArgs e)
        {
            // Aquí debes reemplazar este valor por el real
            string activityId = "ID_de_la_Actividad";

            // Redirigir al usuario a la página de nueva entrega
            //Response.Redirect(string.Format("NewDelivery.aspx?activityId={0}", activityId));
            Response.Redirect("~/Estudiantes/MisCursadas/Entregas/NuevaEntrega.aspx");
        }

        protected void btnViewDelivery_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Estudiantes/MisCursadas/Entregas/VerEntrega.aspx");
        }

        protected void btnDeleteDelivery_Click(object sender, EventArgs e)
        {

        }
    }
}