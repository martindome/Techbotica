using BusinessEntity;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class Especialidad_BLL
    {
        Especialidad_DAL mapper = new Especialidad_DAL();
        public List<Especialidad_BE> ListarEspecialidades()
        {
            return mapper.listar_especilidades();
        }
    }
}
