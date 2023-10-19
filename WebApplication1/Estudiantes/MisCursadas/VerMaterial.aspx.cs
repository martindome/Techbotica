using BusinessEntity;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Estudiantes.Cursadas
{
    public partial class VerMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["material_view"] == null || Session["id_dictado_ver"] == null)
            {
                Response.Write("<script>alert('No se encuentra el material');window.location.href = '/Default.aspx';</script>");
            }
            if (!IsPostBack)
            {
                int idCurso = int.Parse(Session["id_dictado_ver"].ToString());
                //obtener dictado
                Dictado_BLL dictadobll = new Dictado_BLL();
                Dictado_BE dictado = dictadobll.ListarDictados().FirstOrDefault(item => item.Id == idCurso);
                Material_BE material = dictadobll.ListarMaterialesDictado(dictado).FirstOrDefault(item => item.Id == int.Parse(Session["material_view"].ToString()));

                string pdfUrl = "data:application/pdf;base64," + Convert.ToBase64String(material.Archivo);


                materialNameLabel.Text = "Nombre: " + material.Nombre;
                materialFechalabel.Text = "Fecha: " + material.Fecha.ToString("dd/MM/yyyy");

                // Incrustar el visualizador de PDF en HTML
                pdfViewer.Text = string.Format("<embed src=\"{0}\" type=\"application/pdf\" width=\"800px\" height=\"600px\" />", pdfUrl);
            }
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            int materialId = int.Parse(Session["material_view"].ToString());

            // Aquí asumimos que tienes acceso a tus métodos de negocio o datos para obtener el material.
            Dictado_BLL dictadobll = new Dictado_BLL();
            int idCurso = int.Parse(Session["id_dictado_ver"].ToString());
            Dictado_BE dictado = dictadobll.ListarDictados().FirstOrDefault(item => item.Id == idCurso);

            // Obtener el material específico que quieres.
            Material_BE material = dictadobll.ListarMaterialesDictado(dictado).FirstOrDefault(item => item.Id == materialId);

            if (material != null && material.Archivo != null)
            {
                // Asumiendo que 'material.Archivo' son los bytes del archivo PDF.
                byte[] archivoPdf = material.Archivo;

                // Limpiar la respuesta actual.
                Response.Clear();

                // Establecer el tipo de contenido a 'application/pdf' ya que estás sirviendo un archivo PDF.
                Response.ContentType = "application/pdf";

                // Aquí deberías asegurarte de que el nombre del archivo sea válido y tenga la extensión .pdf.
                string nombreArchivo = material.Nombre + ".pdf"; // por ejemplo

                // Agregar el encabezado 'Content-Disposition' para indicar que se trata de una descarga y proporcionar el nombre del archivo.
                Response.AddHeader("Content-Disposition", "attachment; filename=" + nombreArchivo);

                // Escribir los bytes del archivo en la respuesta.
                Response.BinaryWrite(archivoPdf); // Usando BinaryWrite para escribir los bytes directamente en la respuesta.

                // Llamar a End para enviar la respuesta al cliente y detener la ejecución de la página.
                Response.End();
            }

        }
    }
}