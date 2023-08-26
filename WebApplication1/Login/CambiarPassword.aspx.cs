using BusinessEntity;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Login
{
    public partial class CambiarPassword : System.Web.UI.Page
    {
        Usuario_BE usuarioBE = new Usuario_BE();
        Usuario_BLL usuarioBLL = new Usuario_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null)
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            usuarioBE = usuarioBLL.VerificarUsuario(((Usuario_BE)Session["usuario"]).Usuario, TextBoxPassActual.Text);
            if (!string.IsNullOrEmpty(usuarioBE.Usuario) && usuarioBE.Borrado == "No")
            {
                usuarioBE.Contraseña = TextBoxPassword.Text;
                usuarioBLL.CambiarPassword(usuarioBE);
                Session["usuario"] = null;
                Session["carrito"] = null;
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Password actualizada. Inicie sesion nuevamente');window.location.href = '/Default.aspx'", true);
            }
            else
            {
                Label1.Text = "Password actual incorrecta";
            }
        }

        protected void btnUnenroll_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}