using System.Collections.Generic;

namespace Extintos.Enumeration
{
    public class AuxCercado
    {
        public Cercados Cercados  { get; set; }
        
        public List<Dinossauro> Dinossauros { get; } =  new List<Dinossauro>();


        public AuxCercado(Cercados cercados)
        {
            Cercados = cercados;
        }
        
    }
}