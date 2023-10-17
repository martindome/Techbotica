using BusinessEntity;
using BusinessLayer;
using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Administracion;
using WebApplication1.Administracion.Empresas;
using static System.Net.Mime.MediaTypeNames;

namespace WebApplication1.Registarse
{
    public partial class Registarse : System.Web.UI.Page
    {

        Usuario_BLL usuarioBLL = new Usuario_BLL();
        Usuario_BE usuarioBE = new Usuario_BE();
        Empresa_BLL empresaBLL = new Empresa_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;
            if (Session["usuario"] != null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Cierre sesion para registrar un nuevo usuario');window.location.href = '/Default.aspx'", true);
            }
            if (!IsPostBack)
            {
                CargarEmpresas();
            }
        }

        private void CargarEmpresas()
        {
            List<Empresa_BE> listaEmpresas = empresaBLL.ListarEmpresas();
            ddlEmpresa.DataSource = listaEmpresas;
            ddlEmpresa.DataTextField = "Nombre"; // El campo que se mostrará
            ddlEmpresa.DataValueField = "IdEmpresa"; // El valor que se enviará de fondo
            ddlEmpresa.DataBind();

            // Opcional: Agregar un item por defecto como primer valor
            //ddlEmpresa.Items.Insert(0, new ListItem("-- Seleccione una empresa --", "0"));
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                usuarioBE = usuarioBLL.VerificarUsuarioEmail(correoElectronico.Text);
                if (!string.IsNullOrEmpty(usuarioBE.Email) && usuarioBE.Borrado == "No")
                {
                    Label1.Text = "Email '" + correoElectronico.Text + "' existente";
                    Label1.Visible = true;
                }
                else
                {
                    int idEmpresaSeleccionada = Convert.ToInt32(ddlEmpresa.SelectedValue);
                    List<Dominio_BE> dominios = empresaBLL.ListarDominiosEmpresa(idEmpresaSeleccionada);
                    string sufijo = correoElectronico.Text.Split('@')[1];
                    if (!(dominios.Any(item => item.Sufijo == sufijo)))
                    {
                        Label1.Text = "Dominio de la empresa " + correoElectronico.Text.Split('@')[1] + " inexistente";
                        Label1.Visible = true;
                    }
                    else
                    {
                        List<Empresa_BE> empresas = empresaBLL.ListarEmpresas();
                        usuarioBE = usuarioBLL.VerificarUsuarioSinPassword(correoElectronico.Text);
                        if (string.IsNullOrEmpty(usuarioBE.Usuario))
                        {
                            
                            string nuevapass = Servicio.GeneradorClave.CrearRandomContrasenia();
                            Label1.Visible = false;
                            usuarioBE = new Usuario_BE();
                            usuarioBE.Nombre = nombre.Text;
                            usuarioBE.Apellido = apellido.Text;
                            usuarioBE.Usuario = correoElectronico.Text;
                            usuarioBE.Contraseña = nuevapass;
                            usuarioBE.Email = correoElectronico.Text;
                            usuarioBE.Telefono = telefono.Text;
                            usuarioBE.Bloqueado = 0;
                            usuarioBE.Empresa = (int)empresas.FirstOrDefault(item => item.Nombre == ddlEmpresa.SelectedItem.Text)?.IdEmpresa;
                            usuarioBE.Borrado = "No";
                            usuarioBLL.RegistrarEstudiante(usuarioBE);

                            Servicio.GeneradorClave.EnviarNuevaContrasenia(nuevapass, correoElectronico.Text);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Se ha enviado la clave a su correo electronico');window.location.href = '/Default.aspx'", true);
                        }
                        else
                        {
                            string nuevapass = Servicio.GeneradorClave.CrearRandomContrasenia();
                            Label1.Visible = false;
                            usuarioBE.Nombre = nombre.Text;
                            usuarioBE.Apellido = apellido.Text;
                            usuarioBE.Usuario = correoElectronico.Text;
                            //usuarioBE.Contraseña = nuevapass;
                            usuarioBE.Email = correoElectronico.Text;
                            usuarioBE.Telefono = telefono.Text;
                            usuarioBE.Bloqueado = 0;
                            usuarioBE.Empresa = (int)empresas.FirstOrDefault(item => item.Nombre == ddlEmpresa.SelectedItem.Text)?.IdEmpresa;
                            usuarioBE.Borrado = "No";
                            usuarioBLL.UpdateUsuario(usuarioBE);
                            usuarioBLL.RecuperarPassword(usuarioBE);
                            //Servicio.GeneradorClave.EnviarNuevaContrasenia(nuevapass, correoElectronico.Text);
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Se ha enviado la clave a su correo electronico');window.location.href = '/Default.aspx'", true);
                        }
                    }
                    
                }
            } 
        }
    }
}