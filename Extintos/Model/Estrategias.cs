using Extintos.Enumeration;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extintos.Model
{
    internal class Estrategias
    {

        //FUNÇÕES QUE UTILIZAMOS NO FLUXO------------------------------------------------------------------------------------------------------------
        private bool TenhoDinoReiDaSelva(DecisoesTurno decisoes) // função para ver se temos o rei da selva na mao (usada laaa nos if)
        {
            var cercadoEspecifico = decisoes.Cercados.Find(c => c.Cercados == Cercados.RS);

            if (cercadoEspecifico == null || cercadoEspecifico.Dinossauros.Count == 0)
                return false;

            var dinoRS = cercadoEspecifico.Dinossauros[0];

            return decisoes.Mao.Exists(d =>
                d.Dinossauro == dinoRS && d.QuantidadeDinossauros > 0);
        }

        private bool PossoColocarNoCercado(DecisoesTurno decisoes, Cercados cercado, Dinossauro dino)
        {
            var cercadoEspecifico = decisoes.Cercados.Find(c => c.Cercados == cercado);

            if (cercadoEspecifico == null)
                return false;

            return cercado.SePodeAdicionar(
                cercadoEspecifico.Dinossauros.ConvertAll(x => x.PegaCodigo()),
                dino.PegaCodigo()
            );
        }

        private bool TemDinoNoCercado(DecisoesTurno estado, Cercados cercado) //Usado principalmente pra campina da diferença :D
        {
            var cercadoEspecifico = estado.Cercados.Find(c => c.Cercados == cercado);

            return cercadoEspecifico != null && cercadoEspecifico.Dinossauros.Count > 0;
        }

        //ESTRATEGIA REI DA SELVA-------------------------------------------------------------------------------------------------------------------
        public (Dinossauro, Cercados) ReidaSelva(DecisoesTurno decisoes)
        {

            //PRIMEIRO TURNO::

                    if (decisoes.NumeroTurno == 1)
                    {
                        if(decisoes.JogueioDado) //Jogamos o dado
                        {

                            //Verificação para jogarmos um dino em menor quantidade no Rei da Selva (que não seja o TI)
                            AuxDinossauro menorQuantidade = null;

                            foreach (var d in decisoes.Mao)
                            {
                                if (d.QuantidadeDinossauros == 0)
                                    continue;

                                if (d.Dinossauro == Dinossauro.TI)
                                    continue;

                                if (menorQuantidade == null || d.QuantidadeDinossauros <= menorQuantidade.QuantidadeDinossauros)
                                {
                                    menorQuantidade = d;
                                }
                            }

                            if (menorQuantidade!= null)
                            {
                                var colocaRS = decisoes.Cercados.Find(c => c.Cercados == Cercados.RS);

                                if (colocaRS != null && colocaRS.Dinossauros.Count == 0)
                                {
                                    return (menorQuantidade.Dinossauro, Cercados.RS);
                                }
                            }
                        }

                        if(!decisoes.JogueioDado &&
                            (decisoes.DadoAtual == Dado.FL||
                             decisoes.DadoAtual == Dado.WC||
                             decisoes.DadoAtual == Dado.VZ||
                             decisoes.DadoAtual == Dado.TI)) //Não jogamos o dado E caiu em dados pra aplicar a logica RS
                        {
                            //Verificação para jogarmos um dino em menor quantidade no Rei da Selva (que não seja o TI)
                            AuxDinossauro menorQuantidade = null;

                            foreach (var d in decisoes.Mao)
                            {
                                if (d.QuantidadeDinossauros == 0)
                                    continue;

                                if (d.Dinossauro == Dinossauro.TI)
                                    continue;

                                if (menorQuantidade == null || d.QuantidadeDinossauros <= menorQuantidade.QuantidadeDinossauros)
                                {
                                    menorQuantidade = d;
                                }
                            }

                            if (menorQuantidade != null)
                            {
                                var colocaRS = decisoes.Cercados.Find(c => c.Cercados == Cercados.RS);

                                if (colocaRS != null && colocaRS.Dinossauros.Count == 0)
                                {
                                    return (menorQuantidade.Dinossauro, Cercados.RS);
                                }
                            }
                        }

                        else //Caso o dado tenha caído PL ou AL
                        {

                        }
       
                    }
               //OUTROS TURNOS::
                    else
                    {
                        if (decisoes.JogueioDado) //JOGAMOS O DADO
                        {
                            if (TenhoDinoReiDaSelva(decisoes))
                            {
                                var cercadoEspecificoRS = decisoes.Cercados.Find(c => c.Cercados == Cercados.RS);
                                var dinoReiSelva = cercadoEspecificoRS.Dinossauros[0];


                                if (PossoColocarNoCercado(decisoes, Cercados.FI, dinoReiSelva))
                                    return (dinoReiSelva, Cercados.FI);


                                if (PossoColocarNoCercado(decisoes, Cercados.PA, dinoReiSelva))
                                    return (dinoReiSelva, Cercados.PA);
                            }
                            else //nao tenho o dino rei da selva
                            {

                                if (!TemDinoNoCercado(decisoes, Cercados.CD)) //Campina da diferença ta vazio?
                                {
                                    foreach (var d in decisoes.Mao) //procura algum dino para colocar 
                                    {
                                        if (d.QuantidadeDinossauros == 0)
                                            continue;

                                        if (d.Dinossauro == Dinossauro.TI)
                                            continue;

                                        if (PossoColocarNoCercado(decisoes, Cercados.CD, d.Dinossauro))
                                            return (d.Dinossauro, Cercados.CD);
                                    }
                                }
                                else  //Campina da diferença nao ta vazio
                                {
                                    var cercadoEspecificoCD = decisoes.Cercados.Find(c => c.Cercados == Cercados.CD);

                                    if (cercadoEspecificoCD != null)
                                    {
                                        foreach (var d in decisoes.Mao) //procura algum dino para colocar 
                                        {
                                            if (d.QuantidadeDinossauros == 0)
                                                continue;

                                            if (d.Dinossauro == Dinossauro.TI)
                                            {
                                                if (PossoColocarNoCercado(decisoes, Cercados.IS, d.Dinossauro))
                                                    return (d.Dinossauro, Cercados.IS);

                                                continue;

                                            }

                                            if (!cercadoEspecificoCD.Dinossauros.Contains(d.Dinossauro) &&
                                                PossoColocarNoCercado(decisoes, Cercados.CD, d.Dinossauro)) //Temos na mão algum outro dino que dê pra colocar na CD?
                                            {
                                                return (d.Dinossauro, Cercados.CD);
                                            }

                                        }
                                        foreach (var d in decisoes.Mao) //Se não tivermos, colocar em MT
                                        {
                                            if (d.QuantidadeDinossauros == 0)
                                                continue;

                                            if (d.Dinossauro == Dinossauro.TI)
                                                continue;

                                            if (PossoColocarNoCercado(decisoes, Cercados.MT, d.Dinossauro))
                                                return (d.Dinossauro, Cercados.MT);
                                        }

                                    }

                                }

                                foreach (var d in decisoes.Mao) //Em ultimo caso....
                                {
                                    if (d.QuantidadeDinossauros == 0)
                                        continue;

                                    if (d.Dinossauro == Dinossauro.TI)
                                        continue;

                                    if (PossoColocarNoCercado(decisoes, Cercados.RI, d.Dinossauro))
                                        return (d.Dinossauro, Cercados.RI); //Colocar no rio
                                }
                            }
                        }
                        else //NAO JOGAMOS O DADO
                        {
                            if (decisoes.DadoAtual == Dado.FL)
                            {
                                if (TenhoDinoReiDaSelva(decisoes))
                                {
                                    var cercadoEspecificoRS = decisoes.Cercados.Find(c => c.Cercados == Cercados.RS);
                                    var dinoReiSelva = cercadoEspecificoRS.Dinossauros[0];

                                    if (PossoColocarNoCercado(decisoes, Cercados.FI, dinoReiSelva)) //Colocar na FI
                                    {
                                        return (dinoReiSelva, Cercados.FI);
                                    }
                                    else //Se FI ja tiver 6 dinos, jogar na mata tripla
                                    {
                                        if (PossoColocarNoCercado(decisoes, Cercados.MT, dinoReiSelva))
                                        {
                                            return (dinoReiSelva, Cercados.MT);
                                        }
                                        else //Se nao der nada, joga no rio
                                        {
                                            return (dinoReiSelva, Cercados.RI);
                                        }

                                    }
                                }
                                else //não temos o dino RS
                                {
                                    foreach (var d in decisoes.Mao) //procura algum dino para colocar 
                                    {
                                        if (d.QuantidadeDinossauros == 0)
                                            continue;

                                        if (d.Dinossauro == Dinossauro.TI)
                                            continue;

                                        if (PossoColocarNoCercado(decisoes, Cercados.MT, d.Dinossauro)) //Posso botar na mata tripla?
                                        {
                                            return (d.Dinossauro, Cercados.MT);
                                        }
                                        else //Se nao der, joga no rio
                                        {
                                            return (d.Dinossauro, Cercados.RI);
                                        }

                                    }

                                }
                            }
                            if (decisoes.DadoAtual == Dado.WC)
                            {
                                if (!TemDinoNoCercado(decisoes, Cercados.CD))
                                {
                                    foreach (var d in decisoes.Mao) //procura algum dino para colocar 
                                    {
                                        if (d.QuantidadeDinossauros == 0)
                                            continue;

                                        if (d.Dinossauro == Dinossauro.TI)
                                            continue;

                                        return (d.Dinossauro, Cercados.CD);
                                    }
                                }
                                else // ja tem algum dino na campina da diferença
                                {
                                    var cercadoEspecificoCD = decisoes.Cercados.Find(c => c.Cercados == Cercados.CD);

                                    if (cercadoEspecificoCD != null)
                                    {
                                        foreach (var d in decisoes.Mao) //procura algum dino para colocar 
                                        {
                                            if (d.QuantidadeDinossauros == 0)
                                                continue;


                                            if (d.Dinossauro == Dinossauro.TI)
                                            {
                                                if (PossoColocarNoCercado(decisoes, Cercados.IS, d.Dinossauro))
                                                    return (d.Dinossauro, Cercados.IS);

                                                continue;

                                            }

                                            if (!cercadoEspecificoCD.Dinossauros.Contains(d.Dinossauro))
                                            {
                                                return (d.Dinossauro, Cercados.CD);
                                            }

                                        }

                                    }

                                }

                                foreach (var d in decisoes.Mao) //Em ulitmo caso....
                                {
                                    if (d.QuantidadeDinossauros > 0)
                                        return (d.Dinossauro, Cercados.RI); //Colocar no rio
                                }
                            }


                            if (decisoes.DadoAtual == Dado.VZ)
                            {
                                if (TenhoDinoReiDaSelva(decisoes))
                                {
                                    var cercadoEspecificoRS = decisoes.Cercados.Find(c => c.Cercados == Cercados.RS);
                                    var dinoReiSelva = cercadoEspecificoRS.Dinossauros[0];

                                    // 1ª prioridade: floresta da igualdade vazia
                                    if (!TemDinoNoCercado(decisoes, Cercados.FI) &&
                                        PossoColocarNoCercado(decisoes, Cercados.FI, dinoReiSelva))
                                        return (dinoReiSelva, Cercados.FI);

                                    // 2ª prioridade: pradaria do amor vazia
                                    if (!TemDinoNoCercado(decisoes, Cercados.PA) &&
                                        PossoColocarNoCercado(decisoes, Cercados.PA, dinoReiSelva))
                                        return (dinoReiSelva, Cercados.PA);

                                    // 3ª prioridade: qlqr outro cercado vazio que dê pra colocar o rei da selva
                                    if (!TemDinoNoCercado(decisoes, Cercados.CD) &&
                                        PossoColocarNoCercado(decisoes, Cercados.CD, dinoReiSelva))
                                        return (dinoReiSelva, Cercados.CD);

                                    if (!TemDinoNoCercado(decisoes, Cercados.MT) &&
                                        PossoColocarNoCercado(decisoes, Cercados.MT, dinoReiSelva))
                                        return (dinoReiSelva, Cercados.MT);
                                    // ultima prioridade: o rio.....
                                    if (!TemDinoNoCercado(decisoes, Cercados.RI) &&
                                    PossoColocarNoCercado(decisoes, Cercados.RI, dinoReiSelva))
                                        return (dinoReiSelva, Cercados.RI);


                                }
                                else //nao tenho o dino rei da selva
                                {
                                    if (!TemDinoNoCercado(decisoes, Cercados.CD)) //Campina da diferença ta vazio
                                    {
                                        foreach (var d in decisoes.Mao) //procura algum dino para colocar 
                                        {
                                            if (d.QuantidadeDinossauros == 0)
                                                continue;


                                            if (d.Dinossauro == Dinossauro.TI) //Se tivermos o tiranossauro na mao..
                                            {
                                                if (!TemDinoNoCercado(decisoes, Cercados.IS) &&
                                                PossoColocarNoCercado(decisoes, Cercados.IS, d.Dinossauro)) //Se ilha solitaria n tiver o tiranossauro ainda, colocar.
                                                    return (d.Dinossauro, Cercados.IS);

                                                else
                                                {
                                                    continue;
                                                }
                                            }
                                            else //Se NAO tivermos o tiranossauro na mao...
                                            {
                                                if (PossoColocarNoCercado(decisoes, Cercados.CD, d.Dinossauro))
                                                    return (d.Dinossauro, Cercados.CD);  //Colocar na campina da diferença
                                            }

                                        }
                                    }
                                    else //Campina da diferença NAO ta vazio
                                    {
                                        foreach (var d in decisoes.Mao) //procura algum dino para colocar 
                                        {
                                            if (d.QuantidadeDinossauros == 0)
                                                continue;

                                            if (!TemDinoNoCercado(decisoes, Cercados.MT) &&
                                            PossoColocarNoCercado(decisoes, Cercados.MT, d.Dinossauro)) //Se mata tripla tiver vazio, colocar
                                            {
                                                return (d.Dinossauro, Cercados.MT);
                                            }
                                        }

                                        foreach (var d in decisoes.Mao) //Em ultimo caso....
                                        {
                                            if (d.QuantidadeDinossauros == 0)
                                                continue;

                                            if (!TemDinoNoCercado(decisoes, Cercados.RI) &&
                                                PossoColocarNoCercado(decisoes, Cercados.RI, d.Dinossauro)) //Se o rio tiver vazio, colocar.
                                            {
                                                return (d.Dinossauro, Cercados.RI);
                                            }
                                        }
                                    }
                                }
                            }

                            if (decisoes.DadoAtual == Dado.TI)
                            {
                                if (TenhoDinoReiDaSelva(decisoes))
                                {
                                    var cercadoEspecificoRS = decisoes.Cercados.Find(c => c.Cercados == Cercados.RS);
                                    var dinoReiSelva = cercadoEspecificoRS.Dinossauros[0];


                                    if (PossoColocarNoCercado(decisoes, Cercados.FI, dinoReiSelva))
                                        return (dinoReiSelva, Cercados.FI);


                                    if (PossoColocarNoCercado(decisoes, Cercados.PA, dinoReiSelva))
                                        return (dinoReiSelva, Cercados.PA);
                                }
                                else //nao tenho o dino rei da selva
                                {

                                    if (!TemDinoNoCercado(decisoes, Cercados.CD)) //Campina da diferença ta vazio?
                                    {
                                        foreach (var d in decisoes.Mao) //procura algum dino para colocar 
                                        {
                                            if (d.QuantidadeDinossauros == 0)
                                                continue;

                                            if (d.Dinossauro == Dinossauro.TI)
                                                continue;

                                            if (PossoColocarNoCercado(decisoes, Cercados.CD, d.Dinossauro))
                                                return (d.Dinossauro, Cercados.CD);
                                        }
                                    }
                                    else  //Campina da diferença nao ta vazio
                                    {
                                        var cercadoEspecificoCD = decisoes.Cercados.Find(c => c.Cercados == Cercados.CD);

                                        if (cercadoEspecificoCD != null)
                                        {
                                            foreach (var d in decisoes.Mao) //procura algum dino para colocar 
                                            {
                                                if (d.QuantidadeDinossauros == 0)
                                                    continue;

                                                if (d.Dinossauro == Dinossauro.TI)
                                                {
                                                    if (PossoColocarNoCercado(decisoes, Cercados.IS, d.Dinossauro))
                                                        return (d.Dinossauro, Cercados.IS);

                                                    continue;

                                                }

                                                if (!cercadoEspecificoCD.Dinossauros.Contains(d.Dinossauro) &&
                                                    PossoColocarNoCercado(decisoes, Cercados.CD, d.Dinossauro)) //Temos na mão algum outro dino que dê pra colocar na CD?
                                                {
                                                    return (d.Dinossauro, Cercados.CD);
                                                }

                                            }
                                            foreach (var d in decisoes.Mao) //Se não tivermos, colocar em MT
                                            {
                                                if (d.QuantidadeDinossauros == 0)
                                                    continue;

                                                if (d.Dinossauro == Dinossauro.TI)
                                                    continue;

                                                if (PossoColocarNoCercado(decisoes, Cercados.MT, d.Dinossauro))
                                                    return (d.Dinossauro, Cercados.MT);
                                            }

                                        }

                                    }

                                    foreach (var d in decisoes.Mao) //Em ultimo caso....
                                    {
                                        if (d.QuantidadeDinossauros == 0)
                                            continue;

                                        if (d.Dinossauro == Dinossauro.TI)
                                            continue;

                                        if (PossoColocarNoCercado(decisoes, Cercados.RI, d.Dinossauro))
                                            return (d.Dinossauro, Cercados.RI); //Colocar no rio
                                    }
                                }
                            }

                            if (decisoes.DadoAtual == Dado.PR)
                            {
                                if (TenhoDinoReiDaSelva(decisoes))
                                {
                                    var cercadoEspecificoRS = decisoes.Cercados.Find(c => c.Cercados == Cercados.RS);
                                    var dinoReiSelva = cercadoEspecificoRS.Dinossauros[0];

                                    if (PossoColocarNoCercado(decisoes, Cercados.PA, dinoReiSelva))
                                        return (dinoReiSelva, Cercados.PA);

                                    //Apenas segurança, caso não dê para colocar em PA direto..

                                    if (PossoColocarNoCercado(decisoes, Cercados.CD, dinoReiSelva))
                                        return (dinoReiSelva, Cercados.CD);

                                    if (PossoColocarNoCercado(decisoes, Cercados.RI, dinoReiSelva))
                                        return (dinoReiSelva, Cercados.RI);
                                }

                                else { //Não tenho o dino rei da selva

                                    if (!TemDinoNoCercado(decisoes, Cercados.CD)) //Se campina da diferença está vazia
                                    {
                                        foreach (var d in decisoes.Mao) //procura algum dino para colocar 
                                        {
                                            if (d.QuantidadeDinossauros == 0)
                                                continue;

                                            if (d.Dinossauro == Dinossauro.TI)
                                                continue;

                                            if (PossoColocarNoCercado(decisoes, Cercados.CD, d.Dinossauro))
                                                return (d.Dinossauro, Cercados.CD); //Coloca na campina da diferenca
                                        }
                                    }
                                    else // ja tem algum dino na campina da diferença
                                    {
                                        var cercadoEspecificoCD = decisoes.Cercados.Find(c => c.Cercados == Cercados.CD);

                                        if (cercadoEspecificoCD != null)
                                        {
                                            foreach (var d in decisoes.Mao) //procura algum dino para colocar 
                                            {
                                                if (d.QuantidadeDinossauros == 0)
                                                    continue;


                                                if (d.Dinossauro == Dinossauro.TI) //Se tivermos o tiranossauro na mao...
                                                {
                                                    if (!TemDinoNoCercado(decisoes, Cercados.IS) &&
                                                    PossoColocarNoCercado(decisoes, Cercados.IS, d.Dinossauro)) //Se ilha solitaria n tiver o tiranossauro ainda, colocar.
                                                        return (d.Dinossauro, Cercados.IS);

                                                    continue;
                                                }

                                                if (!cercadoEspecificoCD.Dinossauros.Contains(d.Dinossauro)) 
                                                {
                                                    if (PossoColocarNoCercado(decisoes, Cercados.CD, d.Dinossauro))
                                                        return (d.Dinossauro, Cercados.CD); 
                                                }

                                            }

                                        }

                                    }

                                    foreach (var d in decisoes.Mao) //Em ulitmo caso....
                                    {
                                        if (d.QuantidadeDinossauros == 0)
                                            continue;

                                        if (d.Dinossauro == Dinossauro.TI)
                                            continue;

                                        if (PossoColocarNoCercado(decisoes, Cercados.RI, d.Dinossauro))
                                            return (d.Dinossauro, Cercados.RI); //Colocar no rio
                                    }
                                }

                            }
                            if (decisoes.DadoAtual == Dado.AL)
                            {
                                if (TenhoDinoReiDaSelva(decisoes))
                                {
                                    var cercadoEspecificoRS = decisoes.Cercados.Find(c => c.Cercados == Cercados.RS);
                                    var dinoReiSelva = cercadoEspecificoRS.Dinossauros[0];

                                    if (PossoColocarNoCercado(decisoes, Cercados.FI, dinoReiSelva ))
                                    {
                                        return (dinoReiSelva, Cercados.FI);
                                    }

                                    if (PossoColocarNoCercado(decisoes, Cercados.PA, dinoReiSelva))
                                    {
                                        return (dinoReiSelva, Cercados.PA);
                                    }

                                    if (PossoColocarNoCercado(decisoes, Cercados.RI, dinoReiSelva))
                                    {
                                        return (dinoReiSelva, Cercados.RI);
                                    }

                                }

                                else //Nao tenho o rei da selva
                                {
                                    foreach (var d in decisoes.Mao)
                                    {
                                        if (d.QuantidadeDinossauros == 0)
                                            continue;

                                        if (d.Dinossauro == Dinossauro.TI)
                                            continue;

                                        if (PossoColocarNoCercado(decisoes, Cercados.MT, d.Dinossauro))
                                            return (d.Dinossauro, Cercados.MT);
                                     }

                                    foreach (var d in decisoes.Mao) //Em ulitmo caso....
                                    {
                                        if (d.QuantidadeDinossauros == 0)
                                            continue;

                                        if (d.Dinossauro == Dinossauro.TI)
                                            continue;

                                        if (PossoColocarNoCercado(decisoes, Cercados.RI, d.Dinossauro))
                                            return (d.Dinossauro, Cercados.RI); //Colocar no rio
                                    }

                                }
                            }
                        }

                    }






        }















    }
}
  

//Fazer uma função desses foreach