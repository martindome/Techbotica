using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Dictado_DAL
    {
        Acceso_DAL ac = new Acceso_DAL();

        public List<Dictado_BE> listar_dictados()
        {
            List<Dictado_BE> dictados = new List<Dictado_BE>();

            DataTable Tabla = ac.ejecutar_stored_procedure("listar_dictados", null);
            foreach (DataRow reg in Tabla.Rows)
            {
                Dictado_BE dictadoBE = new Dictado_BE();
                mappear_dictado(reg, dictadoBE);
                dictados.Add(dictadoBE);
            }
            return dictados;
        }

        public void nuevo_dictado(Dictado_BE dictado)
        {

            SqlParameter[] parametros = new SqlParameter[6];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@fecha_inicio";
            parametros[0].DbType = DbType.Date;
            parametros[0].Value = dictado.FechaInicio;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@fecha_fin";
            parametros[1].DbType = DbType.Date;
            parametros[1].Value = dictado.FechaFin;

            parametros[2] = new SqlParameter();
            parametros[2].ParameterName = "@enlace";
            parametros[2].DbType = DbType.String;
            parametros[2].Value = dictado.Enlace;

            parametros[3] = new SqlParameter();
            parametros[3].ParameterName = "@tipo_dictado";
            parametros[3].DbType = DbType.Int32;
            parametros[3].Value = dictado.TipoDictado == "Autodirigido" ? 1 : 2;

            parametros[4] = new SqlParameter();
            parametros[4].ParameterName = "@curso";
            parametros[4].DbType = DbType.Int32;
            parametros[4].Value = dictado.Curso.Id;

            parametros[5] = new SqlParameter();
            parametros[5].ParameterName = "@cupo";
            parametros[5].DbType = DbType.Int32;
            parametros[5].Value = dictado.Cupo;

            DataTable Tabla = ac.ejecutar_stored_procedure("nuevo_dictado", parametros);

            foreach (DataRow reg in Tabla.Rows)
            {
                dictado.Id = Convert.ToInt32(reg["id"].ToString());
            }
            foreach (Horario_BE h in dictado.Horarios)
            {
                h.Dictado.Id = dictado.Id;
                nuevo_horario(h);
            }
            foreach (Usuario_BE u in dictado.Tutores)
            {
                agregar_usuario_dictado(dictado.Id, u.IdUsuario);
            }
        }

        public void actualizar_dictado(Dictado_BE dictado)
        {
            SqlParameter[] parametros = new SqlParameter[6];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@fecha_inicio";
            parametros[0].DbType = DbType.Date;
            parametros[0].Value = dictado.FechaInicio;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@fecha_fin";
            parametros[1].DbType = DbType.Date;
            parametros[1].Value = dictado.FechaFin;

            parametros[2] = new SqlParameter();
            parametros[2].ParameterName = "@enlace";
            parametros[2].DbType = DbType.String;
            parametros[2].Value = dictado.Enlace;

            parametros[3] = new SqlParameter();
            parametros[3].ParameterName = "@tipo_dictado";
            parametros[3].DbType = DbType.Int32;
            parametros[3].Value = dictado.TipoDictado == "Autodirigido" ? 1 : 2;

            parametros[4] = new SqlParameter();
            parametros[4].ParameterName = "@id";
            parametros[4].DbType = DbType.Int32;
            parametros[4].Value = dictado.Id;

            parametros[5] = new SqlParameter();
            parametros[5].ParameterName = "@cupo";
            parametros[5].DbType = DbType.Int32;
            parametros[5].Value = dictado.Cupo;

            DataTable Tabla = ac.ejecutar_stored_procedure("actualizar_dictado", parametros);
        }

        public void eliminar_dictado(Dictado_BE dictadobe)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id";
            parametros[0].DbType = DbType.Int32;
            parametros[0].Value = dictadobe.Id;

            ac.ejecutar_stored_procedure("eliminar_dictado", parametros);
        }

        public void nuevo_horario(Horario_BE horario)
        {

            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@hora_inicio";
            parametros[0].SqlDbType = SqlDbType.Time;
            parametros[0].Value = horario.HoraInicio;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@hora_fin";
            parametros[1].SqlDbType = SqlDbType.Time;
            parametros[1].Value = horario.HoraFin;

            parametros[2] = new SqlParameter();
            parametros[2].ParameterName = "@dia";
            parametros[2].DbType = DbType.String;
            parametros[2].Value = horario.Dia;

            parametros[3] = new SqlParameter();
            parametros[3].ParameterName = "@dictado";
            parametros[3].DbType = DbType.Int32;
            parametros[3].Value = horario.Dictado.Id;

            DataTable Tabla = ac.ejecutar_stored_procedure("nuevo_horario", parametros);

            foreach (DataRow reg in Tabla.Rows)
            {
                horario.Id = Convert.ToInt32(reg["id"].ToString());
            }
        }

        public void actualizar_horario(Horario_BE horario)
        {

            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@hora_inicio";
            parametros[0].SqlDbType = SqlDbType.Time;
            parametros[0].Value = horario.HoraInicio;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@hora_fin";
            parametros[1].SqlDbType = SqlDbType.Time;
            parametros[1].Value = horario.HoraFin;

            parametros[2] = new SqlParameter();
            parametros[2].ParameterName = "@dia";
            parametros[2].DbType = DbType.String;
            parametros[2].Value = horario.Dia;

            parametros[3] = new SqlParameter();
            parametros[3].ParameterName = "@id";
            parametros[3].DbType = DbType.Int32;
            parametros[3].Value = horario.Id;

            DataTable Tabla = ac.ejecutar_stored_procedure("actualizar_horario", parametros);

            foreach (DataRow reg in Tabla.Rows)
            {
                horario.Id = Convert.ToInt32(reg["id"].ToString());
            }
        }

        public void eliminar_horario(Horario_BE horariobe)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id";
            parametros[0].DbType = DbType.Int32;
            parametros[0].Value = horariobe.Id;

            ac.ejecutar_stored_procedure("eliminar_horario", parametros);
        }

        public void agregar_usuario_dictado(int dictado_id, int usuario_id)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id_usuario";
            parametros[0].DbType = DbType.Int32;
            parametros[0].Value = usuario_id;
            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@id_dictado";
            parametros[1].DbType = DbType.Int32;
            parametros[1].Value = dictado_id;

            ac.ejecutar_stored_procedure("nuevo_usuario_dictado", parametros);
        }

        public void eliminar_usuario_dictado(int dictado_id, int usuario_id)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id_usuario";
            parametros[0].DbType = DbType.Int32;
            parametros[0].Value = usuario_id;
            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@id_dictado";
            parametros[1].DbType = DbType.Int32;
            parametros[1].Value = dictado_id;

            ac.ejecutar_stored_procedure("eliminar_usuario_dictado", parametros);
        }

        public List<Horario_BE> listar_horarios_dictado(int id_dictado)
        {
            List<Horario_BE> horarios = new List<Horario_BE>();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id_curso";
            parametros[0].DbType = DbType.Int32;
            parametros[0].Value = id_dictado;

            DataTable Tabla = ac.ejecutar_stored_procedure("listar_horarios_dictado", parametros);
            foreach (DataRow reg in Tabla.Rows)
            {
                Horario_BE horarioBE = new Horario_BE();
                mapper_horario(reg, horarioBE);
                horarios.Add(horarioBE);
            }
            return horarios;
        }

        public List<Dictado_BE> listar_dictados_curso(int id)
        {
            List<Dictado_BE> dictados = new List<Dictado_BE>();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id";
            parametros[0].DbType = DbType.Int32;
            parametros[0].Value = id;

            DataTable Tabla = ac.ejecutar_stored_procedure("listar_dictados_curso", parametros);

            foreach (DataRow reg in Tabla.Rows)
            {
                Dictado_BE c = new Dictado_BE();
                mappear_dictado(reg, c);
                dictados.Add(c);
            }
            return dictados;
        }

        private void mappear_dictado(DataRow reg, Dictado_BE e)
        {
            e.Id = Convert.ToInt32(reg["id"].ToString());
            e.Cupo = Convert.ToInt32(reg["cupo"].ToString());
            e.FechaInicio = DateTime.Parse(reg["fecha_inicio"].ToString());
            e.FechaFin = DateTime.Parse(reg["fecha_fin"].ToString());
            e.Enlace = reg["enlace"].ToString();
            e.TipoDictado = reg["tipo_dictado"].ToString();
            e.Curso = new Curso_DAL().listar_cursos().FirstOrDefault(es => es.Id == Convert.ToInt32(reg["id_curso"].ToString()));
            e.Horarios = new List<Horario_BE>();
            e.Tutores = new List<Usuario_BE>();
            foreach (Horario_BE h in listar_horarios_dictado(e.Id))
            {
                h.Dictado = e;
                e.Horarios.Add(h);
            }
            e.Tutores = new Usuario_DAL().listar_usuarios_dictado(e.Id);
        }

        private void mapper_horario(DataRow reg, Horario_BE e)
        {
            e.Id = Convert.ToInt32(reg["id"].ToString());
            e.Dia = reg["dia"].ToString();
            e.HoraInicio = TimeSpan.Parse(reg["hora_inicio"].ToString());
            e.HoraFin = TimeSpan.Parse(reg["hora_fin"].ToString());
        }

        public List<Dictado_BE> listar_dictados_por_tutor(int idUsuario)
        {
            List < Dictado_BE > dictados = listar_dictados();

            return dictados.Where(d => d.Tutores.Any(t => t.IdUsuario == idUsuario)).ToList();

        }
    }
}
