namespace Extintos
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNomedaPartida = new System.Windows.Forms.Label();
            this.txtNomedaPartida = new System.Windows.Forms.TextBox();
            this.lblSenhadaPartida = new System.Windows.Forms.Label();
            this.txtSenhadaPartida = new System.Windows.Forms.TextBox();
            this.lblNomedoGrupo = new System.Windows.Forms.Label();
            this.txtNomedoGrupo = new System.Windows.Forms.TextBox();
            this.btnCriarPartida = new System.Windows.Forms.Button();
            this.lblIdGerado = new System.Windows.Forms.Label();
            this.lblDraftosaurus = new System.Windows.Forms.Label();
            this.lblVersao = new System.Windows.Forms.Label();
            this.btnIrPartidaExistente = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNomedaPartida
            // 
            this.lblNomedaPartida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNomedaPartida.AutoSize = true;
            this.lblNomedaPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomedaPartida.Location = new System.Drawing.Point(352, 127);
            this.lblNomedaPartida.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNomedaPartida.Name = "lblNomedaPartida";
            this.lblNomedaPartida.Size = new System.Drawing.Size(115, 15);
            this.lblNomedaPartida.TabIndex = 13;
            this.lblNomedaPartida.Text = "Nome da Partida";
            // 
            // txtNomedaPartida
            // 
            this.txtNomedaPartida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNomedaPartida.Location = new System.Drawing.Point(352, 152);
            this.txtNomedaPartida.Margin = new System.Windows.Forms.Padding(2);
            this.txtNomedaPartida.Name = "txtNomedaPartida";
            this.txtNomedaPartida.Size = new System.Drawing.Size(102, 20);
            this.txtNomedaPartida.TabIndex = 14;
            this.txtNomedaPartida.TextChanged += new System.EventHandler(this.txtNomedaPartida_TextChanged);
            // 
            // lblSenhadaPartida
            // 
            this.lblSenhadaPartida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblSenhadaPartida.AutoSize = true;
            this.lblSenhadaPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSenhadaPartida.Location = new System.Drawing.Point(352, 187);
            this.lblSenhadaPartida.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSenhadaPartida.Name = "lblSenhadaPartida";
            this.lblSenhadaPartida.Size = new System.Drawing.Size(118, 15);
            this.lblSenhadaPartida.TabIndex = 15;
            this.lblSenhadaPartida.Text = "Senha da Partida";
            // 
            // txtSenhadaPartida
            // 
            this.txtSenhadaPartida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtSenhadaPartida.Location = new System.Drawing.Point(352, 212);
            this.txtSenhadaPartida.Margin = new System.Windows.Forms.Padding(2);
            this.txtSenhadaPartida.Name = "txtSenhadaPartida";
            this.txtSenhadaPartida.Size = new System.Drawing.Size(102, 20);
            this.txtSenhadaPartida.TabIndex = 16;
            this.txtSenhadaPartida.TextChanged += new System.EventHandler(this.txtSenhadaPartida_TextChanged);
            // 
            // lblNomedoGrupo
            // 
            this.lblNomedoGrupo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblNomedoGrupo.AutoSize = true;
            this.lblNomedoGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomedoGrupo.Location = new System.Drawing.Point(356, 246);
            this.lblNomedoGrupo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNomedoGrupo.Name = "lblNomedoGrupo";
            this.lblNomedoGrupo.Size = new System.Drawing.Size(108, 15);
            this.lblNomedoGrupo.TabIndex = 17;
            this.lblNomedoGrupo.Text = "Nome do Grupo";
            // 
            // txtNomedoGrupo
            // 
            this.txtNomedoGrupo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtNomedoGrupo.BackColor = System.Drawing.SystemColors.Menu;
            this.txtNomedoGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomedoGrupo.Location = new System.Drawing.Point(352, 268);
            this.txtNomedoGrupo.Margin = new System.Windows.Forms.Padding(2);
            this.txtNomedoGrupo.Name = "txtNomedoGrupo";
            this.txtNomedoGrupo.Size = new System.Drawing.Size(102, 21);
            this.txtNomedoGrupo.TabIndex = 18;
            this.txtNomedoGrupo.Text = "Extintos";
            this.txtNomedoGrupo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCriarPartida
            // 
            this.btnCriarPartida.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnCriarPartida.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnCriarPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCriarPartida.Location = new System.Drawing.Point(278, 313);
            this.btnCriarPartida.Margin = new System.Windows.Forms.Padding(2);
            this.btnCriarPartida.Name = "btnCriarPartida";
            this.btnCriarPartida.Size = new System.Drawing.Size(114, 77);
            this.btnCriarPartida.TabIndex = 19;
            this.btnCriarPartida.Text = "Criar Partida";
            this.btnCriarPartida.UseVisualStyleBackColor = false;
            this.btnCriarPartida.Click += new System.EventHandler(this.btnCriarPartida_Click);
            // 
            // lblIdGerado
            // 
            this.lblIdGerado.AutoSize = true;
            this.lblIdGerado.Location = new System.Drawing.Point(443, 451);
            this.lblIdGerado.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdGerado.Name = "lblIdGerado";
            this.lblIdGerado.Size = new System.Drawing.Size(0, 13);
            this.lblIdGerado.TabIndex = 21;
            // 
            // lblDraftosaurus
            // 
            this.lblDraftosaurus.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblDraftosaurus.AutoSize = true;
            this.lblDraftosaurus.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDraftosaurus.Location = new System.Drawing.Point(272, 52);
            this.lblDraftosaurus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDraftosaurus.Name = "lblDraftosaurus";
            this.lblDraftosaurus.Size = new System.Drawing.Size(293, 37);
            this.lblDraftosaurus.TabIndex = 22;
            this.lblDraftosaurus.Text = "DRAFTOSAURUS";
            // 
            // lblVersao
            // 
            this.lblVersao.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblVersao.AutoSize = true;
            this.lblVersao.Location = new System.Drawing.Point(756, 468);
            this.lblVersao.Name = "lblVersao";
            this.lblVersao.Size = new System.Drawing.Size(0, 13);
            this.lblVersao.TabIndex = 23;
            // 
            // btnIrPartidaExistente
            // 
            this.btnIrPartidaExistente.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnIrPartidaExistente.BackColor = System.Drawing.Color.MediumAquamarine;
            this.btnIrPartidaExistente.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIrPartidaExistente.Location = new System.Drawing.Point(416, 313);
            this.btnIrPartidaExistente.Margin = new System.Windows.Forms.Padding(2);
            this.btnIrPartidaExistente.Name = "btnIrPartidaExistente";
            this.btnIrPartidaExistente.Size = new System.Drawing.Size(112, 77);
            this.btnIrPartidaExistente.TabIndex = 24;
            this.btnIrPartidaExistente.Text = "Ir para o lobby";
            this.btnIrPartidaExistente.UseVisualStyleBackColor = false;
            this.btnIrPartidaExistente.Click += new System.EventHandler(this.btnIrPartidaExistente_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 500);
            this.Controls.Add(this.btnIrPartidaExistente);
            this.Controls.Add(this.lblVersao);
            this.Controls.Add(this.lblDraftosaurus);
            this.Controls.Add(this.lblIdGerado);
            this.Controls.Add(this.btnCriarPartida);
            this.Controls.Add(this.txtNomedoGrupo);
            this.Controls.Add(this.lblNomedoGrupo);
            this.Controls.Add(this.txtSenhadaPartida);
            this.Controls.Add(this.lblSenhadaPartida);
            this.Controls.Add(this.txtNomedaPartida);
            this.Controls.Add(this.lblNomedaPartida);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblNomedaPartida;
        private System.Windows.Forms.TextBox txtNomedaPartida;
        private System.Windows.Forms.Label lblSenhadaPartida;
        private System.Windows.Forms.TextBox txtSenhadaPartida;
        private System.Windows.Forms.Label lblNomedoGrupo;
        private System.Windows.Forms.TextBox txtNomedoGrupo;
        private System.Windows.Forms.Button btnCriarPartida;
        private System.Windows.Forms.Label lblIdGerado;
        private System.Windows.Forms.Label lblDraftosaurus;
        private System.Windows.Forms.Label lblVersao;
        private System.Windows.Forms.Button btnIrPartidaExistente;
    }
}

