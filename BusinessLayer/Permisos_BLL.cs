using BusinessEntity.Composite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BusinessLayer
{
    public class Permisos_BLL
    {

        Permisos_DAL mapper = new Permisos_DAL();
        public List<Familia_BE> ListarFamilias()
        {
            return mapper.listar_familias();
        }

        public List<Patente_BE> ListarPatentes()
        {
            return mapper.listar_acciones();
        }

        public void AgregarPatenteFamilia(int permiso, int accion)
        {
            mapper.agregar_patente_familia(permiso, accion);
        }

        public void BorrarPatenteFamilia(int permiso, int accion)
        {
            mapper.eliminar_patente_familia(permiso, accion);
        }

        public void AgregarFamilia(string nombre)
        {
            mapper.agregar_familia(nombre);
        }
    }
}
