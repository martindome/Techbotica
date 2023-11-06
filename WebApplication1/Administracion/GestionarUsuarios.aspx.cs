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
    public partial class GestionUsuarios : System.Web.UI.Page
    {
        Usuario_BLL mapperUsuarios = new Usuario_BLL();
        Permisos_BLL mapperPermisos = new Permisos_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Administracion/GestionarUsuarios")))
            {
                //Sacamos controles de navegacion
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            }

            if (!IsPostBack)
            {
                Session["usuario_modificar"] = null;
            }
        }
        protected void btnSelectUser_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int rowIndex = Convert.ToInt32(btn.CommandArgument);
            int idUsuario = Convert.ToInt32(UsersGrid.DataKeys[rowIndex].Value);
            Session["usuario_modificar"] = idUsuario;

            Usuario_BE usuariobe = (Usuario_BE)mapperUsuarios.ListarUsuarios().FirstOrDefault(item => item.IdUsuario == int.Parse(Session["usuario_modificar"].ToString()));
            if (usuariobe.Usuario == "web.master@techbotica.ar")
            {
                Response.Write("<script>alert('No se puede modificar el usuario'); </script>");
            }
            else
            {
                Response.Redirect("~/Administracion/Usuarios/GestionarUsuario.aspx");
            }
            
        }

        protected void SearchUserButton_Click(object sender, EventArgs e)
        {
            //filter and fill user grid
            Usuario_BLL usuariobll = new Usuario_BLL();
            List<Usuario_BE> usuarios = usuariobll.ListarUsuarios();
            //filter users by name (name and surname together) and email textboxes
            usuarios = usuarios.Where(u => u.Nombre.ToLower().Contains(SearchUserByNameTextBox.Text.ToLower()) && u.Apellido.ToLower().Contains(SearchUserByNameTextBox.Text.ToLower()) && u.Email.ToLower().Contains(SearchUserByEmailTextBox.Text.ToLower())).ToList();
            //filter users by CheckBoxBloqueado 
            if (CheckBoxBloqueado.Checked)
            {
                usuarios = usuarios.Where(u => u.Bloqueado == 3).ToList();
            }
            UsersGrid.DataSource = usuarios;
            UsersGrid.DataBind();
        }

        protected void ButtonNuevoUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Usuarios/CrearUsuario.aspx");
        }

        
    }
}