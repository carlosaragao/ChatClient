namespace ChatCliente
{
    partial class frmCliente
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
            this.txtServidorIP = new System.Windows.Forms.TextBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.txtMensagem = new System.Windows.Forms.TextBox();
            this.btnEnviar = new System.Windows.Forms.Button();
            this.btnConectar = new System.Windows.Forms.Button();
            this.btnIncidentes = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtServidorIP
            // 
            this.txtServidorIP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtServidorIP.Location = new System.Drawing.Point(96, 12);
            this.txtServidorIP.Name = "txtServidorIP";
            this.txtServidorIP.Size = new System.Drawing.Size(170, 20);
            this.txtServidorIP.TabIndex = 0;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(96, 56);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(170, 20);
            this.txtUsuario.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Servidor IP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Usuário";
            // 
            // txtLog
            // 
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLog.Enabled = false;
            this.txtLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(12, 82);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(360, 308);
            this.txtLog.TabIndex = 5;
            // 
            // txtMensagem
            // 
            this.txtMensagem.Location = new System.Drawing.Point(15, 423);
            this.txtMensagem.Multiline = true;
            this.txtMensagem.Name = "txtMensagem";
            this.txtMensagem.Size = new System.Drawing.Size(181, 20);
            this.txtMensagem.TabIndex = 6;
            this.txtMensagem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMensagem_KeyPress);
            // 
            // btnEnviar
            // 
            this.btnEnviar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnEnviar.BackgroundImage = global::ChatCliente.Properties.Resources.enviar32001W;
            this.btnEnviar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnEnviar.CausesValidation = false;
            this.btnEnviar.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnEnviar.FlatAppearance.BorderSize = 0;
            this.btnEnviar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnEnviar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.btnEnviar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnviar.Location = new System.Drawing.Point(308, 400);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(64, 64);
            this.btnEnviar.TabIndex = 7;
            this.btnEnviar.UseVisualStyleBackColor = false;
            this.btnEnviar.Click += new System.EventHandler(this.btnEnviar_Click);
            // 
            // btnConectar
            // 
            this.btnConectar.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnConectar.BackgroundImage = global::ChatCliente.Properties.Resources.conectar32001W;
            this.btnConectar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnConectar.CausesValidation = false;
            this.btnConectar.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.btnConectar.FlatAppearance.BorderSize = 0;
            this.btnConectar.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.HotTrack;
            this.btnConectar.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Highlight;
            this.btnConectar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConectar.ImageAlign = System.Drawing.ContentAlignment.BottomRight;
            this.btnConectar.Location = new System.Drawing.Point(308, 12);
            this.btnConectar.Name = "btnConectar";
            this.btnConectar.Size = new System.Drawing.Size(64, 64);
            this.btnConectar.TabIndex = 2;
            this.btnConectar.UseVisualStyleBackColor = false;
            this.btnConectar.Click += new System.EventHandler(this.btnConectar_Click);
            // 
            // btnIncidentes
            // 
            this.btnIncidentes.Location = new System.Drawing.Point(202, 421);
            this.btnIncidentes.Name = "btnIncidentes";
            this.btnIncidentes.Size = new System.Drawing.Size(100, 23);
            this.btnIncidentes.TabIndex = 8;
            this.btnIncidentes.Text = "Incidentes";
            this.btnIncidentes.UseVisualStyleBackColor = true;
            this.btnIncidentes.Click += new System.EventHandler(this.btnIncidentes_Click);
            // 
            // frmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(384, 476);
            this.Controls.Add(this.btnIncidentes);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.txtMensagem);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConectar);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.txtServidorIP);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(400, 515);
            this.MinimumSize = new System.Drawing.Size(400, 515);
            this.Name = "frmCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat Cliente";
            this.Load += new System.EventHandler(this.frmCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServidorIP;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Button btnConectar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.TextBox txtMensagem;
        private System.Windows.Forms.Button btnEnviar;
        private System.Windows.Forms.Button btnIncidentes;
    }
}

