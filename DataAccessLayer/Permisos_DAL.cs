using BusinessEntity.Composite;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Permisos_DAL
    {
        Acceso_DAL ac = new Acceso_DAL();
        public List<Familia_BE> listar_familias()
        {
            List<Familia_BE> tipos = new List<Familia_BE>();

            DataTable Tabla = ac.ejecutar_stored_procedure("listar_familias", null);
            foreach (DataRow reg in Tabla.Rows)
            {
                Familia_BE detalle = new Familia_BE();
                detalle.id = Convert.ToInt32(reg["id"].ToString());
                detalle.familia = reg["familia"].ToString();
                detalle.listaPatentes = this.buscar_familia_patente(detalle.id);
                tipos.Add(detalle);
            }
            return tipos;
        }

        public List<Compuesto_BE> buscar_familia_patente(int familia)
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

        public List<Patente_BE> listar_acciones()
        {

            List<Patente_BE> acciones = new List<Patente_BE>();
            DataTable Tabla = ac.ejecutar_stored_procedure("listar_patentes_todas", null);
            foreach (DataRow reg in Tabla.Rows)
            {
                Patente_BE accion = new Patente_BE();
                accion.id = Convert.ToInt32(reg["id"].ToString());
                accion.detalle = reg["detalle"].ToString();
                acciones.Add(accion);
            }
            return acciones;
        }

        public void eliminar_patente_familia(int familia, int patente)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@familia";
            parametros[0].DbType = DbType.Int16;
            parametros[0].Value = familia;
            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@patente";
            parametros[1].DbType = DbType.Int16;
            parametros[1].Value = patente;
            DataTable Tabla = ac.ejecutar_stored_procedure("eliminar_familia_patente", parametros);
        }

        public void agregar_patente_familia(int familia, int patente)
        {
            SqlParameter[] parametros = new SqlParameter[2];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@familia";
            parametros[0].DbType = DbType.Int16;
            parametros[0].Value = familia;
            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@patente";
            parametros[1].DbType = DbType.Int16;
            parametros[1].Value = patente;
            DataTable Tabla = ac.ejecutar_stored_procedure("agregar_familia_patente", parametros);
        }

        public void agregar_familia(string nombre)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@detalle";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = nombre;
            DataTable Tabla = ac.ejecutar_stored_procedure("agregar_familia", parametros);
        }

        public void eliminar_familia(Familia_BE familia)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id";
            parametros[0].DbType = DbType.Int32;
            parametros[0].Value = familia.id;
            DataTable Tabla = ac.ejecutar_stored_procedure("eliminar_familia", parametros);
        }

        public List<Patente_BE> listar_familia_patente(int familia)
        {
            throw new NotImplementedException();
        }

        #region private functions

        #endregion


    }
}
