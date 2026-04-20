using Draft;
using Extintos.Enumeration;
using Extintos.Model;
using System;
using System.Collections.Generic;


namespace Extintos
{
    internal class Partida
    {
        
        //DEFINIÇÕES DA CLASSE E PRIORIDADES 
        public int IdPartida { get; set; } 
        public string Nome { get; set; }
        public DateTime Data { get; set; }  
        public char Status { get; set; }
       // public int Turno { get; set; }
        public List<Jogador> Jogadores { get; set; } 
        
        

        //  public List<Turno> Turnos { get; set; }

        //LÓGICA DO DATA ACCESS
        //O fluxo é: Camada de Interface (UI) -> Classe Partida (Model) -> Classe Jogo (Service)
        public static List<Partida> ListarPartidas(char Status)
        {
            string status = Convert.ToString(Status);
            string retorno = Jogo.ListarPartidas(status);
            retorno = retorno.Replace("\r", "");
            retorno = retorno.Substring(0, retorno.Length - 1);
            string[] retornoPartidas = retorno.Split('\n');
            List<Partida> listaPartidas = new List<Partida>();
            for (int i = 0; i < retornoPartidas.Length; i++)
            {
                string partida = retornoPartidas[i];
                string[] dados = partida.Split(',');
                Partida p = new Partida();
                p.IdPartida = Convert.ToInt32(dados[0]);
                p.Nome = dados[1];
                p.Data = Convert.ToDateTime(dados[2]);
                p.Status = Convert.ToChar(dados[3]);
                //p.Jogadores = Partida.ListarJogadores(p.IdPartida);
                listaPartidas.Add(p);
            }

            return listaPartidas;
        }

        public static List<Jogador> ListarJogadores(int Id)
        {
            string retorno = Jogo.ListarJogadores(Id);
            if ("".Equals(retorno))
            {
                return new List<Jogador>();
            } 
               
            retorno = retorno.Replace("\r", "");
            retorno = retorno.Substring(0, retorno.Length - 1);
            string[] retornoJogadores = retorno.Split('\n');
            List<Jogador> listaJogadores = new List<Jogador>();
            for (int i = 0; i < retornoJogadores.Length; i++)
            {
                string jogador = retornoJogadores[i];
                string[] dados = jogador.Split(',');
                Jogador j = new Jogador();
                j.IdJogador = Convert.ToInt32(dados[0]);
                j.NomeJogador = dados[1];
                j.Pontuacao = Convert.ToInt32(dados[2]);
                listaJogadores.Add(j);
            }

            return listaJogadores;
        }


        public static Partida BuscaPeloId(char Status, int IdPartida)
        {
            List<Partida> partidas = Partida.ListarPartidas(Status);
            Partida partidaEncontrada = partidas.Find(p => p.IdPartida == IdPartida);
            return partidaEncontrada;
        }
// metodo tipo tupla, tudo que ta nos ( ) é os tipos de retorno e o verificaPartida é o nome e o parametro
//putaria de c# em java é mais bonito, negocio feiao
//é uma versao melhor do metodo do claro
        public static (char statusPartida, int numeroTurno, char statusTurno, int idJogador, string faceDado)
            VerificaPartida(int idPartida)
        {

            string retorno = Jogo.VerificarPartida(idPartida);
            string[] dados = retorno.Split(',');

            return (
                Convert.ToChar(dados[0]), // statusPartida se é J ou E
                Convert.ToInt32(dados[1]), // numeroTurn 1-12
                Convert.ToChar(dados[2]), // statusTurno se tá A ou F
                Convert.ToInt32(dados[3]), // idJogador
                dados[4] // faceDado AL, FL, PR e tal
            );
        }

        
        public static string IniciarPartida(int idJogador, string senhaJogador, int idPartida)
        /*
         Parte central da lógica do código.
         Ele combina a ação (iniciar) com a consulta (verificar status)
         e formata uma mensagem para o usuário.
        */
        {
      
            string retornoEntrar = Jogo.Iniciar(idJogador, senhaJogador);
            var verificacao = Partida.VerificaPartida(idPartida);
         
            // usei var pq ela faz uma tupla e guarda tipos diferentes de dados


            Dado dadoAtual = (Dado)Enum.Parse(typeof(Dado), verificacao.faceDado);
            
            //Boto um trim ? talvez 

            string mensagemInicio = $"O Jogador: {Jogador.BuscaPeloId(idJogador)} iniciou a partida!\n" +
                                    $"O primeiro a jogar é: {Jogador.BuscaPeloId(verificacao.idJogador)}\n" +
                                    $"Turno: {verificacao.numeroTurno}\n" +
                                    $"Face do Dado: {dadoAtual.PegaNome()}\n";
            
            
            return mensagemInicio;
        }
        
        
    }
}

