// Importações e namespaces utilizados no código
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Draft;

namespace Extintos
{

    public partial class Form1 : Form //declaração de herança pelo windows form 
    {
        public Form1() //construtor do forms
        {
            InitializeComponent();
            lblVersao.Text = Jogo.versao;
            Config.Fullscreen(Forms.Form1);

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
            this.Size = new System.Drawing.Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            this.WindowState = FormWindowState.Maximized;
        }
        

        private void btnCriarPartida_Click(object sender, EventArgs e) //evento de clique do botão criar partida
        {
            txtNomedoGrupo.Text = "Extintos";
            string nomePartida = txtNomedaPartida.Text;
            string senhaPartida = txtSenhadaPartida.Text;
            string nomeGrupo = txtNomedoGrupo.Text;

            if (string.IsNullOrEmpty(nomePartida) ||
                string.IsNullOrEmpty(senhaPartida) ||
                string.IsNullOrEmpty(nomeGrupo))
            {
                MessageBox.Show("Todos os campos devem ser preechidos!!\n\n", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           Jogo.CriarPartida(nomePartida, senhaPartida, nomeGrupo);

            //Referenciando o próximo formulário
            Forms.FormLobby.Show();
            this.Hide();
        }

        private void btnIrPartidaExistente_Click(object sender, EventArgs e) //evento de clique do botão ir para partida existente
        {
            Forms.FormLobby.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e) //evento de carregamento do forms
        {

        }

        private void txtNomedaPartida_TextChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void txtSenhadaPartida_TextChanged(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
    }
