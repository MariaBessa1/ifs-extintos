namespace Extintos
{
    partial class FormJogadores
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lblSenhaGeradaJogador = new System.Windows.Forms.Label();
            this.bntListaJogadores = new System.Windows.Forms.Button();
            this.lblSenhaGeradaa = new System.Windows.Forms.Label();
            this.btnProximo = new System.Windows.Forms.Button();
            this.btnCadastrarNovoJogador = new System.Windows.Forms.Button();
            this.lblTituloAddJogadores = new System.Windows.Forms.Label();
            this.lblVersao2 = new System.Windows.Forms.Label();
            this.btnVoltar2 = new System.Windows.Forms.Button();
            this.dgvJogadores = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJogadores)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSenhaGeradaJogador
            // 
            this.lblSenhaGeradaJogador.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSenhaGeradaJogador.AutoSize = true;
            this.lblSenhaGeradaJogador.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenhaGeradaJogador.Location = new System.Drawing.Point(707, 179);
            this.lblSenhaGeradaJogador.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSenhaGeradaJogador.Name = "lblSenhaGeradaJogador";
            this.lblSenhaGeradaJogador.Size = new System.Drawing.Size(233, 18);
            this.lblSenhaGeradaJogador.TabIndex = 44;
            this.lblSenhaGeradaJogador.Text = "Senha do jogador adicionado:";
            // 
            // bntListaJogadores
            // 
            this.bntListaJogadores.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.bntListaJogadores.BackColor = System.Drawing.Color.MediumAquamarine;
            this.bntListaJogadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntListaJogadores.Location = new System.Drawing.Point(392, 131);
            this.bntListaJogadores.Name = "bntListaJogadores";
            this.bntListaJogadores.Size = new System.Drawing.Size(141, 31);
            this.bntListaJogadores.TabIndex = 46;
            this.bntListaJogadores.Text = "Listar Jogadores";
            this.bntListaJogadores.UseVisualStyleBackColor = false;
            this.bntListaJogadores.Click += new System.EventHandler(this.bntListaJogadores_Click);
            // 
            // lblSenhaGeradaa
            // 
            this.lblSenhaGeradaa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSenhaGeradaa.AutoSize = true;
            this.lblSenhaGeradaa.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenhaGeradaa.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblSenhaGeradaa.Location = new System.Drawing.Point(778, 227);
            this.lblSenhaGeradaa.Name = "lblSenhaGeradaa";
            this.lblSenhaGeradaa.Size = new System.Drawing.Size(0, 17);
            this.lblSenhaGeradaa.TabIndex = 47;
            // 
            // btnProximo
            // 
            this.btnProximo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnProximo.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnProximo.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProximo.Location = new System.Drawing.Point(739, 304);
            this.btnProximo.Name = "btnProximo";
            this.btnProximo.Size = new System.Drawing.Size(168, 87);
            this.btnProximo.TabIndex = 49;
            this.btnProximo.Text = "Iniciar Partida";
            this.btnProximo.UseVisualStyleBackColor = false;
            this.btnProximo.Click += new System.EventHandler(this.bntEntrar_Click);
            // 
            // btnCadastrarNovoJogador
            // 
            this.btnCadastrarNovoJogador.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCadastrarNovoJogador.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnCadastrarNovoJogador.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrarNovoJogador.Location = new System.Drawing.Point(375, 501);
            this.btnCadastrarNovoJogador.Name = "btnCadastrarNovoJogador";
            this.btnCadastrarNovoJogador.Size = new System.Drawing.Size(180, 26);
            this.btnCadastrarNovoJogador.TabIndex = 51;
            this.btnCadastrarNovoJogador.Text = "Cadastrar novo jogador";
            this.btnCadastrarNovoJogador.UseVisualStyleBackColor = false;
            this.btnCadastrarNovoJogador.Click += new System.EventHandler(this.btnCadastrarNovoJogador_Click);
            // 
            // lblTituloAddJogadores
            // 
            this.lblTituloAddJogadores.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblTituloAddJogadores.AutoSize = true;
            this.lblTituloAddJogadores.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloAddJogadores.Location = new System.Drawing.Point(532, 50);
            this.lblTituloAddJogadores.Name = "lblTituloAddJogadores";
            this.lblTituloAddJogadores.Size = new System.Drawing.Size(263, 29);
            this.lblTituloAddJogadores.TabIndex = 53;
            this.lblTituloAddJogadores.Text = "Jogadores da Partida";
            // 
            // lblVersao2
            // 
            this.lblVersao2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVersao2.AutoSize = true;
            this.lblVersao2.Location = new System.Drawing.Point(1254, 547);
            this.lblVersao2.Name = "lblVersao2";
            this.lblVersao2.Size = new System.Drawing.Size(0, 13);
            this.lblVersao2.TabIndex = 54;
            // 
            // btnVoltar2
            // 
            this.btnVoltar2.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnVoltar2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar2.Location = new System.Drawing.Point(21, 24);
            this.btnVoltar2.Name = "btnVoltar2";
            this.btnVoltar2.Size = new System.Drawing.Size(33, 49);
            this.btnVoltar2.TabIndex = 55;
            this.btnVoltar2.Text = "❮";
            this.btnVoltar2.UseVisualStyleBackColor = false;
            this.btnVoltar2.Click += new System.EventHandler(this.btnVoltar2_Click_1);
            // 
            // dgvJogadores
            // 
            this.dgvJogadores.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.dgvJogadores.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvJogadores.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MediumSeaGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvJogadores.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvJogadores.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvJogadores.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvJogadores.Location = new System.Drawing.Point(340, 168);
            this.dgvJogadores.Name = "dgvJogadores";
            this.dgvJogadores.RowHeadersWidth = 51;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.MediumAquamarine;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Teal;
            this.dgvJogadores.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvJogadores.RowTemplate.Height = 24;
            this.dgvJogadores.Size = new System.Drawing.Size(253, 327);
            this.dgvJogadores.TabIndex = 56;
            // 
            // FormJogadores
            // 
            this.ClientSize = new System.Drawing.Size(1370, 583);
            this.Controls.Add(this.dgvJogadores);
            this.Controls.Add(this.btnVoltar2);
            this.Controls.Add(this.lblVersao2);
            this.Controls.Add(this.lblTituloAddJogadores);
            this.Controls.Add(this.btnCadastrarNovoJogador);
            this.Controls.Add(this.btnProximo);
            this.Controls.Add(this.lblSenhaGeradaa);
            this.Controls.Add(this.bntListaJogadores);
            this.Controls.Add(this.lblSenhaGeradaJogador);
            this.Name = "FormJogadores";
            ((System.ComponentModel.ISupportInitialize)(this.dgvJogadores)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bntIniciar;
        private System.Windows.Forms.TextBox txtIdJogador;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblIdJogador;
        private System.Windows.Forms.Label lblSenhaJogador;
        private System.Windows.Forms.Label lblSenhaGeradaJogador;
        private System.Windows.Forms.Button bntListaJogadores;
        private System.Windows.Forms.Label lblSenhaGeradaa;
        private System.Windows.Forms.Label lblIdGeradoJogado;
        private System.Windows.Forms.Button btnProximo;
        private System.Windows.Forms.Button btnCadastrarNovoJogador;
        private System.Windows.Forms.Label lblTituloAddJogadores;
        private System.Windows.Forms.Label lblVersao2;
        private System.Windows.Forms.Button btnVoltar2;
        private System.Windows.Forms.DataGridView dgvJogadores;
    }
}