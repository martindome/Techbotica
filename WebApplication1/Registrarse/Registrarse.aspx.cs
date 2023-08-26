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
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                usuarioBE = usuarioBLL.VerificarUsuarioEmail(correoElectronico.Text);
                if (!string.IsNullOrEmpty(usuarioBE.Email))
                {
                    Label1.Text = "Email '" + correoElectronico.Text + "' existente";
                    Label1.Visible = true;
                }
                else
                {
                    List<Empresa_BE> empresas = empresaBLL.ListarEmpresas();
                    if (!(empresas.Any(item => item.Nombre == empresa.Text)))
                    {
                        Label1.Text = "Empresa '" + empresa.Text + "' inexistente";
                        Label1.Visible = true;
                    }
                    else
                    {
                        int id_empresa = (int)empresas.FirstOrDefault(item => item.Nombre == empresa.Text)?.IdEmpresa;
                        List<Dominio_BE> dominios = empresaBLL.ListarDominiosEmpresa(id_empresa);
                        string sufijo = correoElectronico.Text.Split('@')[1];
                        if (!(dominios.Any(item => item.Sufijo == sufijo)))
                        {
                            Label1.Text = "Dominio de la empresa " + correoElectronico.Text.Split('@')[1] + " inexistente";
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
                                usuarioBE.Empresa = (int)empresas.FirstOrDefault(item => item.Nombre == empresa.Text)?.IdEmpresa;
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
    }
}