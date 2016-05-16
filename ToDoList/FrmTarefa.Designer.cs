namespace ToDoList
{
    partial class FrmTarefa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTarefa));
            this.TxTitulo = new System.Windows.Forms.TextBox();
            this.TxDescricao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtAdd = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.CbProgramador = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CbProjeto = new System.Windows.Forms.ComboBox();
            this.DtPrazo = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.CbStatus = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TxTitulo
            // 
            this.TxTitulo.Location = new System.Drawing.Point(12, 85);
            this.TxTitulo.Name = "TxTitulo";
            this.TxTitulo.Size = new System.Drawing.Size(595, 20);
            this.TxTitulo.TabIndex = 0;
            // 
            // TxDescricao
            // 
            this.TxDescricao.Location = new System.Drawing.Point(12, 137);
            this.TxDescricao.Multiline = true;
            this.TxDescricao.Name = "TxDescricao";
            this.TxDescricao.Size = new System.Drawing.Size(595, 139);
            this.TxDescricao.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Titulo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Descrição";
            // 
            // BtAdd
            // 
            this.BtAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtAdd.Location = new System.Drawing.Point(532, 24);
            this.BtAdd.Name = "BtAdd";
            this.BtAdd.Size = new System.Drawing.Size(75, 23);
            this.BtAdd.TabIndex = 9;
            this.BtAdd.Text = "Adicionar";
            this.BtAdd.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Programador";
            // 
            // CbProgramador
            // 
            this.CbProgramador.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CbProgramador.FormattingEnabled = true;
            this.CbProgramador.Location = new System.Drawing.Point(135, 26);
            this.CbProgramador.Name = "CbProgramador";
            this.CbProgramador.Size = new System.Drawing.Size(101, 21);
            this.CbProgramador.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Projeto";
            // 
            // CbProjeto
            // 
            this.CbProjeto.FormattingEnabled = true;
            this.CbProjeto.Location = new System.Drawing.Point(12, 27);
            this.CbProjeto.Name = "CbProjeto";
            this.CbProjeto.Size = new System.Drawing.Size(98, 21);
            this.CbProjeto.TabIndex = 5;
            // 
            // DtPrazo
            // 
            this.DtPrazo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DtPrazo.Location = new System.Drawing.Point(379, 27);
            this.DtPrazo.Name = "DtPrazo";
            this.DtPrazo.Size = new System.Drawing.Size(147, 20);
            this.DtPrazo.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(376, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Prazo";
            // 
            // CbStatus
            // 
            this.CbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CbStatus.FormattingEnabled = true;
            this.CbStatus.Location = new System.Drawing.Point(259, 26);
            this.CbStatus.Name = "CbStatus";
            this.CbStatus.Size = new System.Drawing.Size(105, 21);
            this.CbStatus.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(256, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Status";
            // 
            // FrmTarefa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 286);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.CbStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.DtPrazo);
            this.Controls.Add(this.BtAdd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CbProgramador);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CbProjeto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TxDescricao);
            this.Controls.Add(this.TxTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTarefa";
            this.Text = "FrmTarefa";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxTitulo;
        private System.Windows.Forms.TextBox TxDescricao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtAdd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox CbProgramador;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox CbProjeto;
        private System.Windows.Forms.DateTimePicker DtPrazo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox CbStatus;
        private System.Windows.Forms.Label label6;
    }
}