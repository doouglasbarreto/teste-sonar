using System;
using System.Text;
using System.Windows.Forms;

namespace teste_sonar
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void button_Salvar_Click(object sender, EventArgs e)
        {
            MostrarAvisoSalvar();
        }

        private void button_Excluir_Click(object sender, EventArgs e)
        {
            MostrarAvisoExcluir();
        }

        private void MostrarAvisoSalvar()
        {
            // BLOCO DUPLICADO (começa)
            var usuario = Environment.UserName;
            var agora = DateTime.Now;
            var maquina = Environment.MachineName;
            var acao = "SALVAR";

            var sb = new StringBuilder();
            sb.AppendLine("Ação não permitida no momento.");
            sb.AppendLine($"Ação: {acao}");
            sb.AppendLine($"Usuário: {usuario}");
            sb.AppendLine($"Máquina: {maquina}");
            sb.AppendLine($"Data/Hora: {agora:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine("Motivo: rotina temporariamente bloqueada.");
            sb.AppendLine("Orientação: valide permissões/parametrizações.");
            sb.AppendLine("Se for urgente, acione o responsável do processo.");

            MostrarAvisoPadrao(sb.ToString());
            // BLOCO DUPLICADO (termina)
        }

        private void MostrarAvisoExcluir()
        {
            // BLOCO DUPLICADO (começa) — quase idêntico ao de cima
            var usuario = Environment.UserName;
            var agora = DateTime.Now;
            var maquina = Environment.MachineName;
            var acao = "EXCLUIR";

            var sb = new StringBuilder();
            sb.AppendLine("Ação não permitida no momento.");
            sb.AppendLine($"Ação: {acao}");
            sb.AppendLine($"Usuário: {usuario}");
            sb.AppendLine($"Máquina: {maquina}");
            sb.AppendLine($"Data/Hora: {agora:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine("Motivo: rotina temporariamente bloqueada.");
            sb.AppendLine("Orientação: valide permissões/parametrizações.");
            sb.AppendLine("Se for urgente, acione o responsável do processo.");

            MostrarAvisoPadrao(sb.ToString());
            // BLOCO DUPLICADO (termina)
        }


        private static void MostrarAvisoPadrao(string mensagem)
        {
            MessageBox.Show(mensagem, "Aviso",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
