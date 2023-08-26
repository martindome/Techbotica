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

        private void mappear_empresa(DataRow reg, Empresa_BE e)
        {
            e.IdEmpresa = Convert.ToInt32(reg["id"].ToString());
            e.Nombre = reg["nombre"].ToString();
            e.Descripcion = reg["descripcion"].ToString();
        }

        private void mappear_dominio(DataRow reg,  Dominio_BE e)
        {
            e.IdDominio = Convert.ToInt32(reg["id"].ToString());
            e.Sufijo = reg["sufijo"].ToString();
            e.IdDominio = Convert.ToInt32(reg["id_empresa"].ToString());
        }
    }
}
