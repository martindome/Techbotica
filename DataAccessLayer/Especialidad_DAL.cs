using BusinessEntity;
using BusinessEntity.Composite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Especialidad_DAL
    {
        Acceso_DAL ac = new Acceso_DAL();
        public List<Especialidad_BE> listar_especilidades()
        {
            List<Especialidad_BE> tipos = new List<Especialidad_BE>();

            DataTable Tabla = ac.ejecutar_stored_procedure("listar_especialidades", null);
            foreach (DataRow reg in Tabla.Rows)
            {
                Especialidad_BE detalle = new Especialidad_BE();
                mapearEspecialidad(reg, detalle);
                tipos.Add(detalle);
            }
            return tipos;
        }

        private void mapearEspecialidad (DataRow reg, Especialidad_BE b)
        {
            b.IdEspecialidad = Convert.ToInt32(reg["id"].ToString());
            b.Nombre = reg["nombre"].ToString();
            b.Descripcion = reg["descripcion"].ToString();
        }
    }
}
