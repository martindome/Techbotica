using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Estudiantes.MisCursadas.Entregas
{
    public partial class VerEntrega : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Aquí debes reemplazar este valor por el real
                string pdfUrl = "~/Estudiantes/MisCursadas/Material.pdf";
                pdfUrl = Page.ResolveClientUrl(pdfUrl);

                // Incrustar el visualizador de PDF en HTML
                pdfViewer.Text = string.Format("<embed src=\"{0}\" type=\"application/pdf\" width=\"600px\" height=\"500px\" />", pdfUrl);
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            // Aquí debes reemplazar este valor por el real
            string pdfUrl = "~/Estudiantes/MisCursadas/Material.pdf";
            pdfUrl = Page.ResolveClientUrl(pdfUrl);
            // Lógica para descargar el archivo PDF
            Response.ContentType = "application/pdf";
            Response.AppendHeader("Content-Disposition", "attachment; filename=Entrega.pdf");
            Response.TransmitFile(Server.MapPath(pdfUrl));
            Response.End();
        }
    }
}