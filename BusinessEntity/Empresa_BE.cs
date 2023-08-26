using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity
{
    public class Empresa_BE
    {
        public int IdEmpresa { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Borrado { get; set; }
        public List<Dominio_BE> Dominios { get; set; }
    }
}
