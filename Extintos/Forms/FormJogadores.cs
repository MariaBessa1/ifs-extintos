using Draft;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Extintos.Model;

namespace Extintos
{
    public partial class FormJogadores : Form
    {
         
        private Jogador dadosJogador; //*******

        public FormJogadores()
        { 

            InitializeComponent();
            lblVersao2.Text = Jogo.versao;

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.WindowState = FormWindowState.Maximized;

            dgvJogadores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvJogadores.EditMode = DataGridViewEditMode.EditProgrammatically;
            dgvJogadores.AllowUserToAddRows = false;
            dgvJogadores.AllowUserToResizeColumns = false;
            dgvJogadores.AllowUserToResizeRows = false;
            dgvJogadores.RowHeadersVisible = false;


        }

        internal FormJogadores(Jogador dadosJogador) : this() //Construtor com parâmetro 
        {
            this.dadosJogador = dadosJogador;
            lblSenhaGeradaa.Text = dadosJogador.Senha;
        }

       
        private void bntListaJogadores_Click(object sender, EventArgs e)
        {

           dgvJogadores.DataSource = Partida.ListarJogadores(dadosJogador.idPartida);

        }



        private void bntEntrar_Click(object sender, EventArgs e)
        {
            //teste do GPT pra arrumar essa bosta de botão
            FormDraftosaurus form = new FormDraftosaurus("", dadosJogador);
            form.Show();
            this.Hide();

            Task.Run(() =>
            {
                string retorno = Partida.IniciarPartida(
                    dadosJogador.IdJogador,
                    dadosJogador.Senha,
                    dadosJogador.idPartida
                );

                form.Invoke((MethodInvoker)delegate
                {
                    form.DefinirRetorno(retorno);
                });
            });

            /*string retornoEntrar = Partida.IniciarPartida(dadosJogador.IdJogador, dadosJogador.Senha, dadosJogador.idPartida);
            FormDraftosaurus FormDraftosaurus = new FormDraftosaurus(retornoEntrar, dadosJogador);
            FormDraftosaurus.Show();
            this.Hide();
            */


        }
        private void btnCadastrarNovoJogador_Click(object sender, EventArgs e)
        {
            Forms.FormLobby.Show();
            this.Hide();

        }

        private void btnVoltar2_Click(object sender, EventArgs e)
        {
            Forms.FormLobby.Show();
            this.Hide();
        }

        private void btnVoltar2_Click_1(object sender, EventArgs e)
        {
            Forms.FormLobby.Show();
            this.Hide();
        }

     
    }
    }






