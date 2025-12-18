namespace teste_sonar
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void MostrarAvisoSalvar()
        {
            MostrarAvisoPadrao();
        }

        private void MostrarAvisoExcluir()
        {
            MostrarAvisoPadrao();
        }

        // Terceiro método é o que realmente faz algo
        private void MostrarAvisoPadrao()
        {
            MessageBox.Show("Ação não permitida no momento.", "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void button_Salvar_Click(object sender, EventArgs e)
        {
            MostrarAvisoSalvar();
        }

        private void button_Excluir_Click(object sender, EventArgs e)
        {
            MostrarAvisoExcluir();
        }
    }
}
