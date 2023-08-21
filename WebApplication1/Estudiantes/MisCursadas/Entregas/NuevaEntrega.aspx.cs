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

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (pdfFile.HasFile)
            //{
            //    try
            //    {
            //        string fileName = Path.GetFileName(pdfFile.PostedFile.FileName);
            //        string folderPath = Server.MapPath("~/Uploads/");

            //        // Crear el directorio si no existe
            //        if (!Directory.Exists(folderPath))
            //        {
            //            Directory.CreateDirectory(folderPath);
            //        }

            //        // Guardar el archivo
            //        pdfFile.PostedFile.SaveAs(folderPath + fileName);

            //        // Aquí debes implementar la lógica para guardar la información de la entrega en la base de datos
            //    }
            //    catch (Exception ex)
            //    {
            //        // Manejar la excepción
            //    }
            //}
            Response.Redirect("~/Estudiantes/MisCursadas/Cursada.aspx");
        }
    }
}