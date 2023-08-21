using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Tutores.MisDictados.Material
{
    public partial class NuevoMaterial : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Aquí debes implementar la lógica para actualizar el nombre y/o el archivo del material.
            // Esta lógica dependerá de cómo estés manejando los archivos y los datos en tu aplicación.
            Response.Redirect("~/Tutores/MisDictados/Dictado.aspx");
        }
    }
}