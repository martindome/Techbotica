using BusinessEntity;
using BusinessEntity.Composite;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Estudiantes.MisCursadas
{
    public partial class NuevaEntrega : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Estudiante/Dictados")))
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }
            else
            {
                if (Session["id_dictado_ver"] == null)
                {
                    Response.Write("<script>alert('No se encuentra el material');window.location.href = '/Default.aspx';</script>");
                }
            }   
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (pdfFile.HasFile)
            {
                try
                {
                    if (pdfFile.PostedFile.ContentType != "application/pdf")
                    {
                        Response.Write("<script>alert('Por favor, sube solamente archivos PDF.');</script>");
                        return;
                    }

                    int fileSizeLimit = 5 * 1024 * 1024;
                    if (pdfFile.PostedFile.ContentLength > fileSizeLimit)
                    {
                        Response.Write("<script>alert('El tamaño del archivo excede el límite permitido de 5 MB.');</script>");
                        return;
                    }

                    int idCurso = int.Parse(Session["id_dictado_ver"].ToString());
                    Dictado_BLL dictadobll = new Dictado_BLL();
                    Dictado_BE dictado = dictadobll.ListarDictados().FirstOrDefault(item => item.Id == idCurso);

                    int actividadId = int.Parse(Session["actividad_view"].ToString());
                    Actividad_BE actividad = dictadobll.ListarActividadesDictado(dictado).FirstOrDefault(item => item.Id == actividadId);

                    Usuario_BE usuario = (Usuario_BE)Session["usuario"];

                    Entrega_BE entrega = new Entrega_BE();
                    byte[] pdfData = pdfFile.FileBytes;
                    entrega.Archivo = pdfData;
                    entrega.Dictado = dictado;
                    entrega.Actividad = actividad;
                    entrega.Estudiante = usuario;
                    entrega.Fecha = DateTime.Now;
                    entrega.Comentario = "";
                    dictadobll.NuevaEntrega(entrega);
                    Response.Redirect("~/Estudiantes/MisCursadas/Cursada.aspx");
                }
                catch (Exception ex)
                {
                    // Codifica el mensaje de la excepción para uso seguro en JavaScript
                    string safeMessage = HttpUtility.JavaScriptStringEncode(ex.Message);

                    // Construye el script para mostrar el mensaje
                    string script = $"<script>alert('Error: {safeMessage}');</script>";

                    // Escribe el script en la respuesta
                    Response.Write(script);
                }
            }
            else
            {
                Response.Write("<script>alert('Archivo invalido');</script>");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Estudiantes/MisCursadas/VerActividad.aspx");
        }
    }
}