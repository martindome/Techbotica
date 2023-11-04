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
                   
                }
            }
        }

        protected void actualizar_grid()
        {
            string filterName = SearchCompanyByNameTextBox.Text.ToLower().Trim();
            string filterDescription = SearchCompanyByDescTextBox.Text.ToLower().Trim();

            List<Empresa_BE> empresas = mapper.ListarEmpresas();

            // Si hay un valor en el TextBox de nombre, aplicamos ese filtro
            if (!string.IsNullOrEmpty(filterName))
            {
                empresas = empresas.Where(emp => emp.Nombre.ToLower().Contains(filterName)).ToList();
            }

            // Si hay un valor en el TextBox de descripción, aplicamos ese filtro
            if (!string.IsNullOrEmpty(filterDescription))
            {
                empresas = empresas.Where(emp => emp.Descripcion.ToLower().Contains(filterDescription)).ToList();
            }
            CompaniesGrid.DataSource = empresas;
            CompaniesGrid.DataBind();
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

            
            Session["id_empresa_editar"] = idEmpresa;
            Response.Redirect("~/Administracion/Empresas/DetalleEmpresa.aspx");
        }

        protected void botoneliminar_Click(object sender, EventArgs e)
        {
            // Obteniendo el botón que desencadenó el evento
            Button btn = (Button)sender;

            // Recuperando el índice de la fila desde el CommandArgument del botón
            int rowIndex = Convert.ToInt32(btn.CommandArgument);

            // Obteniendo el valor de IdEmpresa usando DataKeys
            string idEmpresa = CompaniesGrid.DataKeys[rowIndex].Value.ToString();

            if (int.Parse(idEmpresa) == 1)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No se puede eliminar empresa')", true);
                actualizar_grid();

            }
            else
            {
                List<Usuario_BE> usuarios = mapper.ObtenerUsuariosEmpresa(int.Parse(idEmpresa.ToString()));
                if (usuarios.Count > 0)
                {
                    Response.Write("<script>alert('La empresa tiene usuarios');</script>");
                }
                Empresa_BE empresabe = (Empresa_BE)mapper.ListarEmpresas().FirstOrDefault(item => item.IdEmpresa == int.Parse(idEmpresa.ToString()));

                mapper.EliminarEmpresa(empresabe);

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Empresa eliminada con exito')", true);

                actualizar_grid();
            }

            
        }

        protected void SearchCompanyButton_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                actualizar_grid();
            }
        }
    }
}