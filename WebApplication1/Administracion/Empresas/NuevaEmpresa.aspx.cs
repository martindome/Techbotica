using BusinessEntity;
using BusinessEntity.Composite;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Administracion.Empresas
{
    public partial class NuevaEmpresa : System.Web.UI.Page
    {
        Empresa_BLL mappere = new Empresa_BLL();
        List<Dominio_BE> dt;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["id_empresa_editar"] = null;
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Administracion/GestionarEmpresas")))
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }
            else
            {
                if (!IsPostBack)
                {
                    BindDomainsGrid();
                    dt = new List<Dominio_BE>();
                    ViewState["DomainList"] = dt;
                }
            }
        }

        private void BindDomainsGrid()
        {
            // Create a DataTable object and add columns to it

            // Bind the DataTable to the GridView
            dt = (List<Dominio_BE>)ViewState["DomainList"];
            DomainsGrid.DataSource = dt;
            DomainsGrid.DataBind();
        }

        protected void btnCreateCompany_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                dt = (List<Dominio_BE>)ViewState["DomainList"];
                Empresa_BE empresabe = new Empresa_BE();
                empresabe.Nombre = CompanyName.Text;
                empresabe.Descripcion = CompanyDesc.Text;
                empresabe.Telefono = CompanyPhone.Text;
                empresabe.Email = CompanyEmail.Text;
                empresabe.Borrado = "No";
                empresabe.Dominios = dt;
                mappere.NuevaEmpresa(empresabe);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Empresa creada con exito');window.location.href = '/Administracion/GestionarEmpresas.aspx'", true);
            }
        }

        protected void botoneliminardominio_Click(object sender, EventArgs e)
        {
            dt = (List<Dominio_BE>)ViewState["DomainList"];
            Button btn = (Button)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Eliminar el dominio de la lista dt basado en el índice
            if (rowIndex >= 0 && rowIndex < dt.Count)
            {
                dt.RemoveAt(rowIndex);
                ViewState["DomainList"] = dt;
                BindDomainsGrid();
            }
        }

        protected void btnCreateDomain_Click(object sender, EventArgs e)
        {
            string pattern = @"^(?!-)(?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?\.[a-zA-Z]{2,6}$";
            if (!Regex.IsMatch(NewDomain.Text, pattern))
            {
                // El valor del TextBox no coincide con la expresión regular, manejar error.
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Formato de dominio no valido');", true);
            }
            else
            {
                dt = (List<Dominio_BE>)ViewState["DomainList"];
                Dominio_BE d = new Dominio_BE();
                d.Sufijo = NewDomain.Text;
                d.Borrado = "No";

                bool exists = dt.Any(dom => dom.Sufijo.Equals(d.Sufijo, StringComparison.OrdinalIgnoreCase));

                if (!exists)
                {
                    dt.Add(d);
                    ViewState["DomainList"] = dt;
                    BindDomainsGrid();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Dominio existente');", true);
                }
            }
        }
    }
}