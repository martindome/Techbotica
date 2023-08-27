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
    public partial class GestionarEstudiantes : System.Web.UI.Page
    {
        Usuario_BLL mapperUsuarios = new Usuario_BLL();
        Permisos_BLL mapperPermisos = new Permisos_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Administracion/GestionarUsuarios")))
            //{
            //    //Sacamos controles de navegacion
            //    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
            //}

            if (!IsPostBack)
            {
                ListBoxUsuarios.Items.Clear();

                //ListBoxFamilias.Items.Clear();

                ListBoxUsuarios.Enabled = true;
                CheckBoxBorradoFiltro.Enabled = true;
                CheckBoxBloqueadoFiltro.Enabled = true;
                TextBoxUsuarioFiltro.Enabled = true;

                //ListBoxFamilias.Enabled = false;
                CheckBoxBorrado.Enabled = false;
                CheckBoxBloqueado.Enabled = false;
                TextBoxEmail.Enabled = false;
                TextBoxNombre.Enabled = false;
                TextBoxApellido.Enabled = false;
                TextBoxTelefono.Enabled = false;
                ButtonAplicar.Enabled = false;

                List<Familia_BE> permisos = mapperPermisos.ListarFamilias();
                List<Usuario_BE> usuarios = mapperUsuarios.ListarUsuarios();
                usuarios.Sort((x, y) => x.Usuario.CompareTo(y.Usuario));

                foreach (Usuario_BE u in usuarios)
                {
                    ListBoxUsuarios.Items.Add(u.Usuario);
                }
            }
        }

        protected void ButtonAplicar_Click(object sender, EventArgs e)
        {
            if (ListBoxUsuarios.SelectedValue != "")
            {
                Usuario_BE usuarioBE = mapperUsuarios.VerificarUsuarioSinPassword(ListBoxUsuarios.SelectedValue);
                usuarioBE.Nombre = TextBoxNombre.Text;
                usuarioBE.Email = TextBoxEmail.Text;
                usuarioBE.Usuario = TextBoxEmail.Text;
                usuarioBE.Telefono= TextBoxTelefono.Text;
                usuarioBE.Apellido = TextBoxApellido.Text;
                usuarioBE.Bloqueado = CheckBoxBloqueado.Checked ? 3 : 0;
                usuarioBE.Borrado = CheckBoxBorrado.Checked ? "Si" : "No";
                mapperUsuarios.UpdateUsuario(usuarioBE);

                //if (ListBoxFamilias.SelectedValue != "")
                //{
                //    string usuario = ListBoxUsuarios.SelectedValue;
                //    string tipo_usuario = ListBoxFamilias.SelectedValue;
                //    Familia_BE p = mapperPermisos.ListarFamilias().FirstOrDefault(permiso => permiso.familia == tipo_usuario);
                //    mapperUsuarios.CambiarPerfil(usuarioBE.IdUsuario, p.id);
                //}
                LabelAccion.Text = "Usuario cambiado correctamente";
            }
            else
            {
                LabelAccion.Text = "Error al cambiar usuario";
            }
        }

        protected void ButtonSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void ButtonFiltrar_Click(object sender, EventArgs e)
        {
            ListBoxUsuarios.Items.Clear();
            List<Usuario_BE> usuarios = mapperUsuarios.ListarUsuarios();
            usuarios.Sort((x, y) => x.Usuario.CompareTo(y.Usuario));


            string nombre = TextBoxUsuarioFiltro.Text;
            string borrado = CheckBoxBorradoFiltro.Checked ? "Si" : "No";
            List<Usuario_BE> aux = new List<Usuario_BE>();

            IEnumerable<Usuario_BE> query = new List<Usuario_BE>();

            if (CheckBoxBorradoFiltro.Checked)
            {
                query = from c in usuarios where (c.Borrado == borrado) select c;
                usuarios = query.ToList();
            }
            if (CheckBoxBloqueadoFiltro.Checked)
            {
                query = from c in usuarios where (c.Bloqueado >= 3) select c;
                usuarios = query.ToList();
            }
            if (nombre.Length != 0)
            {
                query = from c in usuarios where (c.Usuario.Contains(nombre) || nombre.Contains(c.Usuario)) select c;
                usuarios = query.ToList();
            }

            foreach (Usuario_BE u in usuarios)
            {
                ListBoxUsuarios.Items.Add(u.Usuario);
            }

            if (ListBoxUsuarios.SelectedIndex == -1)
            {
                //ListBoxFamilias.Enabled = false;
                CheckBoxBorrado.Enabled = false;
                TextBoxEmail.Enabled = false;
                TextBoxNombre.Enabled = false;
                TextBoxApellido.Enabled = false;
                TextBoxTelefono.Enabled = false;
                ButtonAplicar.Enabled = false;
            }
        }

        protected void ButtonSeleccionar_Click(object sender, EventArgs e)
        {
            //ListBoxFamilias.Items.Clear();
            if (ListBoxUsuarios.SelectedIndex != -1)
            {
                //ListBoxFamilias.Enabled = true;
                CheckBoxBorrado.Enabled = true;
                CheckBoxBloqueado.Enabled = true;
                TextBoxEmail.Enabled = true;
                TextBoxNombre.Enabled = true;
                ButtonAplicar.Enabled = true;
                TextBoxApellido.Enabled = true;
                TextBoxTelefono.Enabled = true;

                Usuario_BE usuario = mapperUsuarios.VerificarUsuarioSinPassword(ListBoxUsuarios.SelectedValue);
                TextBoxEmail.Text = usuario.Email;
                TextBoxNombre.Text = usuario.Nombre;
                TextBoxApellido.Text = usuario.Apellido;
                TextBoxTelefono.Text = usuario.Telefono;
                CheckBoxBorrado.Checked = usuario.Borrado == "Si" ? true : false;
                CheckBoxBloqueado.Checked = usuario.Bloqueado >= 3 ? true : false;
                LabelUsuarioSeleccionado.Text = usuario.Usuario;

                List<Familia_BE> permisos = mapperPermisos.ListarFamilias();
                permisos.Sort((x, y) => x.familia.CompareTo(y.familia));

                //foreach (Familia_BE b in permisos)
                //{
                //    if (usuario.Familia.id == b.id)
                //    {
                //        LabelFamiliaActual.Text = b.familia;
                //    }
                //    //ListBoxFamilias.Items.Add(b.familia);
                //}
                //var keyValue = 1; // Replace with your Convert.ToInt32(Request.QueryString["RowToSelectID"])
                ////for (int i = 0; i <= this.ListBoxFamilias.Items.Count - 1; i++)
                ////{
                ////    //if (ListBoxFamilias.Items[i].Value == usuario.Familia.familia)
                ////    {
                ////        //this.ListBoxFamilias.SelectedIndex = i;
                ////    }
                ////}
            }
            else
            {
                //ListBoxFamilias.Enabled = false;
                CheckBoxBorrado.Enabled = false;
                TextBoxEmail.Enabled = false;
                TextBoxNombre.Enabled = false;
                TextBoxApellido.Enabled = false;
                TextBoxTelefono.Enabled = false;
                ButtonAplicar.Enabled = false;
            }
        }

        protected void ButtonNuevoUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/Usuarios/CrearUsuario.aspx");
        }
    }
}