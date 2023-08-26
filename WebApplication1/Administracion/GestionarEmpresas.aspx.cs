using BusinessEntity.Composite;
using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;

namespace WebApplication1.Administracion
{
    public partial class GestionarEmpresas : System.Web.UI.Page
    {
        Empresa_BLL mapper = new Empresa_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Permisos
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
                    actualizar_grid();
                    

                    //// Crear una lista de objetos ficticios "Company"
                    //List<Company> companies = new List<Company>
                    //{
                    //    new Company { CompanyName = "Empresa 1", CompanyDesc = "Descripción 1", CompanyEmail = "empresa1@ejemplo.com", CompanyPhone = "123456789" },
                    //    new Company { CompanyName = "Empresa 2", CompanyDesc = "Descripción 2", CompanyEmail = "empresa2@ejemplo.com", CompanyPhone = "987654321" },
                    //    new Company { CompanyName = "Empresa 3", CompanyDesc = "Descripción 3", CompanyEmail = "empresa3@ejemplo.com", CompanyPhone = "456123789" },
                    //    // puedes agregar más empresas aquí
                    //};

                    //// Vincular la lista de objetos "Company" a la GridView
                    //CompaniesGrid.DataSource = companies;
                    //CompaniesGrid.DataBind();
                }
            }
        }

        protected void actualizar_grid()
        {
            List<Empresa_BE> empresas = mapper.ListarEmpresas();
            CompaniesGrid.DataSource = empresas;
            CompaniesGrid.DataBind();
        }

        protected void CompaniesGrid_RowEditing(object sender, EventArgs e)
        {
            
        }

        protected void CompaniesGrid_RowDeleting(object seder, EventArgs e)
        {

        }

        public class Company
        {
            public string CompanyName { get; set; }
            public string CompanyDesc { get; set; }
            public string CompanyEmail { get; set; }
            public string CompanyPhone { get; set; }
        }

        protected void NewCompanyButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Empresas/NuevaEmpresa.aspx");
        }

        protected void botoneditar_Click(object sender, EventArgs e)
        {
            // Obteniendo el botón que desencadenó el evento
            Button btn = (Button)sender;

            // Recuperando el índice de la fila desde el CommandArgument del botón
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Obteniendo el valor de IdEmpresa usando DataKeys
            string idEmpresa = CompaniesGrid.DataKeys[rowIndex].Value.ToString();

            // Ahora puedes usar idEmpresa para tus propósitos
            Session["id_empresa_editar"] = idEmpresa;
            Response.Redirect("~/Administracion/Empresas/DetalleEmpresa.aspx");
        }

        protected void botoneliminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/GestionarEmpresas.aspx");
            
        }
    }
}