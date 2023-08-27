using BusinessEntity;
using BusinessEntity.Composite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Empresa_DAL
    {
        Acceso_DAL ac = new Acceso_DAL();

        public List<Empresa_BE> listar_empresas()
        {
            List<Empresa_BE> empresas = new List<Empresa_BE>();

            DataTable Tabla = ac.ejecutar_stored_procedure("listar_empresas", null);
            foreach (DataRow reg in Tabla.Rows)
            {
                Empresa_BE empresaBE = new Empresa_BE();
                mappear_empresa(reg,empresaBE);
                List<Dominio_BE> dominios = listar_dominios_empresa(empresaBE.IdEmpresa);
                foreach (Dominio_BE dominioBE in dominios)
                {
                    empresaBE.Dominios.Add(dominioBE);
                }
                empresas.Add(empresaBE);
            }
            return empresas;
        }

        public List<Dominio_BE> listar_dominios_empresa(int id_empresa)
        {
            SqlParameter[] parametros = new SqlParameter[1];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@id_empresa";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = id_empresa;

            DataTable Tabla = ac.ejecutar_stored_procedure("listar_dominios_empresa", parametros);

            List<Dominio_BE> dominios = new List<Dominio_BE>();

            foreach (DataRow reg in Tabla.Rows)
            {
                Dominio_BE d = new Dominio_BE();
                mappear_dominio(reg, d);
                dominios.Add(d);
            }
            return dominios;
        }

        public void nueva_empresa(Empresa_BE empresa)
        {

            SqlParameter[] parametros = new SqlParameter[5];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@nombre";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = empresa.Nombre;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@descripcion";
            parametros[1].DbType = DbType.String;
            parametros[1].Value = empresa.Descripcion;

            parametros[2] = new SqlParameter();
            parametros[2].ParameterName = "@telefono";
            parametros[2].DbType = DbType.String;
            parametros[2].Value = empresa.Telefono;

            parametros[3] = new SqlParameter();
            parametros[3].ParameterName = "@email";
            parametros[3].DbType = DbType.String;
            parametros[3].Value = empresa.Email;

            parametros[4] = new SqlParameter();
            parametros[4].ParameterName = "@borrado";
            parametros[4].DbType = DbType.String;
            parametros[4].Value = empresa.Borrado;
            DataTable Tabla = ac.ejecutar_stored_procedure("nueva_empresa", parametros);

            foreach (DataRow reg in Tabla.Rows)
            {
                empresa.IdEmpresa = Convert.ToInt32(reg["id"].ToString());
            }

            foreach (Dominio_BE d in empresa.Dominios)
            {
                d.IdEmpresa = empresa.IdEmpresa;
                nuevo_dominio(d);
            }
        }

        public void nuevo_dominio (Dominio_BE d)
        {
            SqlParameter[] parametros = new SqlParameter[3];
            parametros[0] = new SqlParameter();
            parametros[0].ParameterName = "@sufijo";
            parametros[0].DbType = DbType.String;
            parametros[0].Value = d.Sufijo;

            parametros[1] = new SqlParameter();
            parametros[1].ParameterName = "@id_empresa";
            parametros[1].DbType = DbType.Int32;
            parametros[1].Value = d.IdEmpresa;

            parametros[2] = new SqlParameter();
            parametros[2].ParameterName = "@borrado";
            parametros[2].DbType = DbType.String;
            parametros[2].Value = d.Borrado;

            DataTable Tabla = ac.ejecutar_stored_procedure("nuevo_dominio", parametros);
        }

        private void mappear_empresa(DataRow reg, Empresa_BE e)
        {
            e.IdEmpresa = Convert.ToInt32(reg["id"].ToString());
            e.Nombre = reg["nombre"].ToString();
            e.Descripcion = reg["descripcion"].ToString();
            e.Telefono = reg["telefono"].ToString();
            e.Email = reg["email"].ToString();
            e.Dominios = new List<Dominio_BE>();
        }

        private void mappear_dominio(DataRow reg,  Dominio_BE e)
        {
            e.IdDominio = Convert.ToInt32(reg["id"].ToString());
            e.Sufijo = reg["sufijo"].ToString();
            e.IdDominio = Convert.ToInt32(reg["id_empresa"].ToString());
        }
    }
}
