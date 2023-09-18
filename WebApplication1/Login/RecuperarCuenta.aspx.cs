using BusinessEntity;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Login
{
    public partial class RecuperarCuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRecover_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Usuario_BLL usuarioBLL = new Usuario_BLL();
                Usuario_BE usuarioBE = usuarioBLL.VerificarUsuarioSinPassword(email.Text);
                if (!string.IsNullOrEmpty(usuarioBE.Usuario))
                {
                    usuarioBLL.RecuperarPassword(usuarioBE);
                    Response.Write("<script>alert('Se envio un email a su direccion con instrucciones para recuperar su cuenta'); window.location.href = '/Login/Login.aspx' </script>");
                }
                else
                {
                    Response.Write("<script>alert('No existe un usuario con esa direccion');</script>");
                }
            }
        }
    }
}