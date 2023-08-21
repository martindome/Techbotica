using System;
using System.Collections.Generic;
using System.Linq;
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
            Response.Redirect("~/Login/Login.aspx");
            // Aquí puedes agregar el código para enviar un enlace de recuperación al correo electrónico
        }
    }
}