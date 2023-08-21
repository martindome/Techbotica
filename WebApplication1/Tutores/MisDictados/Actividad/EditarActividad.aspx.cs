using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.MisDictados.Actividad
{
    public partial class EditarActividad : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            //if (pdfFile.HasFile)
            //{
            //    try
            //    {
            //        string filename = Path.GetFileName(pdfFile.FileName);
            //        pdfFile.SaveAs(Server.MapPath("~/Path/To/Save/") + filename);
            //        Response.Write("Upload status: File uploaded!");
            //    }
            //    catch (Exception ex)
            //    {
            //        Response.Write("Upload status: The file could not be uploaded. The following error occured: " + ex.Message);
            //    }
            //}
            Response.Redirect("~/Tutores/MisDictados/Dictado.aspx");
        }
    }
}