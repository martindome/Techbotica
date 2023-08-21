using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Cursos
{
    public partial class ConfirmacionInscripcionCurso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCursos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BuscarCursos.aspx");
        }

        protected void btnInscripciones_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Estudiantes/GestionarInscripciones");
        }
    }
}