using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using BusinessEntity.Composite;
using System.Security.Cryptography.X509Certificates;

namespace DataAccessLayer
{
    public class Usuario_DAL
    {
        Acceso_DAL ac = new Acceso_DAL();

        public List<Usuario_BE> listar_usuarios()
        {
            List<Usuario_BE> usuarios = new List<Usuario_BE>();

            DataTable Tabla = ac.ejecutar_stored_procedure("listar_usuarios", null);
            foreach (DataRow reg in Tabla.Rows)
            {
                Usuario_BE usuarioBE = new Usuario_BE();
                usuarioBE.Usuario = reg["usuario"].ToString();
                usuarioBE.Contraseña = reg["contraseña"].ToString();
                usuarioBE.IdUsuario = Convert.ToInt32(reg["id"].ToString());
                usuarioBE.Nombre = reg["nombre"].ToString();
                usuarioBE.Apellido = reg["apellido"].ToString();
                usuarioBE.Empresa = Convert.ToInt32(reg["id_empresa"].ToString());
                
                usuarioBE.Telefono = reg["telefono"].ToString();
                usuarioBE.Email = reg["email"].ToString();
                usuarioBE.Borrado = reg["borrado"].ToString();
                usuarioBE.Bloqueado = int.Parse(reg["bloqueado"].ToString());
                Familia_BE tipoUsuario = new Familia_BE();
                tipoUsuario.id = Convert.ToInt32(reg["familia"].ToString());
                tipoUsuario.familia = reg["detalle"].ToString();
                usuarioBE.Familia = tipoUsuario;
                usuarios.Add(usuarioBE);
            }
            return usuarios;
        }

        public Usuario_BE obtener_usuario(string usuario)
        {

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@usu";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = usuario;

            DataTable Tabla = ac.ejecutar_stored_procedure("obtener_usuario_usuario", parametros);

            Usuario_BE usuarioBE = new Usuario_BE();

            foreach (DataRow reg in Tabla.Rows)
            {

                usuarioBE.Usuario = reg["usuario"].ToString();
                usuarioBE.Contraseña = reg["contraseña"].ToString();
                usuarioBE.IdUsuario = Convert.ToInt32(reg["id"].ToString());
                usuarioBE.Empresa = Convert.ToInt32(reg["id_empresa"].ToString());
                
                usuarioBE.Nombre = reg["nombre"].ToString();
                usuarioBE.Apellido = reg["apellido"].ToString();
                usuarioBE.Telefono = reg["telefono"].ToString();
                usuarioBE.Email = reg["email"].ToString();
                usuarioBE.Borrado = reg["borrado"].ToString();
                usuarioBE.Bloqueado = Convert.ToInt32(reg["bloqueado"].ToString());
                Familia_BE tipoUsuario = new Familia_BE();
                tipoUsuario.id = Convert.ToInt32(reg["familia"].ToString());
                tipoUsuario.familia = reg["detalle"].ToString();
                usuarioBE.Familia = tipoUsuario;
                //usuarioBE.Bloqueado = Convert.ToInt32(reg["bloqueado"].ToString());

                //user.Sesion.sesionIniciada = bool.Parse(reg["sesionIniciada"].ToString());

            }
            return usuarioBE;
        }

        public Usuario_BE obtener_usuario(int usuario)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id";
            parametros[0].DbType = DbType.Int16;
            parametros[0].Value = usuario;

            DataTable Tabla = ac.ejecutar_stored_procedure("obtener_usuario_id", parametros);

            Usuario_BE usuarioBE = new Usuario_BE();

            foreach (DataRow reg in Tabla.Rows)
            {

                usuarioBE.Usuario = reg["usuario"].ToString();
                usuarioBE.Contraseña = reg["contraseña"].ToString();
                usuarioBE.IdUsuario = Convert.ToInt32(reg["id"].ToString());
                usuarioBE.Nombre = reg["nombre"].ToString();
                usuarioBE.Apellido = reg["apellido"].ToString();
                usuarioBE.Empresa = Convert.ToInt32(reg["id_empresa"].ToString());
                
                usuarioBE.Telefono = reg["telefono"].ToString();
                usuarioBE.Email = reg["email"].ToString();
                usuarioBE.Borrado = reg["borrado"].ToString();
                usuarioBE.Bloqueado = Convert.ToInt32(reg["bloqueado"].ToString());
                Familia_BE tipoUsuario = new Familia_BE();
                tipoUsuario.id = Convert.ToInt32(reg["familia"].ToString());
                tipoUsuario.familia = reg["detalle"].ToString();
                usuarioBE.Familia = tipoUsuario;
                //usuarioBE.Bloqueado = Convert.ToInt32(reg["bloqueado"].ToString());

                //user.Sesion.sesionIniciada = bool.Parse(reg["sesionIniciada"].ToString());

            }
            return usuarioBE;
        }

        public Usuario_BE loguear(string usuario, string contraseña)
        {
            string contraseña_encriptada = Servicio.Encriptacion.Calcular_HashSHA256(contraseña); //Password default: Password1234!

            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@usu";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = usuario;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@pass";
            parametros[1].DbType = DbType.String;
            parametros[1].Value = contraseña_encriptada;

            DataTable Tabla = ac.ejecutar_stored_procedure("verificar_usuario", parametros);

            Usuario_BE usuarioBE = new Usuario_BE();

            foreach (DataRow reg in Tabla.Rows)
            {

                usuarioBE.Usuario = reg["usuario"].ToString();
                usuarioBE.Contraseña = reg["contraseña"].ToString();
                usuarioBE.IdUsuario = Convert.ToInt32(reg["id"].ToString());
                usuarioBE.Nombre = reg["nombre"].ToString();
                usuarioBE.Apellido = reg["apellido"].ToString();
                usuarioBE.Empresa = Convert.ToInt32(reg["id_empresa"].ToString());
                
                usuarioBE.Telefono = reg["telefono"].ToString();
                usuarioBE.Email = reg["email"].ToString();
                usuarioBE.Borrado = reg["borrado"].ToString();
                usuarioBE.Bloqueado = Convert.ToInt32(reg["bloqueado"].ToString());
                Familia_BE tipoUsuario = new Familia_BE();
                tipoUsuario.id = Convert.ToInt32(reg["familia"].ToString());
                tipoUsuario.familia = reg["detalle"].ToString();
                usuarioBE.Familia = tipoUsuario;
                //usuarioBE.Bloqueado = Convert.ToInt32(reg["bloqueado"].ToString());

                //user.Sesion.sesionIniciada = bool.Parse(reg["sesionIniciada"].ToString());

            }
            return usuarioBE;
        }

        public List<Compuesto_BE> buscar_patentes(int familia)
        {
            List<Compuesto_BE> acciones = new List<Compuesto_BE>();

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id_familia";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = familia;


            DataTable Tabla = ac.ejecutar_stored_procedure("listar_patentes", parametros);
            foreach (DataRow reg in Tabla.Rows)
            {
                Patente_BE accion = new Patente_BE();
                accion.id = Convert.ToInt32(reg["id"].ToString());
                accion.detalle = reg["detalle"].ToString();

                acciones.Add(accion);
            }
            return acciones;
        }

        //Agregado para el bloqueo de usuario por reintentos de contraseña
        public void bloquear_usuario(string usuario)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@usu";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = usuario;

            DataTable Tabla = ac.ejecutar_stored_procedure("bloquear_usuario", parametros);

        }

        public void update_usuario(Usuario_BE usuario)
        {
            SqlParameter[] parametros = new SqlParameter[8];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@usu";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = usuario.Usuario;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@email";
            parametros[1].DbType = DbType.String;
            parametros[1].Value = usuario.Email;

            parametros[2] = new SqlParameter();
            parametros[2].ParameterName = "@nombre";
            parametros[2].DbType = DbType.String;
            parametros[2].Value = usuario.Nombre;

            parametros[3] = new SqlParameter();
            parametros[3].ParameterName = "@apellido";
            parametros[3].DbType = DbType.String;
            parametros[3].Value = usuario.Apellido;

            parametros[4] = new SqlParameter();
            parametros[4].ParameterName = "@telefono";
            parametros[4].DbType = DbType.String;
            parametros[4].Value = usuario.Telefono;

            parametros[5] = new SqlParameter();
            parametros[5].ParameterName = "@borrado";
            parametros[5].DbType = DbType.String;
            parametros[5].Value = usuario.Borrado;

            parametros[6] = new SqlParameter();
            parametros[6].ParameterName = "@bloqueado";
            parametros[6].DbType = DbType.String;
            parametros[6].Value = usuario.Bloqueado;

            parametros[7] = new SqlParameter();
            parametros[7].ParameterName = "@empresa";
            parametros[7].DbType = DbType.Int32;
            parametros[7].Value = usuario.Empresa;

            DataTable Tabla = ac.ejecutar_stored_procedure("update_usuario", parametros);

        }

        public void registrar_usuario_admin(Usuario_BE usuario)
        {
            string password = Servicio.Encriptacion.Calcular_HashSHA256(usuario.Contraseña);

            SqlParameter[] parametros = new SqlParameter[9];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@usu";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = usuario.Usuario;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@nom";
            parametros[1].DbType = DbType.String;
            parametros[1].Value = usuario.Nombre;

            parametros[2] = new SqlParameter();
            parametros[2].ParameterName = "@pass";
            parametros[2].DbType = DbType.String;
            parametros[2].Value = password;

            parametros[3] = new SqlParameter();
            parametros[3].ParameterName = "@email";
            parametros[3].DbType = DbType.String;
            parametros[3].Value = usuario.Email;

            parametros[4] = new SqlParameter();
            parametros[4].ParameterName = "@apellido";
            parametros[4].DbType = DbType.String;
            parametros[4].Value = usuario.Apellido;

            parametros[5] = new SqlParameter();
            parametros[5].ParameterName = "@telefono";
            parametros[5].DbType = DbType.String;
            parametros[5].Value = usuario.Telefono;

            parametros[6] = new SqlParameter();
            parametros[6].ParameterName = "@borrado";
            parametros[6].DbType = DbType.String;
            parametros[6].Value = usuario.Borrado;

            parametros[7] = new SqlParameter();
            parametros[7].ParameterName = "@tipo";
            parametros[7].DbType = DbType.Int32;
            parametros[7].Value = usuario.Familia.id;

            parametros[8] = new SqlParameter();
            parametros[8].ParameterName = "@empresa";
            parametros[8].DbType = DbType.Int32;
            parametros[8].Value = usuario.Empresa;


            DataTable Tabla = ac.ejecutar_stored_procedure("registrar_usuario", parametros);
        }

        public void registrar_usuario_estudiante(Usuario_BE usuario)
        {
            string password = Servicio.Encriptacion.Calcular_HashSHA256(usuario.Contraseña);

            SqlParameter[] parametros = new SqlParameter[9];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@usu";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = usuario.Usuario;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@nom";
            parametros[1].DbType = DbType.String;
            parametros[1].Value = usuario.Nombre;

            parametros[2] = new SqlParameter();
            parametros[2].ParameterName = "@pass";
            parametros[2].DbType = DbType.String;
            parametros[2].Value = password;

            parametros[3] = new SqlParameter();
            parametros[3].ParameterName = "@email";
            parametros[3].DbType = DbType.String;
            parametros[3].Value = usuario.Email;

            parametros[4] = new SqlParameter();
            parametros[4].ParameterName = "@apellido";
            parametros[4].DbType = DbType.String;
            parametros[4].Value = usuario.Apellido;

            parametros[5] = new SqlParameter();
            parametros[5].ParameterName = "@telefono";
            parametros[5].DbType = DbType.String;
            parametros[5].Value = usuario.Telefono;

            parametros[6] = new SqlParameter();
            parametros[6].ParameterName = "@borrado";
            parametros[6].DbType = DbType.String;
            parametros[6].Value = usuario.Borrado;

            parametros[7] = new SqlParameter();
            parametros[7].ParameterName = "@tipo";
            parametros[7].DbType = DbType.Int32;
            parametros[7].Value = 2;

            parametros[8] = new SqlParameter();
            parametros[8].ParameterName = "@empresa";
            parametros[8].DbType = DbType.Int32;
            parametros[8].Value = usuario.Empresa;


            DataTable Tabla = ac.ejecutar_stored_procedure("registrar_usuario", parametros);
        }

        public Usuario_BE validar_usuario_sin_password(string usuario)
        {


            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@usu";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = usuario;


            DataTable Tabla = ac.ejecutar_stored_procedure("verificar_usuario_sinpassword", parametros);

            Usuario_BE usuarioBE = new Usuario_BE();

            foreach (DataRow reg in Tabla.Rows)
            {

                usuarioBE.Usuario = reg["usuario"].ToString();
                usuarioBE.Contraseña = reg["contraseña"].ToString();
                usuarioBE.IdUsuario = Convert.ToInt32(reg["id"].ToString());
                usuarioBE.Nombre = reg["nombre"].ToString();
                usuarioBE.Apellido = reg["apellido"].ToString();
                usuarioBE.Empresa = Convert.ToInt32(reg["id_empresa"].ToString());
                
                usuarioBE.Telefono = reg["telefono"].ToString();
                usuarioBE.Email = reg["email"].ToString();
                usuarioBE.Borrado = reg["borrado"].ToString();
                Familia_BE tipoUsuario = new Familia_BE();
                tipoUsuario.id = Convert.ToInt32(reg["familia"].ToString());
                tipoUsuario.familia = reg["detalle"].ToString();
                usuarioBE.Familia = tipoUsuario;
                usuarioBE.Bloqueado = Convert.ToInt32(reg["bloqueado"].ToString());

            }
            return usuarioBE;
        }

        public void cambiar_familia(int usuario, int perfil)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@usu";
            parametros[0].DbType = DbType.Int16;
            parametros[0].Value = usuario;
            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@familia";
            parametros[1].DbType = DbType.Int16;
            parametros[1].Value = perfil;

            DataTable Tabla = ac.ejecutar_stored_procedure("cambiar_familia", parametros);
        }

        public void blanquear_password(string usuario)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@usu";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = usuario;

            DataTable Tabla = ac.ejecutar_stored_procedure("blanquear_password", parametros);

        }

        public List<Usuario_BE> listar_usuarios_bloqueados()
        {
            List<Usuario_BE> usuariosBloqueados = new List<Usuario_BE>();

            DataTable Tabla = ac.ejecutar_stored_procedure("listar_usuariosBloqueados", null);
            foreach (DataRow reg in Tabla.Rows)
            {
                Usuario_BE usuario = new Usuario_BE();
                usuario.Usuario = reg["usuario"].ToString();
                usuariosBloqueados.Add(usuario);
            }
            return usuariosBloqueados;
        }

        public void desbloquear_usuario(string usuario)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@usu";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = usuario;

            DataTable Tabla = ac.ejecutar_stored_procedure("desbloquear_usuario", parametros);
        }

        public void recuperar_password(Usuario_BE usuario)
        {
            string nuevapass = Servicio.GeneradorClave.CrearRandomContrasenia();

            usuario.Contraseña = nuevapass;
            cambiar_password(usuario);
            Servicio.GeneradorClave.EnviarNuevaContrasenia(nuevapass, usuario.Email);
        }

        public void cambiar_password(Usuario_BE usuario)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@usu";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = usuario.Usuario;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@pass";
            parametros[1].DbType = DbType.String;
            parametros[1].Value = Servicio.Encriptacion.Calcular_HashSHA256(usuario.Contraseña);

            DataTable Tabla = ac.ejecutar_stored_procedure("cambiar_password", parametros);
        }

        public void borrar_usuario(Usuario_BE usuario)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@usu";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = usuario.Usuario;

            DataTable Tabla = ac.ejecutar_stored_procedure("borrar_usuario", parametros);
        }

        public void restaurar_usuario(Usuario_BE usuario)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@usu";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = usuario.Usuario;

            DataTable Tabla = ac.ejecutar_stored_procedure("restaurar_usuario", parametros);
        }

        public Usuario_BE validar_usuario_email(string email)
        {

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@email";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = email;


            DataTable Tabla = ac.ejecutar_stored_procedure("validar_usuario_email", parametros);

            Usuario_BE usuarioBE = new Usuario_BE();

            foreach (DataRow reg in Tabla.Rows)
            {

                usuarioBE.Usuario = reg["usuario"].ToString();
                usuarioBE.Contraseña = reg["contraseña"].ToString();
                usuarioBE.IdUsuario = Convert.ToInt32(reg["id"].ToString());
                usuarioBE.Nombre = reg["nombre"].ToString();
                usuarioBE.Apellido = reg["apellido"].ToString();
                usuarioBE.Empresa = Convert.ToInt32(reg["id_empresa"].ToString());
                
                usuarioBE.Telefono = reg["telefono"].ToString();
                usuarioBE.Email = email;
                usuarioBE.Borrado = reg["borrado"].ToString();
                Familia_BE tipoUsuario = new Familia_BE();
                tipoUsuario.id = Convert.ToInt32(reg["familia"].ToString());
                tipoUsuario.familia = reg["detalle"].ToString();
                usuarioBE.Familia = tipoUsuario;
                usuarioBE.Bloqueado = Convert.ToInt32(reg["bloqueado"].ToString());

            }
            return usuarioBE;

            
        }

        public List<Usuario_BE> listar_usuarios_dictado(int id_dictado)
        {

            List<Usuario_BE> usuarios = new List<Usuario_BE>();

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id_dictado";
            parametros[0].DbType = DbType.Int32;
            parametros[0].Value = id_dictado;
            DataTable Tabla = ac.ejecutar_stored_procedure("listar_usuarios_dictado", parametros);
            foreach (DataRow reg in Tabla.Rows)
            {
                Usuario_BE usuarioBE = new Usuario_BE();
                usuarioBE.Usuario = reg["usuario"].ToString();
                usuarioBE.Contraseña = reg["contraseña"].ToString();
                usuarioBE.IdUsuario = Convert.ToInt32(reg["id"].ToString());
                usuarioBE.Nombre = reg["nombre"].ToString();
                usuarioBE.Apellido = reg["apellido"].ToString();
                usuarioBE.Empresa = Convert.ToInt32(reg["id_empresa"].ToString());

                usuarioBE.Telefono = reg["telefono"].ToString();
                usuarioBE.Email = reg["email"].ToString();
                usuarioBE.Borrado = reg["borrado"].ToString();
                usuarioBE.Bloqueado = int.Parse(reg["bloqueado"].ToString());
                Familia_BE tipoUsuario = new Familia_BE();
                tipoUsuario.id = Convert.ToInt32(reg["familia"].ToString());
                tipoUsuario.familia = reg["detalle"].ToString();
                usuarioBE.Familia = tipoUsuario;
                usuarios.Add(usuarioBE);
            }
            return usuarios;
        }

        #region private functions

        #endregion
    }
}
