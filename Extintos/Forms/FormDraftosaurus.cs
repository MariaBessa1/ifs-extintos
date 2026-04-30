//todos os import
using Draft;
using Extintos.Enumeration;
using Extintos.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace Extintos
{
    public partial class FormDraftosaurus : Form
    {
        //declaração de variáveis de nivel de classe que existem enquanto o form estiver aberto
        //é a memória do formulário.
        private string _retornoEntrar;
        private Jogador _dadosJogador; //armazena senha e id do jogador e partida

        public void DefinirRetorno(string retorno)
        {
            lblRetornoInicio.Text = retorno;
        }

        public FormDraftosaurus() 
            /*
             construtor padrão, faz o desenho do form
             assim que se clica em criar partida ou entrar no form anterior, esse form recebe os dados e 
             construa o restante já com os dados obtidos anteriormente
                 */
        {

            InitializeComponent();
            lblVersaoTres.Text = Jogo.versao;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.WindowState = FormWindowState.Maximized;

        }

        internal FormDraftosaurus(string retornoEntrar, Jogador dadosJogador) : this() //Construtor com parâmetros
        {
            this._retornoEntrar = retornoEntrar;
            this._dadosJogador = dadosJogador;
            lblRetornoInicio.Text = _retornoEntrar;
        }

        //metodo de exibir a mao vai ir pro jogador depois

        public void bntExibirMao_Click(object sender, EventArgs e)
        {
            string retornoMao = Jogo.ExibirMao(_dadosJogador.IdJogador, _dadosJogador.Senha);
            string[] linhasRetorno = retornoMao.Replace("\r", "")
                .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            /*
             esse new[] ta criando um novo array pra guardar por linha, pq eles vem tudo na mesma linha
             Replace -> remove os char invisíveis de quebra de linha
             Split \n transforma a string em uma lista de linhas
             Split , quebra a linha em colunas
             */
            List<AuxDinossauro> dinossaurosJogador = new List<AuxDinossauro>();



            foreach (string linha in linhasRetorno)
            {
                string[] partes = linha.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (partes.Length == 2)
                {

                    string codigo = partes[0].ToUpper().Trim();
                    codigo.ToUpper();
                    int quantidade = int.Parse(partes[1].Trim());
                    Dinossauro dinossauro = (Dinossauro)Enum.Parse(typeof(Dinossauro), codigo);
                    dinossaurosJogador.Add(new AuxDinossauro(dinossauro, quantidade));

                }

                string mao = "";
                foreach (var item in dinossaurosJogador)
                {
                    mao += $"Dino: {item.Dinossauro.PegaNome()} | Qtd: {item.QuantidadeDinossauros}\n";
                }

                lblNomeDino.Text = mao;


            }
        }

        public void btnJogar_Click(object sender, EventArgs e)
        {
            // pega o estado atual da partida
            var verificacao = Partida.VerificaPartida(_dadosJogador.idPartida);

            // impede jogar se o turno já acabou
            if (verificacao.statusTurno == 'F')
            {
                MessageBox.Show("O turno já foi finalizado!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // pega o dado do turno atual
            Dado dadoAtual = (Dado)Enum.Parse(typeof(Dado), verificacao.faceDado);

            // verifica quais são os cercados permitidos com base no dado
            List<Cercados> cercadosOk = dadoAtual.ValidaCercados();

            // valores digitados pelo jogador
            string dinoEscolhido = txtDino.Text.ToUpper();
            string cercadoEscolhido = txtCercado.Text.ToUpper();

            // valida se o cercado pode ser usado
            if (!cercadosOk.Contains((Cercados)Enum.Parse(typeof(Cercados), cercadoEscolhido)))
            {
                MessageBox.Show(
                    $"Você não pode jogar nesse cercado!\n\nDado: {dadoAtual.PegaNome()}",
                    "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // envia a jogada para o jogo
            string retorno = Jogo.Jogar(_dadosJogador.IdJogador, _dadosJogador.Senha, dinoEscolhido, cercadoEscolhido);

            MessageBox.Show("Jogada realizada com sucesso!", "Boa!!", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        
        private void btnVerificarPartida_Click(object sender, EventArgs e)
        {
            VerificarPartida();
        }

        private void VerificarPartida()
        {
            // pega os dados atuais da partida
            var verificacao = Partida.VerificaPartida(_dadosJogador.idPartida);

            // cada variável representa uma parte do retorno    
            char statusPartida = verificacao.statusPartida; // J ou E (jogando ou encerrado)
            int numeroTurno = verificacao.numeroTurno;      // turno atual
            char statusTurno = verificacao.statusTurno;     // A ou F (andamento ou finalizado)
            int jogadorDaVez = verificacao.idJogador;       // quem está com o dado
            string faceDado = verificacao.faceDado;         // dado sorteado

            // monta a saída no padrão do client
            string resumo = $"{statusPartida}, {numeroTurno}, {statusTurno}, {jogadorDaVez}, {faceDado}";

            txtSaida.Text = resumo;
            
            lblDescricaoVerificacao.Text = "Status da Partida | Nº Turno | Status Turno | Jogador | Dado\n";
                
            txtSaida.Visible = true;
            lblDescricaoVerificacao.Visible = true;
        }


        private void lblNomeDino_Click(object sender, EventArgs e)
        {
           
        }

        private void lblDescricaoVerificacao_Click(object sender, EventArgs e)
        {
           
        }

        private void FormDraftosaurus_Load(object sender, EventArgs e)
        {
            
        }

        private void btnExibirTabuleiro_Click(object sender, EventArgs e)
        {
            ExibirTabuleiro();
        }

        private void ExibirTabuleiro()
        {
            int idJogador;

            // se não digitar ID, usa o próprio
            if (string.IsNullOrEmpty(txtIdJogadorTabuleiro.Text))
            {
                idJogador = _dadosJogador.IdJogador;
            }
            else
            {
                idJogador = Convert.ToInt32(txtIdJogadorTabuleiro.Text);
            }

            string retorno;

            // se for o próprio jogador, envia a senha (mostra tudo)
            if (idJogador == _dadosJogador.IdJogador)
            {
                retorno = Jogo.ExibirTabuleiro(idJogador, _dadosJogador.Senha);
            }
            else
            {
                retorno = Jogo.ExibirTabuleiro(idJogador);
            }

            // mostra o retorno direto do método
            txtSaida.Text = retorno;

            lblDescricaoVerificacao.Text = "Cercado | Dinossauro | Quantidade";

            txtSaida.Visible = true;
            lblDescricaoVerificacao.Visible = true;

        }

        private void ListarHistorico()
        {
            // chama o método
            string retorno = Jogo.ListarHistorico(_dadosJogador.idPartida);

            // joga direto na textbox do histórico
            txtHistorico.Text = retorno.Replace(".", ".\r\n");

            txtHistorico.ScrollBars = ScrollBars.Both;
            txtHistorico.Multiline = true;
            txtHistorico.ReadOnly = true;
        }

        private void btnAtualizarHistorico_Click(object sender, EventArgs e)
        {
            ListarHistorico();
        }

        private void lblRetornoInicio_Click(object sender, EventArgs e)
        {

        }

    }
}


     
    



