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
            var cercadosPermitidos = decisoes.DadoAtual.ValidaCercados();

            foreach (var maoDino in decisoes.Mao)  //para percorrer nossa mão inteira, dino por dino:
            {
                if (maoDino.QuantidadeDinossauros == 0) //se não temos nenhum daquele tipo de dino, continuamos para o proximo
                    continue;

                var dino = maoDino.Dinossauro; //TR, TI, PA.....

                foreach (var cercadoAtual in cercadosPermitidos)   //para percorrer os cercados que podem ser jogagos nesse turno (de acordo com o dado rolado)
                {
                    var cercadoEspecifico = decisoes.Cercados.Find(c => c.Cercados == cercadoAtual); //Dinos que estao dentro de um cercado especifico.
                                                                                                     //Procura o primeiro elemento c onde o Cercados dele é igual ao cercado atual
                                                                                                     //posso botar esse dino nesse cercado?                                                                  
                    PossoColocarNoCercado(decisoes, cercadoAtual, dino);

                    if (!PossoColocarNoCercado(decisoes, cercadoAtual, dino))
                        continue;

                    /*|                   |
                      | NOSSO FLUXO EBA:: |
                      |                   |
                    */


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
                    else // outros turnos
                    {
                        if (decisoes.JogueioDado) //Jogamos o dado
                        { 
                          

                        }
                        else //Não jogamos o dado
                        {
                            if (decisoes.DadoAtual == Dado.FL)
                            {
                                if(TenhoDinoReiDaSelva(decisoes))
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
                            if (decisoes.DadoAtual == Dado.WC)
                            {
                                if(!TemDinoNoCercado(decisoes, Cercados.CD))
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
                                

                                }

                            }
                            if (decisoes.DadoAtual == Dado.VZ)
                            {

                            }
                            if (decisoes.DadoAtual == Dado.TI)
                            {

                            }
                            if (decisoes.DadoAtual == Dado.PR)
                            {

                            }
                            if (decisoes.DadoAtual == Dado.AL)
                            {

                            }

                        }






                        }















                    }
            }
        }
    }
}
