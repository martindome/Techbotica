using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Administracion.Empresas
{
    public partial class DetalleEmpresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEditCompany_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/GestionarEmpresas.aspx");
        }

        protected void btnEditDomains_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Empresas/Dominios.aspx");
        }
    }
}