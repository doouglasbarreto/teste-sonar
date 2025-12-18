namespace teste_sonar
{
    partial class FrmPrincipal
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            button_Salvar = new Button();
            button_Excluir = new Button();
            SuspendLayout();
            // 
            // button_Salvar
            // 
            button_Salvar.Location = new Point(231, 126);
            button_Salvar.Name = "button_Salvar";
            button_Salvar.Size = new Size(75, 23);
            button_Salvar.TabIndex = 0;
            button_Salvar.Text = "Salvar";
            button_Salvar.UseVisualStyleBackColor = true;
            button_Salvar.Click += button_Salvar_Click;
            // 
            // button_Excluir
            // 
            button_Excluir.Location = new Point(434, 126);
            button_Excluir.Name = "button_Excluir";
            button_Excluir.Size = new Size(75, 23);
            button_Excluir.TabIndex = 1;
            button_Excluir.Text = "Excluir";
            button_Excluir.UseVisualStyleBackColor = true;
            button_Excluir.Click += button_Excluir_Click;
            // 
            // FrmPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button_Excluir);
            Controls.Add(button_Salvar);
            Name = "FrmPrincipal";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private Button button_Salvar;
        private Button button_Excluir;
    }
}
