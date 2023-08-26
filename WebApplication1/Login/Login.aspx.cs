using BusinessEntity;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessEntity.Composite;

namespace WebApplication1.Login
{
    public partial class Login : System.Web.UI.Page
    {
        Usuario_BLL usuarioBLL = new Usuario_BLL();
        Usuario_BE usuarioBE = new Usuario_BE();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Form.DefaultButton = btnLogin.UniqueID;
            this.Page.Form.DefaultFocus = btnLogin.ClientID;
            if (Session["usuario"] != null)
            {
                Session["usuario"] = null;
                Session["carrito"] = null;
                Session["PaginaProductos"] = null;
                Session["BusquedaProductos"] = null;
                //ClientScript.RegisterStartupScript(this.GetType(), "callfunction", "alert('Sesion cerrada correctamente');", true);
                //System.Threading.Thread.Sleep(5);
                //Response.Redirect("../Stilo.aspx");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('La sesion ha sido cerrada');window.location.href = '/Default.aspx'", true);
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            usuarioBE = usuarioBLL.VerificarUsuarioSinPassword(username.Text.ToString());
            //Verificar si existe y si esta bloqueado
            if (!string.IsNullOrEmpty(usuarioBE.Usuario) && usuarioBE.Borrado == "No" && (usuarioBE.Bloqueado < 3))
            {
                //Verificar si la password esta correcta
                usuarioBE = usuarioBLL.VerificarUsuario(username.Text.ToString(), password.Text.ToString());
                if (!string.IsNullOrEmpty(usuarioBE.Usuario))
                {
                    //Trae el perfil del usuario de la base (con composite)
                    usuarioBE.Familia.listaPatentes = usuarioBLL.BuscarAcciones(usuarioBE.Familia.id);
                    //Bloqueado se pone 0
                    usuarioBLL.BlanquearPassword(username.Text.ToString());
                    //Guardamos el objeto usuario en la variables de sesion
                    Session["usuario"] = usuarioBE;
                    Response.Redirect("~/Default.aspx");
                }
                //contraseña incorrecta aumentar contador bloqueado en 1
                else
                {
                    usuarioBLL.BloquearUsuario(username.Text.ToString());
                    Label1.Text = "Usuario o clave invalida";
                    Label1.Visible = true;
                }
            }
            else if (usuarioBE.Bloqueado == 3)
            {
                Label1.Text = "Su usuario esta bloqueado. Contactar administrador.";
                Label1.Visible = true;
            }

            else
            {
                //Usuario o contraseña invalidos
                Label1.Text = "Usuario o clave invalida";
                Label1.Visible = true;
            }
        }
    }
}