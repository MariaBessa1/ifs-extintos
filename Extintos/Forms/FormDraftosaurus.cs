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
                //verifica se o turno atual é do jogador 
                var verificacao = Partida.VerificaPartida(_dadosJogador.idPartida);
                 if (verificacao.idJogador == _dadosJogador.IdJogador)
            {
                List<Cercados> todos = CercadosExtension.cercadosLista();

                Dado dadoAtual = (Dado)Enum.Parse(typeof(Dado), verificacao.faceDado);

                //validação de regras do cercado a partir do dado
                List<Cercados> cercadosOk = dadoAtual.ValidaCercados();

                string dinoEscolhido = txtDino.Text.ToUpper();

                string cercadoEscolhido = txtCercado.Text.ToUpper();

                if (!cercadosOk.Contains((Cercados)Enum.Parse(typeof(Cercados), cercadoEscolhido)))
                {
                    MessageBox.Show(
                        $"Voce nao pode jogar nesse cercado devido ao dado do turno\n\n" +
                        $"Dado atual: {dadoAtual.PegaNome()}\n\n" +
                        $"A restição diz que {dadoAtual.PegaRestricao()}\n\n" +
                        $"Escolha outro cercado!!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show(
                        $"Jogada realizada com sucesso!", "Boa!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //criar metodo pra atualizar dinos no cercado


                }


                string retornoMao = Jogo.ExibirMao(_dadosJogador.IdJogador, _dadosJogador.Senha);
                retornoMao = retornoMao.Substring(1);
                string[] linhasRetorno = retornoMao.Replace("\r", "")
                    .Split(new[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

                //esse new[] ta criando um novo array pra guardar por linha, pq eles vem tudo na mesma linha
                List<AuxDinossauro> dinossaurosJogador = new List<AuxDinossauro>();



                foreach (string linha in linhasRetorno)
                {
                    string[] partes = linha.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    if (partes.Length == 2)
                    {

                        string codigo = partes[0].Trim();
                        int quantidade = int.Parse(partes[1].Trim());
                        Dinossauro dinossauro = (Dinossauro)Enum.Parse(typeof(Dinossauro), codigo.ToUpper());
                        dinossaurosJogador.Add(new AuxDinossauro(dinossauro, quantidade));

                    }

                }

                Dinossauro dino = (Dinossauro)Enum.Parse(typeof(Dinossauro), dinoEscolhido);
                Cercados cerca = (Cercados)Enum.Parse(typeof(Cercados), cercadoEscolhido);
                foreach (var dinossauro in dinossaurosJogador)
                {
                    if (dinossauro.Dinossauro.Equals(dino))
                    {
                        //MessageBox.Show($"foi2", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        string retorno = Jogo.Jogar(_dadosJogador.IdJogador, _dadosJogador.Senha, dinoEscolhido,
                            cercadoEscolhido);
                        // lblMensagemInicioPartida.Text= retorno;
                        _dadosJogador.ColocarDinossauro(dino, cerca);
                    }
                }
            }

        }
        
        private void btnVerificarPartida_Click(object sender, EventArgs e)
        {
            VerificarPartida();
                

        }

        private void VerificarPartida()
        {

            var verificacao = Partida.VerificaPartida(_dadosJogador.idPartida);

                
            char statusPartida = verificacao.statusPartida; // J ou E
            int numeroTurno = verificacao.numeroTurno;      // 1 a 12
            char statusTurno = verificacao.statusTurno;     // A ou F
            int jogadorDaVez = verificacao.idJogador;       // ID
            string faceDado = verificacao.faceDado;         // PR, FL, etc

                
            string resumo = $"{statusPartida}{numeroTurno}{statusTurno}{jogadorDaVez}{faceDado}";

            txtVerificarPartida.Text = resumo;

            
            lblDescricaoVerificacao.Text = "Status da Partida | Nº Turno | Status Turno | Jogador | Dado\n";

                
            txtVerificarPartida.Visible = true;
            lblDescricaoVerificacao.Visible = true;
        }

        private void lblNomeDino_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void lblDescricaoVerificacao_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void FormDraftosaurus_Load(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}


     
    



