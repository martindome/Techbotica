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

        public void NuevaEmpresa(Empresa_BE empresa)
        {
            mapper.nueva_empresa(empresa);
        }

        public void ActualizarEmpresa(Empresa_BE empresabe)
        {
            mapper.actualizar_empresa(empresabe);
        }

        public void NuevoDominio(Dominio_BE newDomain)
        {
            mapper.nuevo_dominio(newDomain);
        }

        public void EliminarDominio(int domainId)
        {
            mapper.eliminar_dominio(domainId);
        }

        public void EliminarEmpresa(Empresa_BE empresabe)
        {
            mapper.eliminar_empresa(empresabe);
        }

        public List<Usuario_BE> ObtenerUsuariosEmpresa(int id)
        {
            Usuario_BLL userBLL = new Usuario_BLL();
            List<Usuario_BE> usuarios = userBLL.ListarUsuarios();

            // for usuarios if empresa.id == id then add to list
            List<Usuario_BE> usuariosEmpresa = new List<Usuario_BE>();
            foreach (Usuario_BE usuario in usuarios)
            {
                if (usuario.Empresa == id && usuario.Borrado == "No")
                {
                    usuariosEmpresa.Add(usuario);
                }
            }
            return usuariosEmpresa;
        }
    }
}
