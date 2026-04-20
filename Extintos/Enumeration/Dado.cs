using System;
using System.Collections.Generic;
using System.Reflection;




namespace Extintos.Enumeration
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class DadoFace : Attribute

    {
        public string Nome { get; }
        public string Restricao { get; }

        public DadoFace(string nome, string restricao)
        {
            Nome = nome;
            Restricao = restricao;
        }




    }

    public enum Dado
    {
        [DadoFace("Alimentação", "Os dinossauros devem ser posicionados no lado da praça de alimentação do seu zoo")]
        AL,

        [DadoFace("Floresta", "Os dinossauros devem ser posicionados na seção florestal de seu zoo")]
        FL,

        [DadoFace("Pradaria", "Os dinossauros devem ser posicionados na seção de pradarias de seu zoo")]
        PR,

        [DadoFace("Tiranossauro Rex", "Os dinossauros devem ser posicionados em um cercado que não tenha um T-Rex")]
        TI,

        [DadoFace("Cercado Vazio", "Os dinossauros devem ser posicionados em um cercado ainda vazio")]
        VZ,

        [DadoFace("Banheiros", "Os dinossauros devem ser posicionados no lado dos banheiros do seu zoo")]
        WC,

    }

    internal static class DadoExtension
    {
        public static DadoFace? PegaInfo(this Dado dado)
        {
            var field = dado.GetType().GetField(dado.ToString());
            return field?.GetCustomAttribute<DadoFace>();
        }

        public static string PegaNome(this Dado dado)
        {
            return dado.PegaInfo()?.Nome ?? dado.ToString();
        }

        public static string PegaRestricao(this Dado dado)
        {
            return dado.PegaInfo()?.Restricao ?? string.Empty;
        }

        public static List<Cercados> ValidaCercados(this Dado dado)
        {
            switch (dado)
            {
                case Dado.AL:
                    List<Cercados> listaAlimentacao = new List<Cercados>();
                    listaAlimentacao.Add(Cercados.FI);
                    listaAlimentacao.Add(Cercados.MT);
                    listaAlimentacao.Add(Cercados.PA);
                    listaAlimentacao.Add(Cercados.RI);
                    return listaAlimentacao;

                case Dado.FL:
                    List<Cercados> listaFloresta = new List<Cercados>();
                    listaFloresta.Add(Cercados.FI);
                    listaFloresta.Add(Cercados.MT);
                    listaFloresta.Add(Cercados.RI);
                    listaFloresta.Add(Cercados.RS);
                    return listaFloresta;

                case Dado.PR:
                    List<Cercados> listaPradais = new List<Cercados>();
                    listaPradais.Add(Cercados.IS);
                    listaPradais.Add(Cercados.PA);
                    listaPradais.Add(Cercados.CD);
                    listaPradais.Add(Cercados.RI);
                    return listaPradais;

                case Dado.WC:
                    List<Cercados> listaBanheiro = new List<Cercados>();
                    listaBanheiro.Add(Cercados.RI);
                    listaBanheiro.Add(Cercados.RS);
                    listaBanheiro.Add(Cercados.IS);
                    listaBanheiro.Add(Cercados.CD);
                    return listaBanheiro;
                
                case Dado.TI:
                    List<Cercados> listaTi = new List<Cercados>();
                    listaTi.Add(Cercados.FI);
                    listaTi.Add(Cercados.MT);
                    listaTi.Add(Cercados.PA);
                    listaTi.Add(Cercados.RI);
                    listaTi.Add(Cercados.RS);
                    listaTi.Add(Cercados.IS);
                    return listaTi;
                case Dado.VZ:
                    List<Cercados> listaVz = new List<Cercados>();
                    listaVz.Add(Cercados.FI);
                    listaVz.Add(Cercados.MT);
                    listaVz.Add(Cercados.PA);
                    listaVz.Add(Cercados.RI);
                    listaVz.Add(Cercados.RS);
                    listaVz.Add(Cercados.IS);
                    return listaVz;
                default: 
                    List<Cercados> listaTodos = new List<Cercados>();
                    listaTodos.Add(Cercados.FI);
                    listaTodos.Add(Cercados.MT);
                    listaTodos.Add(Cercados.PA);
                    listaTodos.Add(Cercados.RI);
                    listaTodos.Add(Cercados.RS);
                    listaTodos.Add(Cercados.IS);
                    return listaTodos;
            }
        }
    }
}
//como usa: 

//Dado dadoAtual = Dado.PegaNome();

//List<Cercados> valida = dadoAtual.GetCercados();

//ex de uso pra percorrer ela e ver se pode colocar no cercad
//foreach (var cercadoEscolido in valida)


