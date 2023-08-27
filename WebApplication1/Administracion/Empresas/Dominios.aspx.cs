using BusinessEntity.Composite;
using BusinessEntity;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Administracion.Empresas
{
    public partial class Dominios : System.Web.UI.Page
    {
        Empresa_BLL mappere = new Empresa_BLL();
        Empresa_BE empresabe;
        List<Dominio_BE> dt;
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
                    ViewState["empresabe"] = empresabe;
                    ViewState["DomainList"] = empresabe.Dominios;
                    BindDomainsGrid();
                }
            }
        }

        private void BindDomainsGrid()
        {
            empresabe = (Empresa_BE)mappere.ListarEmpresas().FirstOrDefault(item => item.IdEmpresa == int.Parse(Session["id_empresa_editar"].ToString()));
            ViewState["empresabe"] = empresabe;
            ViewState["DomainList"] = empresabe.Dominios;
            dt = empresabe.Dominios;
            DomainsGrid.DataSource = dt;
            DomainsGrid.DataBind();
        }

        protected void botoneliminardominio_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            // Recuperando el índice de la fila desde el CommandArgument del botón
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Obteniendo el valor de IdEmpresa usando DataKeys
            string domainId = DomainsGrid.DataKeys[rowIndex].Value.ToString();


            Empresa_BLL empresaBll = new Empresa_BLL();
            empresaBll.EliminarDominio(int.Parse(domainId));

            // Actualizar el GridView
            BindDomainsGrid();
        }

        protected void btnCreateDomain_Click(object sender, EventArgs e)
        {
            Dominio_BE newDomain = new Dominio_BE
            {
                Sufijo = NewDomain.Text,
                IdEmpresa = ((Empresa_BE)ViewState["empresabe"]).IdEmpresa,
                Borrado = "No" // o lo que sea que utilices para representar un dominio no borrado.
            };

            Empresa_BLL empresaBll = new Empresa_BLL();
            empresaBll.NuevoDominio(newDomain);

            // Actualizar el GridView
            BindDomainsGrid();
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Empresas/DetalleEmpresa.aspx");
        }
    }
}