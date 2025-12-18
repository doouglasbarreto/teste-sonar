using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace teste_sonar
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();

            // Se quiser disparar manualmente algum cenário em runtime,
            // pode chamar aqui, ou amarrar em botões:
            // Sonar_Regra01_UsarIgualIgualQuandoEqualsFoiSobrescrito();
        }

        private void button_Salvar_Click(object sender, EventArgs e)
        {
            MostrarAvisoSalvar();
        }

        private void button_Excluir_Click(object sender, EventArgs e)
        {
            MostrarAvisoExcluir();
        }

        // ==========================================================
        // SEU CENÁRIO COM REDUNDÂNCIA (duplicação real)
        // ==========================================================
        private static void MostrarAvisoSalvar()
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

        private static void MostrarAvisoExcluir()
        {
            // BLOCO DUPLICADO (começa)
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

        // “corrigido” como estático (o ponto que ele levantou antes)
        private static void MostrarAvisoPadrao(string mensagem)
        {
            MessageBox.Show(mensagem, "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ==========================================================
        // CENÁRIOS PARA VIOLAR REGRAS (um por regra)
        // ==========================================================

        // REGRA 1: "==" should not be used when "Equals" is overridden
        private void Sonar_Regra01_UsarIgualIgualQuandoEqualsFoiSobrescrito()
        {
            var a = new Pedido(10);
            var b = new Pedido(10);

            if (a == b) // <-- viola (deveria usar a.Equals(b))
                MostrarAvisoPadrao("Comparou com '==' mesmo com Equals sobrescrito.");
        }

        // REGRA 2: "[DefaultValue]" should not be used when "[DefaultParameterValue]" is meant
        private void Sonar_Regra02_DefaultValueErrado([Optional, DefaultValue(10)] int tentativas) // <-- viola
        {
            MostrarAvisoPadrao($"Tentativas: {tentativas}");
        }

        // REGRA 4: "[Optional]" should not be used on "ref" or "out" parameters
        private void Sonar_Regra04_OptionalComOut([Optional] out int valor) // <-- viola
        {
            valor = 1;
        }

        // REGRA 5: "abstract" classes should not have "public" constructors
        private void Sonar_Regra05_AbstractComConstrutorPublico()
        {
            var v = new ValidadorConcreto();
            v.Validar();
        }

        // REGRA 6: "Any()" should be used to test for emptiness
        private void Sonar_Regra06_CountParaVazio()
        {
            IEnumerable<int> itens = new List<int>();

            if (itens.Count() == 0) // <-- viola (use !itens.Any())
                MostrarAvisoPadrao("Vazio (testado com Count() == 0).");
        }

        // REGRA 7: "Assembly.GetExecutingAssembly" should not be called
        private void Sonar_Regra07_GetExecutingAssembly()
        {
            var asm = Assembly.GetExecutingAssembly(); // <-- viola
            MostrarAvisoPadrao(asm.FullName);
        }

        // REGRA 8: "Assembly.Load" should be used (violação típica: LoadFrom/LoadFile)
        private void Sonar_Regra08_AssemblyLoadFrom()
        {
            var caminhoDll = @"C:\temp\minha.dll";
            var asm = Assembly.LoadFrom(caminhoDll); // <-- viola
            MostrarAvisoPadrao(asm.FullName);
        }

        // REGRA 9: "async" and "await" should not be used as identifiers
        private void Sonar_Regra09_AsyncAwaitComoIdentificador()
        {
            int @async = 10;     // <-- viola
            string @await = "x"; // <-- viola
            MostrarAvisoPadrao($"{@async} - {@await}");
        }

        // REGRA 10: "async" methods should not return "void" (fora de event handler)
        private async void Sonar_Regra10_AsyncVoidForaDeEventHandler() // <-- viola
        {
            await Task.Delay(50);
            MostrarAvisoPadrao("Async void fora de event handler.");
        }

        // REGRA 11: "base.Equals" should not be used ... se base não é object (contexto típico)
        private void Sonar_Regra11_BaseEqualsEmBaseNaoObject()
        {
            var a = new PessoaVip(1);
            var b = new PessoaVip(1);

            // Só pra ter uso
            MostrarAvisoPadrao($"Equals: {a.Equals(b)}");
        }

        // REGRA 12: "catch" clauses should do more than rethrow
        private void Sonar_Regra12_CatchSoRethrow()
        {
            try
            {
                throw new Exception("boom");
            }
            catch (Exception)
            {
                throw; // <-- viola
            }
        }

        // REGRA 13: "ConfigureAwait(false)" should be used (em código de lib/serviço)
        private async Task<string> Sonar_Regra13_AwaitSemConfigureAwait()
        {
            using var http = new HttpClient();

            // <-- viola (quando a regra estiver habilitada)
            return await http.GetStringAsync("https://example.com");
        }

        // REGRA 15: "Contains" should be used instead of "Any" for simple equality checks
        private void Sonar_Regra15_AnyParaIgualdadeSimples()
        {
            var ids = new List<int> { 1, 2, 3 };
            var alvo = 2;

            if (ids.Any(x => x == alvo)) // <-- viola (use ids.Contains(alvo))
                MostrarAvisoPadrao("Achou (via Any(x => x == alvo)).");
        }

        // ==========================================================
        // CLASSES AUXILIARES (DENTRO DO FORM)
        // ==========================================================

        // Para REGRA 1
        private sealed class Pedido
        {
            public int Id { get; }
            public Pedido(int id) => Id = id;

            public override bool Equals(object obj)
                => obj is Pedido other && other.Id == Id;

            public override int GetHashCode() => Id.GetHashCode();
        }

        // Para REGRA 5
        private abstract class ValidadorBase
        {
            public ValidadorBase() // <-- viola: construtor public em abstract
            {
            }

            public abstract void Validar();
        }

        private sealed class ValidadorConcreto : ValidadorBase
        {
            public override void Validar()
            {
                // nada
            }
        }

        // Para REGRA 11
        private class BasePessoa
        {
            public int Id { get; }
            public BasePessoa(int id) => Id = id;

            public override bool Equals(object obj)
                => obj is BasePessoa other && other.Id == Id;

            public override int GetHashCode() => Id;
        }

        private class PessoaVip : BasePessoa
        {
            public PessoaVip(int id) : base(id) { }

            public override bool Equals(object obj)
            {
                if (base.Equals(obj)) // <-- viola (nesse contexto)
                    return true;

                return false;
            }
        }
    }
}
