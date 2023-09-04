using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Composite
{
    [Serializable]
    public abstract class Compuesto_BE
    {
        public string Nombre { get; set; }
        public int ID_Compuesto { get; set; }
        public string Descripcion { get; set; }

        public abstract void AgregarPatente(Compuesto_BE p);

        public abstract void QuitarPatente(Compuesto_BE p);

        public abstract List<Compuesto_BE> ObtenerHijos();

        public override string ToString()
        {
            return this.Nombre;
        }
    }
}
