﻿using BusinessEntity;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.MisDictados.Actividad
{
    public partial class NuevaActividad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id_dictado_ver"] == null)
            {
                Response.Write("<script>alert('No se encuentra el material');window.location.href = '/Default.aspx';</script>");
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

                    Actividad_BE actividad = new Actividad_BE();
                    byte[] pdfData = pdfFile.FileBytes;
                    actividad.Archivo = pdfData;
                    actividad.Dictado = dictado;
                    actividad.Fecha = DateTime.Now;
                    actividad.Nombre = actividadName.Text;
                    dictadobll.NuevaActividad(actividad);
                    Response.Redirect("~/Tutores/MisDictados/Dictado.aspx");
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
    }
}