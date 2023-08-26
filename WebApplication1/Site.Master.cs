using BusinessEntity.Composite;
using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace WebApplication1
{
    public partial class SiteMaster : MasterPage
    {

        public string User;

        protected void Page_Load(object sender, EventArgs e)
        {

            HtmlGenericControl about = (HtmlGenericControl)this.FindControl("about");
            about.Visible = true;
            HtmlGenericControl contact = (HtmlGenericControl)this.FindControl("contact");
            contact.Visible = true;
            HtmlGenericControl busqueda = (HtmlGenericControl)this.FindControl("dropBusquedaDeOferta");
            busqueda.Visible = true;
            HtmlGenericControl tutores = (HtmlGenericControl)this.FindControl("dropTutores");
            tutores.Visible = true;
            HtmlGenericControl estudiantes = (HtmlGenericControl)this.FindControl("dropEstudiantes");
            estudiantes.Visible = true;
            HtmlGenericControl userhtml = (HtmlGenericControl)this.FindControl("user");
            userhtml.Visible = true;

            if (Session["usuario"] == null)
            {
                userhtml.Visible = false;
                botonlogin.Visible = true;
                botonregistrarse.Visible = true;

                
            }
            else
            {
                Usuario_BE usuario = (Usuario_BE)Session["usuario"];
                User = ((Usuario_BE)Session["usuario"]).Usuario;
                userhtml.Visible = true;
                botonlogin.Visible = false;
                botonregistrarse.Visible = false;
            }
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