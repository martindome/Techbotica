using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using BusinessEntity.Composite;
using DataAccessLayer;

namespace BusinessLayer
{
    public class Usuario_BLL
    {

        Usuario_DAL mapper = new Usuario_DAL();

        public List<Usuario_BE> ListarUsuarios()
        {
            return mapper.listar_usuarios();
        }

        public Usuario_BE VerificarUsuario(string usuario, string contraseña)
        {
            return mapper.loguear(usuario, contraseña);
        }

        public Usuario_BE obtener_usuario(string usuario)
        {
            return mapper.obtener_usuario(usuario);
        }

        public Usuario_BE obtener_usuario(int usuario)
        {
            return mapper.obtener_usuario(usuario);
        }

        public List<Compuesto_BE> BuscarAcciones(int id_tipousuario)
        {
            return mapper.buscar_patentes(id_tipousuario);
        }

        public void BloquearUsuario(string usuario)
        {
            mapper.bloquear_usuario(usuario);
        }

        public void UpdateUsuario(Usuario_BE usuario)
        {
            mapper.update_usuario(usuario);
        }

        public Usuario_BE VerificarUsuarioSinPassword(string usuario)
        {
            return mapper.validar_usuario_sin_password(usuario);
        }

        public Usuario_BE VerificarUsuarioEmail(string email)
        {
            return mapper.validar_usuario_email(email);
        }

        public void RegistarCliente(Usuario_BE usuarioBE)
        {
            mapper.registrar_usuario_cliente(usuarioBE);
        }

        public void RegistarUsuarioAdmin(Usuario_BE usuarioBE)
        {
            mapper.registrar_usuario_admin(usuarioBE);
        }

        public void BlanquearPassword(string usuario)
        {
            mapper.blanquear_password(usuario);
        }

        public void CambiarPerfil(int usuario, int tipo_usuario)
        {
            mapper.cambiar_familia(usuario, tipo_usuario);
        }

        public List<Usuario_BE> UsuariosBloquedos()
        {
            return mapper.listar_usuarios_bloqueados();
        }

        public void DesbloquearUsuario(string usuario)
        {
            mapper.desbloquear_usuario(usuario);
        }

        public void RecuperarPassword(Usuario_BE usuario)
        {
            mapper.recuperar_password(usuario);
        }

        public void CambiarPassword(Usuario_BE usuario)
        {
            mapper.cambiar_password(usuario);
        }

        public void BorrarUsuario(Usuario_BE usuario)
        {
            mapper.borrar_usuario(usuario);
        }

        public void RestaurarUsuario(Usuario_BE usuario)
        {
            mapper.restaurar_usuario(usuario);
        }
    }
}
