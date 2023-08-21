using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.MisDictados.Actividad
{
    public partial class VerActividad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Aquí debes reemplazar estos valores por los reales
                string materialName = "Nombre del Material";
                string pdfUrl = "Material.pdf";

                materialNameLabel.Text = materialName;

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
            Response.AppendHeader("Content-Disposition", "attachment; filename=Material.pdf");
            Response.TransmitFile(Server.MapPath(pdfUrl));
            Response.End();
        }
    }
}