using BusinessEntity;
using BusinessLayer;
using Servicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                usuarioBE = usuarioBLL.VerificarUsuarioEmail(correoElectronico.Text);
                if (!string.IsNullOrEmpty(usuarioBE.Email))
                {
                    Label1.Text = "Email existente";
                    Label1.Visible = true;
                }
                else
                {
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
                        usuarioBE.Bloqueado = 3;
                        usuarioBE.Borrado = "No";
                        usuarioBLL.RegistrarEstudiante(usuarioBE);

                        Servicio.GeneradorClave.EnviarNuevaContrasenia(nuevapass, correoElectronico.Text);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Se ha enviado la clave a su correo electronico');window.location.href = '/Default.aspx'", true);
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