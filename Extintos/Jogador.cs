using Draft;
using System;
using System.Collections.Generic;
using Extintos.Enumeration;

namespace Extintos.Model
{
    // Classe que representa um jogador no jogo, contendo propriedades e métodos relacionados ao jogador
    internal class Jogador
    {
        public int IdJogador { get; set; }

        public string NomeJogador { get; set; } 
        
        public string Senha { get; set; }

        public int Pontuacao { get; set; }
        
        
        public int idPartida { get; set; } 
        
        public List<AuxCercado> meusCercados { get; set; } = CercadosExtension.CercadoAuxLista(); 
         /*
         lista de cercados que o jogador possui, pode ser usada para armazenar os cercados 
         conquistados pelo jogador durante o jogo e facilitar a gestão desses cercados.
         */


        public static Jogador EntrarNaPartida(int idPartida, string nomeJogador, string senhaPartida) 
            /*
            método estático para permitir que um jogador entre em uma partida existente,
            recebendo o id da partida, o nome do jogador e a senha da partida como parâmetros.
            O método pode retornar um objeto do tipo Jogador com as informações do jogador que entrou na partida,
            ou lançar uma exceção caso haja algum erro durante o processo de entrada.
            */
        {
            
            string retornoEntrar = Jogo.Entrar(idPartida, nomeJogador, senhaPartida);
            string[] dadosJogador = retornoEntrar.Split(',');
                
            Jogador jogador = new Jogador();

            jogador.IdJogador = Convert.ToInt32(dadosJogador[0]);
            jogador.Senha = dadosJogador[1];
            jogador.NomeJogador = nomeJogador;
            jogador.Pontuacao = 0;
            jogador.idPartida = idPartida;

            return jogador;
        }

        // busca com o id da partida (mais eficiente, uma chamada só)
        public static string BuscaPeloId(int idJogador, int idPartida)
        {
            List<Jogador> jogadores = Partida.ListarJogadores(idPartida);
            Jogador jogadorEncontrado = jogadores.Find(j => j.IdJogador == idJogador);

            if (jogadorEncontrado == null)
                return null;

            return jogadorEncontrado.NomeJogador;
        }

        // busca sem o id da partida (percorre todas as partidas)
        public static string BuscaPeloId(int idJogador)
        {
            List<Partida> todasPartidas = Partida.ListarPartidas('T');

            foreach (Partida partida in todasPartidas)
            {
                List<Jogador> jogadores = Partida.ListarJogadores(partida.IdPartida);
                Jogador jogadorEncontrado = jogadores.Find(j => j.IdJogador == idJogador);

                if (jogadorEncontrado != null)
                    return jogadorEncontrado.NomeJogador;
            }

            return null;
        }

        public void ColocarDinossauro(Dinossauro dino, Cercados cerca)
        {
            AuxCercado cercado = meusCercados.Find(c => c.Cercados.Equals(cerca));
            cercado.Dinossauros.Add(dino);
        }
        
    }
}
