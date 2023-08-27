using BusinessEntity.Composite;
using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace WebApplication1.Administracion.Empresas
{
    public partial class DetalleEmpresa : System.Web.UI.Page
    {
        Empresa_BLL mappere = new Empresa_BLL();
        Empresa_BE empresabe;
        protected void Page_Load(object sender, EventArgs e)
        {
            //Permisos
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Administracion/GestionarEmpresas")))
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }
            else
            {
                if (!IsPostBack)
                {
                    if (Session["id_empresa_editar"] == null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Empresa inexistente');window.location.href = '/Default.aspx'", true);
                    }
                    empresabe = (Empresa_BE)mappere.ListarEmpresas().FirstOrDefault(item => item.IdEmpresa == int.Parse(Session["id_empresa_editar"].ToString()));
                }
            }
        }

        protected void btnEditCompany_Click(object sender, EventArgs e)
        {
            Session["id_empresa_editar"] = null;
            Response.Redirect("~/Administracion/GestionarEmpresas.aspx");
        }

        protected void btnEditDomains_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Empresas/Dominios.aspx");
        }
    }
}