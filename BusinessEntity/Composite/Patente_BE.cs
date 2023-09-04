using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Composite
{
    [Serializable]
    public class Patente_BE : Compuesto_BE
    {
        public int id { get; set; }
        public string detalle { get; set; }

        public override void AgregarPatente(Compuesto_BE p)
        {
            throw new NotImplementedException();
        }

        public override void QuitarPatente(Compuesto_BE p)
        {
            throw new NotImplementedException();
        }

        public override List<Compuesto_BE> ObtenerHijos()
        {
            return new List<Compuesto_BE>();
        }
    }
}
