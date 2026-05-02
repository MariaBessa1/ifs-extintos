using Extintos.Enumeration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extintos.Model
{
    internal class DecisoesTurno
    {
        public List<AuxDinossauro> Mao { get; set; }
        public List<AuxCercado> Cercados { get; set; }
        public Dado DadoAtual { get; set; }
        public int NumeroTurno { get; set; }
        public bool JogueioDado { get; set; }
    }

    //informações gerais que nosso joguinho precisa pra decidir qual estrategia usar. Precisa da mão, dos cercados, dado atual, turno e se eu joguei o dado.
}
