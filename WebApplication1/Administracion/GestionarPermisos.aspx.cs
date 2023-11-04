using BusinessEntity.Composite;
using BusinessEntity;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Administracion
{
    public partial class GestionarPermisos : System.Web.UI.Page
    {
        Permisos_BLL permisosBLL = new Permisos_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Administracion/GestionarPermisos")))
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }

            if (!IsPostBack)
            {
                Session["familia_editar"] = null;
                BindFamiliesGrid();
            }
        }

        protected void AddFamilyButton_Click(object sender, EventArgs e)
        {
            string nombreFamilia = NewFamilyNameTextBox.Text.Trim();
            if (!string.IsNullOrEmpty(nombreFamilia))
            {
                permisosBLL.AgregarFamilia(nombreFamilia);
                BindFamiliesGrid();
            }
        }

        protected void btnEditFamily_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idFamilia = Convert.ToInt32(btn.CommandArgument);
            // Guardar el id de la familia a editar en la sesión y redirigir a la página de edición
            
            Session["familia_editar"] = idFamilia;
            Response.Redirect("~/Administracion/Permisos/EditarFamilia.aspx");
            
        }

        protected void btnDeleteFamily_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idFamilia = Convert.ToInt32(btn.CommandArgument);

            //obtener familia en una Familia_BE
            List<Familia_BE> familias = permisosBLL.ListarFamilias();
            Familia_BE familia = familias.FirstOrDefault(f => f.id == idFamilia);

            //if (familia.listaPatentes.Count > 0)
            //{
            //    Response.Write("<script>alert('La familia no se puede eliminar porque tiene patentes');window.location.href = '/Default.aspx';</script>");
            //}

            List<Usuario_BE> usuarios = new Usuario_BLL().ListarUsuarios();

            //filtrar los usuarios cuya familia es familia
            usuarios = usuarios.Where(u => u.Familia.id == idFamilia).ToList();

            if (usuarios.Count > 0)
            {
                Response.Write("<script>alert('La familia no se puede eliminar porque tiene usuarios');</script>");
            }
            else
            {
                permisosBLL.EliminarFamilia(familia);
            }
            BindFamiliesGrid();
        }

        private void BindFamiliesGrid()
        {
            var familias = permisosBLL.ListarFamilias();
            FamiliesGrid.DataSource = familias;
            FamiliesGrid.DataBind();
        }
    }
}