using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntity.Composite
{
    [Serializable]
    public class Familia_BE : Compuesto_BE
    {

        //private List<Compuesto_BE> listaAcciones;
        public int id { get; set; }
        public string familia { get; set; }
        public List<Compuesto_BE> listaPatentes { get; set; }

        public Familia_BE()
        {
            listaPatentes = new List<Compuesto_BE>();
        }

        public override void AgregarPatente(Compuesto_BE p)
        {
            if (!listaPatentes.Contains(p))
            {
                listaPatentes.Add(p);
            }
        }

        public override List<Compuesto_BE> ObtenerHijos()
        {
            return this.listaPatentes;
        }

        public override void QuitarPatente(Compuesto_BE p)
        {
            if (this.listaPatentes.Any(item => item.ID_Compuesto == p.ID_Compuesto && item.Nombre == p.Nombre))
            {
                List<Compuesto_BE> aux = new List<Compuesto_BE>();
                foreach (Compuesto_BE comp in this.ObtenerHijos())
                {
                    if (comp.ID_Compuesto != p.ID_Compuesto)
                    {
                        aux.Add(comp);
                    }
                }
                this.listaPatentes = aux;
            }
        }

    }
}
