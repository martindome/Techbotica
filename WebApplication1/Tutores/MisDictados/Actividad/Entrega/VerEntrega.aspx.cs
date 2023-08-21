using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.MisDictados.Actividad
{
    public partial class VerEntrega : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Aquí debes reemplazar estos valores por los reales
                string activityName = "Nombre de la Entrega";
                string pdfUrl = "Material.pdf";

                activityNameLabel.Text = activityName;

                // Incrustar el visualizador de PDF en HTML
                pdfViewer.Text = string.Format("<embed src=\"{0}\" type=\"application/pdf\" width=\"800px\" height=\"600px\" />", pdfUrl);
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
    }
}