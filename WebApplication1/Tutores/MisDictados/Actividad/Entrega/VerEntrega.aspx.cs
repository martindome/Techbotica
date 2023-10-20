using BusinessEntity;
using BusinessEntity.Composite;
using BusinessLayer;
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
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Tutores/MisDictados")))
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }
            else
            {
                if (Session["entrega_ver"] == null || Session["id_dictado_ver"] == null)
                {
                    Response.Write("<script>alert('No se encuentra el material');window.location.href = '/Default.aspx';</script>");
                }
                if (!IsPostBack)
                {
                    int idCurso = int.Parse(Session["id_dictado_ver"].ToString());
                    //obtener dictado
                    Dictado_BLL dictadobll = new Dictado_BLL();
                    Dictado_BE dictado = dictadobll.ListarDictados().FirstOrDefault(item => item.Id == idCurso);
                    int actividadId = int.Parse(Session["actividad_view"].ToString());
                    Actividad_BE actividad = dictadobll.ListarActividadesDictado(dictado).FirstOrDefault(item => item.Id == actividadId);
                    Entrega_BE entrega = dictadobll.ListarEntregasActividad(actividad).FirstOrDefault(item => item.Id == int.Parse(Session["entrega_ver"].ToString()));

                    string pdfUrl = "data:application/pdf;base64," + Convert.ToBase64String(entrega.Archivo);
                    materialFechalabel.Text = "Fecha: " + entrega.Fecha.ToString("dd/MM/yyyy");
                    comentario.Text = entrega.Comentario;
                    // Incrustar el visualizador de PDF en HTML
                    pdfViewer.Text = string.Format("<embed src=\"{0}\" type=\"application/pdf\" width=\"800px\" height=\"600px\" />", pdfUrl);
                }
            }
            
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            int idCurso = int.Parse(Session["id_dictado_ver"].ToString());
            //obtener dictado
            Dictado_BLL dictadobll = new Dictado_BLL();
            Dictado_BE dictado = dictadobll.ListarDictados().FirstOrDefault(item => item.Id == idCurso);
            int actividadId = int.Parse(Session["actividad_view"].ToString());
            Actividad_BE actividad = dictadobll.ListarActividadesDictado(dictado).FirstOrDefault(item => item.Id == actividadId);
            Entrega_BE entrega = dictadobll.ListarEntregasActividad(actividad).FirstOrDefault(item => item.Id == int.Parse(Session["entrega_ver"].ToString()));

            if (entrega != null && entrega.Archivo != null)
            {
                // Asumiendo que 'material.Archivo' son los bytes del archivo PDF.
                byte[] archivoPdf = entrega.Archivo;

                // Limpiar la respuesta actual.
                Response.Clear();

                // Establecer el tipo de contenido a 'application/pdf' ya que estás sirviendo un archivo PDF.
                Response.ContentType = "application/pdf";

                // Aquí deberías asegurarte de que el nombre del archivo sea válido y tenga la extensión .pdf.
                string nombreArchivo = actividad.Nombre + "-Entrega" + ".pdf"; // por ejemplo

                // Agregar el encabezado 'Content-Disposition' para indicar que se trata de una descarga y proporcionar el nombre del archivo.
                Response.AddHeader("Content-Disposition", "attachment; filename=" + nombreArchivo);

                // Escribir los bytes del archivo en la respuesta.
                Response.BinaryWrite(archivoPdf); // Usando BinaryWrite para escribir los bytes directamente en la respuesta.

                // Llamar a End para enviar la respuesta al cliente y detener la ejecución de la página.
                Response.End();
            }

        }

        protected void ButtonComment_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                int idCurso = int.Parse(Session["id_dictado_ver"].ToString());
                //obtener dictado
                Dictado_BLL dictadobll = new Dictado_BLL();
                Dictado_BE dictado = dictadobll.ListarDictados().FirstOrDefault(item => item.Id == idCurso);
                int actividadId = int.Parse(Session["actividad_view"].ToString());
                Actividad_BE actividad = dictadobll.ListarActividadesDictado(dictado).FirstOrDefault(item => item.Id == actividadId);
                Entrega_BE entrega = dictadobll.ListarEntregasActividad(actividad).FirstOrDefault(item => item.Id == int.Parse(Session["entrega_ver"].ToString()));
                entrega.Comentario = comentario.Text;
                dictadobll.EditarComentario(entrega);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/MisDictados/Actividad/VerActividad.aspx");
        }
    }
}