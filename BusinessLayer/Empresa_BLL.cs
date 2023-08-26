using BusinessEntity;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Empresa_BLL
    {
        Empresa_DAL mapper = new Empresa_DAL();
        public List<Empresa_BE> ListarEmpresas()
        {
            return mapper.listar_empresas();
        }

        public List<Dominio_BE> ListarDominiosEmpresa(int id)
        {
            return mapper.listar_dominios_empresa(id);
        }
    }
}
