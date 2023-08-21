using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Estudiantes
{
    public partial class DetalleInscripcionCarrera : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUnenroll_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Estudiantes/GestionarInscripciones.aspx");
        }
    }
}