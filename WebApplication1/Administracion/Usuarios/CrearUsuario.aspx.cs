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
    public partial class CrearUsuario : System.Web.UI.Page
    {
        Usuario_BLL usuarioBLL = new Usuario_BLL();
        Usuario_BE usuarioBE = new Usuario_BE();
        Permisos_BLL permisosBLL = new Permisos_BLL();
        Especialidad_BLL especialidadBLL = new Especialidad_BLL();
        Empresa_BLL empresaBLL = new Empresa_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuario"] == null || !(((Usuario_BE)Session["usuario"]).Familia.listaPatentes.Any(x => ((Patente_BE)x).detalle == "/Administracion/GestionarUsuarios")))
                {
                    //Sacamos controles de navegacion
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('No tiene permisos para acceder');window.location.href = '/Default.aspx'", true);
                }
                List<Familia_BE> permisos = permisosBLL.ListarFamilias();
                foreach (Familia_BE permiso in permisos)
                {
                    GridView2.Items.Add(permiso.familia);
                }
                //List<Especialidad_BE> especialidades = especialidadBLL.ListarEspecialidades();
                //foreach (Especialidad_BE especialidad in especialidades)
                //{
                //    ListBoxEspecialidades.Items.Add(especialidad.Nombre);
                //}
                List<Empresa_BE> empresas = empresaBLL.ListarEmpresas();
                foreach (Empresa_BE empresa in empresas)
                {
                    ListItem item = new ListItem(empresa.Nombre, empresa.IdEmpresa.ToString());
                    ListBoxEmpresas.Items.Add(item);
                }
            }
        }
        

        protected void ButtonSalir_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Administracion/GestionarUsuarios.aspx");
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            Label1.Visible = false;
            if (IsValid)
            {
                usuarioBE = usuarioBLL.VerificarUsuarioEmail(TextBoxEmail.Text);
                if (!string.IsNullOrEmpty(usuarioBE.Email))
                {
                    Label1.Text = "Email existente";
                    Label1.Visible = true;
                }
                else
                {
                    usuarioBE = usuarioBLL.VerificarUsuarioSinPassword(TextBoxEmail.Text);
                    if (string.IsNullOrEmpty(usuarioBE.Usuario) && GridView2.SelectedValue != "")
                    {
                        usuarioBE = new Usuario_BE();
                        usuarioBE.Nombre = TextBoxNombre.Text;
                        usuarioBE.Apellido = TextBoxApellido.Text;
                        usuarioBE.Usuario = TextBoxEmail.Text;
                        usuarioBE.Telefono = TextBoxTelefono.Text;
                        usuarioBE.Contraseña = TextBoxPassword.Text;
                        usuarioBE.Bloqueado = 0;
                        usuarioBE.Borrado = "No";
                        usuarioBE.Email = TextBoxEmail.Text;
                        usuarioBE.Familia = new Familia_BE();
                        usuarioBE.Familia.id = permisosBLL.ListarFamilias().FirstOrDefault(x => x.familia == GridView2.SelectedValue).id;
                        if (usuarioBE.Familia.id == 2) //Es estudiante
                        {
                            if (!string.IsNullOrEmpty(ListBoxEmpresas.SelectedValue))
                            {
                                int idEmpresaSeleccionada = int.Parse(ListBoxEmpresas.SelectedValue);
                                usuarioBE.Empresa = empresaBLL.ListarEmpresas().FirstOrDefault(x => x.IdEmpresa == idEmpresaSeleccionada).IdEmpresa;
                                usuarioBE.Especialidad = 0;
                            }
                            else
                            {
                                // Aquí puedes gestionar el error. Por ejemplo:
                                Label1.Text = "Por favor, seleccione una empresa.";
                                Label1.Visible = true;
                                return; // No continuamos con el proceso si no se ha seleccionado una empresa.
                            }
                        }
                        //else if (usuarioBE.Familia.id == 3) // Es tutor
                        //{
                        //    usuarioBE.Especialidad = especialidadBLL.ListarEspecialidades().FirstOrDefault(x => x.IdEspecialidad == int.Parse(ListBoxEspecialidades.SelectedValue.ToString())).IdEspecialidad;
                        //    usuarioBE.Empresa = 0;
                        //}
                        else //Es todo lo demas
                        {
                            usuarioBE.Especialidad = 0;
                            usuarioBE.Empresa = 0;
                        }
                        if (!string.IsNullOrEmpty(usuarioBLL.VerificarUsuarioEmail(TextBoxEmail.Text).Email))
                        {
                            Label1.Text = "Email '" + TextBoxEmail.Text + "' existente";
                            Label1.Visible = true;
                            return;
                        }
                        usuarioBLL.RegistarUsuarioAdmin(usuarioBE);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Usuario creado con exito');window.location.href = '/Administracion/GestionarUsuarios.aspx'", true);
                    }
                    else
                    {
                        Label1.Text = "Usuario Existente";
                        Label1.Visible = true;
                    }
                }
            }
        }
    }
}