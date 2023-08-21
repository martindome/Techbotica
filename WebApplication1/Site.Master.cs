using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BuscarCurso(object sender, EventArgs e)
        {
            Response.Redirect("~/BuscarCursos.aspx");
        }

        protected void Unnamed_Click(object sender, EventArgs e)
        {

        }

        protected void botonlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Login/Login.aspx");
        }

        protected void botonregistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Registrarse/Registrarse.aspx");
        }
    }
}