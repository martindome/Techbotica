using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntity;
using BusinessEntity.Composite;

namespace BusinessEntity
{
    public class Usuario_BE
    {
        public int IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public int Empresa { get; set; }
        public string Borrado { get; set; }
        // Agregado para el bloqueo por reintentos
        public int Bloqueado { get; set; }
        public Especialidad_BE Especialidad { get; set; }
        public Familia_BE Familia { get; set; }
        //Composite
        public List<Compuesto_BE> Patentes { get; set; }
        public Usuario_BE()
        {
            Patentes = new List<Compuesto_BE>();
        }
        public Usuario_BE(int pId)
        {
            IdUsuario = pId;
            Patentes = new List<Compuesto_BE>();
        }
    }
}
