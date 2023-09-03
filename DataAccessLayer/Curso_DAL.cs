using BusinessEntity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Curso_DAL
    {
        Acceso_DAL ac = new Acceso_DAL();
        public List<Curso_BE> listar_cursos()
        {
            List<Curso_BE> cursos = new List<Curso_BE>();

            DataTable Tabla = ac.ejecutar_stored_procedure("listar_cursos", null);
            foreach (DataRow reg in Tabla.Rows)
            {
                Curso_BE cursoBE = new Curso_BE();
                mappear_curso(reg, cursoBE);
                cursos.Add(cursoBE);
            }
            return cursos;
        }

        public void nuevo_curso(Curso_BE curso)
        {

            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@nombre";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = curso.Nombre;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@descripcion";
            parametros[1].DbType = DbType.String;
            parametros[1].Value = curso.Descripcion;

            parametros[2] = new SqlParameter();
            parametros[2].ParameterName = "@especialidad";
            parametros[2].DbType = DbType.Int32;
            parametros[2].Value = curso.Especialidad;

            DataTable Tabla = ac.ejecutar_stored_procedure("nuevo_curso", parametros);

            foreach (DataRow reg in Tabla.Rows)
            {
                curso.Id = Convert.ToInt32(reg["id"].ToString());
            }
        }

        public void actualizar_curso(Curso_BE cursobe)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@nombre";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = cursobe.Nombre;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@descripcion";
            parametros[1].DbType = DbType.String;
            parametros[1].Value = cursobe.Descripcion;

            parametros[2] = new SqlParameter();
            parametros[2].ParameterName = "@id";
            parametros[2].DbType = DbType.Int32;
            parametros[2].Value = cursobe.Id;

            parametros[3] = new SqlParameter();
            parametros[3].ParameterName = "@especialidad";
            parametros[3].DbType = DbType.Int32;
            parametros[3].Value = cursobe.Especialidad;

            DataTable Tabla = ac.ejecutar_stored_procedure("actualizar_curso", parametros);
        }

        public void eliminar_curso(Curso_BE cursobe)
        {

            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id";
            parametros[0].DbType = DbType.Int32;
            parametros[0].Value = cursobe.Id;

            ac.ejecutar_stored_procedure("eliminar_curso", parametros);

        }

        private void mappear_curso(DataRow reg, Curso_BE e)
        {
            e.Id = Convert.ToInt32(reg["id"].ToString());
            e.Nombre = reg["nombre"].ToString();
            e.Descripcion = reg["descripcion"].ToString();
            e.Especialidad = Convert.ToInt32(reg["id_especialidad"].ToString());
        }

        public List<Curso_BE> listar_cursos_carrera(int id)
        {
            List<Curso_BE> cursos  = new List<Curso_BE>();
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id";
            parametros[0].DbType = DbType.Int32;
            parametros[0].Value = id;

            DataTable Tabla = ac.ejecutar_stored_procedure("listar_cursos_carrera", parametros);

            foreach (DataRow reg in Tabla.Rows)
            {
                Curso_BE c = new Curso_BE();
                mappear_curso(reg, c);
                cursos.Add(c);
            }
            return cursos;
        }
    }
}
