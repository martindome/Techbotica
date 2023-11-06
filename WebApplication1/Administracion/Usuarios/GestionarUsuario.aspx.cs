using BusinessEntity.Composite;
using BusinessEntity;
using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Administracion.Usuarios
{
    public partial class GestionarUsuario : System.Web.UI.Page
    {
        Usuario_BLL mapperu = new Usuario_BLL();
        Usuario_BE usuariobe;
        Permisos_BLL mapperPermisos = new Permisos_BLL();
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
                    if (Session["usuario_modificar"] == null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Usuario inexistente');window.location.href = '/Default.aspx'", true);
                    }
                    //obtener el usuario basado en la variable de sesion y completar los valores de los campos
                    usuariobe = (Usuario_BE)mapperu.ListarUsuarios().FirstOrDefault(item => item.IdUsuario == int.Parse(Session["usuario_modificar"].ToString()));
                    ViewState["usuariobe"] = usuariobe;
                    
                    correoElectronico.Text = usuariobe.Email.ToString();
                    nombre.Text = usuariobe.Nombre.ToString();
                    apellido.Text = usuariobe.Apellido.ToString();
                    telefono.Text = usuariobe.Telefono.ToString();
                    CheckBoxBorrado.Checked = usuariobe.Borrado == "Si" ? true : false;
                    CheckBoxBloqueado.Checked = usuariobe.Bloqueado >= 3 ? true : false;

                    // Completar DropDownList de permisos con todos los permisos
                    List<Familia_BE> permisos = mapperPermisos.ListarFamilias();
                    foreach (Familia_BE p in permisos)
                    {
                        // Suponiendo que quieras mostrar el campo "familia" y usar el "id" como valor.
                        ListItem item = new ListItem(p.familia, p.id.ToString());
                        ddlPerfil.Items.Add(item);
                    }

                    // Seleccionar en el dropdown el permiso del usuario
                    // Asegúrate de que Familia.Nombre sea el campo de texto y Familia.ID el valor en el dropdown
                    ddlPerfil.SelectedValue = usuariobe.Familia.id.ToString();
                }
            }
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                // Obtener el ID seleccionado del dropdown
                int seleccionadoId = int.Parse(ddlPerfil.SelectedValue);
                List<Familia_BE> permisos = mapperPermisos.ListarFamilias();
                // Encontrar el objeto Familia_BE correspondiente al ID seleccionado
                Familia_BE familiaSeleccionada = permisos.FirstOrDefault(p => p.id == seleccionadoId);

                // Ahora tienes el objeto y puedes hacer lo que necesites con él

                Usuario_BE usuarioBE = mapperu.VerificarUsuarioSinPassword(correoElectronico.Text);
                usuarioBE.Nombre = nombre.Text;
                usuarioBE.Apellido = apellido.Text;
                usuarioBE.Telefono = telefono.Text;
                usuarioBE.Bloqueado = CheckBoxBloqueado.Checked ? 3 : 0;
                usuarioBE.Borrado = CheckBoxBorrado.Checked ? "Si" : "No";
                mapperu.UpdateUsuario(usuarioBE);
                mapperu.CambiarPerfil(usuarioBE.IdUsuario, familiaSeleccionada.id);
                Response.Redirect("~/Administracion/GestionarUsuarios.aspx");
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/GestionarUsuarios.aspx");
        }
    }
}