namespace ToDoList
{
    partial class FrmCadastro
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCadastro));
            this.panel1 = new System.Windows.Forms.Panel();
            this.LbTexto = new System.Windows.Forms.Label();
            this.BtRemove = new System.Windows.Forms.Button();
            this.BtAdd = new System.Windows.Forms.Button();
            this.TxProgramador = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.LstProgramadores = new System.Windows.Forms.ListView();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.LbTexto);
            this.panel1.Controls.Add(this.BtRemove);
            this.panel1.Controls.Add(this.BtAdd);
            this.panel1.Controls.Add(this.TxProgramador);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(240, 62);
            this.panel1.TabIndex = 0;
            // 
            // LbTexto
            // 
            this.LbTexto.AutoSize = true;
            this.LbTexto.Location = new System.Drawing.Point(3, 17);
            this.LbTexto.Name = "LbTexto";
            this.LbTexto.Size = new System.Drawing.Size(42, 13);
            this.LbTexto.TabIndex = 3;
            this.LbTexto.Text = "Lbtexto";
            // 
            // BtRemove
            // 
            this.BtRemove.Location = new System.Drawing.Point(209, 30);
            this.BtRemove.Name = "BtRemove";
            this.BtRemove.Size = new System.Drawing.Size(28, 23);
            this.BtRemove.TabIndex = 2;
            this.BtRemove.Text = "-";
            this.BtRemove.UseVisualStyleBackColor = true;
            // 
            // BtAdd
            // 
            this.BtAdd.Location = new System.Drawing.Point(175, 30);
            this.BtAdd.Name = "BtAdd";
            this.BtAdd.Size = new System.Drawing.Size(28, 23);
            this.BtAdd.TabIndex = 1;
            this.BtAdd.Text = "+";
            this.BtAdd.UseVisualStyleBackColor = true;
            // 
            // TxProgramador
            // 
            this.TxProgramador.Location = new System.Drawing.Point(3, 33);
            this.TxProgramador.Name = "TxProgramador";
            this.TxProgramador.Size = new System.Drawing.Size(166, 20);
            this.TxProgramador.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.LstProgramadores);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 62);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(240, 293);
            this.panel2.TabIndex = 1;
            // 
            // LstProgramadores
            // 
            this.LstProgramadores.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstProgramadores.Location = new System.Drawing.Point(0, 0);
            this.LstProgramadores.Name = "LstProgramadores";
            this.LstProgramadores.Size = new System.Drawing.Size(240, 293);
            this.LstProgramadores.TabIndex = 0;
            this.LstProgramadores.UseCompatibleStateImageBehavior = false;
            // 
            // FrmCadastro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 355);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmCadastro";
            this.Text = "Usuarios";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LbTexto;
        private System.Windows.Forms.Button BtRemove;
        private System.Windows.Forms.Button BtAdd;
        private System.Windows.Forms.TextBox TxProgramador;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView LstProgramadores;
    }
}