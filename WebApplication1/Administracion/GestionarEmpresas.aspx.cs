using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Administracion
{
    public partial class GestionarEmpresas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Crear una lista de objetos ficticios "Company"
                List<Company> companies = new List<Company>
        {
            new Company { CompanyName = "Empresa 1", CompanyDesc = "Descripción 1", CompanyEmail = "empresa1@ejemplo.com", CompanyPhone = "123456789" },
            new Company { CompanyName = "Empresa 2", CompanyDesc = "Descripción 2", CompanyEmail = "empresa2@ejemplo.com", CompanyPhone = "987654321" },
            new Company { CompanyName = "Empresa 3", CompanyDesc = "Descripción 3", CompanyEmail = "empresa3@ejemplo.com", CompanyPhone = "456123789" },
            // puedes agregar más empresas aquí
        };

                // Vincular la lista de objetos "Company" a la GridView
                CompaniesGrid.DataSource = companies;
                CompaniesGrid.DataBind();
            }
        }

        protected void CompaniesGrid_RowEditing(object seder, EventArgs e)
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
            Response.Redirect("~/Administracion/Empresas/DetalleEmpresa.aspx");
        }

        protected void botoneliminar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/GestionarEmpresas.aspx");
        }
    }
}