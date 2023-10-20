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
    public partial class VerActividad : System.Web.UI.Page
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
                if (Session["actividad_view"] == null || Session["id_dictado_ver"] == null)
                {
                    Response.Write("<script>alert('No se encuentra el material');window.location.href = '/Default.aspx';</script>");
                }
                if (!IsPostBack)
                {
                    Session["entrega_ver"] = null;
                    LoadEntregas();
                    int idCurso = int.Parse(Session["id_dictado_ver"].ToString());
                    //obtener dictado
                    Dictado_BLL dictadobll = new Dictado_BLL();
                    Dictado_BE dictado = dictadobll.ListarDictados().FirstOrDefault(item => item.Id == idCurso);
                    Actividad_BE actividad = dictadobll.ListarActividadesDictado(dictado).FirstOrDefault(item => item.Id == int.Parse(Session["actividad_view"].ToString()));

                    string pdfUrl = "data:application/pdf;base64," + Convert.ToBase64String(actividad.Archivo);


                    actividadNameLable.Text = "Nombre: " + actividad.Nombre;
                    actividadFechaLabel.Text = "Fecha: " + actividad.Fecha.ToString("dd/MM/yyyy");

                    // Incrustar el visualizador de PDF en HTML
                    pdfViewer.Text = string.Format("<embed src=\"{0}\" type=\"application/pdf\" width=\"800px\" height=\"600px\" />", pdfUrl);
                }
            }
            
        }

        private void LoadEntregas()
        {
            Dictado_BLL dictadobll = new Dictado_BLL();
            int idCurso = int.Parse(Session["id_dictado_ver"].ToString());
            Dictado_BE dictado = dictadobll.ListarDictados().FirstOrDefault(item => item.Id == idCurso);
            int actividadId = int.Parse(Session["actividad_view"].ToString());
            Actividad_BE actividad = dictadobll.ListarActividadesDictado(dictado).FirstOrDefault(item => item.Id == actividadId);
            List<Entrega_BE> entregas = dictadobll.ListarEntregasActividad(actividad);
            //filtrar entregas que pertenescan al usuario
            //Usuario_BE usuario = (Usuario_BE)Session["usuario"];
            //int userId = usuario.IdUsuario;
            //List<Entrega_BE> entregasFiltradas = new List<Entrega_BE>();
            //foreach (Entrega_BE entrega in entregas)
            //{
            //    if (entrega.Estudiante.IdUsuario == userId)
            //    {
            //        entregasFiltradas.Add(entrega);
            //    }
            //}
            deliveriesGrid.DataSource = entregas;
            deliveriesGrid.DataBind();
        }

        protected void btnViewDelivery_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            // Recuperando el índice de la fila desde el CommandArgument del botón
            int rowIndex = Convert.ToInt32(btn.CommandArgument);
            // Obteniendo el valor de Id del curso usando DataKeys
            int idEntrega = Convert.ToInt32(deliveriesGrid.DataKeys[rowIndex].Value);
            // Almacena el ID del curso en una variable de sesión para usarlo en la página de edición
            Session["entrega_ver"] = idEntrega;
            Response.Redirect("~/Tutores/MisDictados/Actividad/Entrega/VerEntrega.aspx");
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            int actividadId = int.Parse(Session["actividad_view"].ToString());

            // Aquí asumimos que tienes acceso a tus métodos de negocio o datos para obtener el material.
            Dictado_BLL dictadobll = new Dictado_BLL();
            int idCurso = int.Parse(Session["id_dictado_ver"].ToString());
            Dictado_BE dictado = dictadobll.ListarDictados().FirstOrDefault(item => item.Id == idCurso);

            // Obtener el material específico que quieres.
            Actividad_BE actividad = dictadobll.ListarActividadesDictado(dictado).FirstOrDefault(item => item.Id == actividadId);

            if (actividad != null && actividad.Archivo != null)
            {
                // Asumiendo que 'material.Archivo' son los bytes del archivo PDF.
                byte[] archivoPdf = actividad.Archivo;

                // Limpiar la respuesta actual.
                Response.Clear();

                // Establecer el tipo de contenido a 'application/pdf' ya que estás sirviendo un archivo PDF.
                Response.ContentType = "application/pdf";

                // Aquí deberías asegurarte de que el nombre del archivo sea válido y tenga la extensión .pdf.
                string nombreArchivo = actividad.Nombre + ".pdf"; // por ejemplo

                // Agregar el encabezado 'Content-Disposition' para indicar que se trata de una descarga y proporcionar el nombre del archivo.
                Response.AddHeader("Content-Disposition", "attachment; filename=" + nombreArchivo);

                // Escribir los bytes del archivo en la respuesta.
                Response.BinaryWrite(archivoPdf); // Usando BinaryWrite para escribir los bytes directamente en la respuesta.

                // Llamar a End para enviar la respuesta al cliente y detener la ejecución de la página.
                Response.End();
            }

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Tutores/MisDictados/Dictado.aspx");
        }
    }
}