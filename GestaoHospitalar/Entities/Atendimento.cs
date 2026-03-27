using System.Globalization;
using System.Text;
using GestaoHospitalar.Enums;
using GestaoHospitalar.Services;

namespace GestaoHospitalar.Entities {
    internal abstract class Atendimento {

        private static int contador = 1;
         
        public string Codigo { get; private set; }
        public string Paciente { get; init; }
        public string Cpf { get; private set; }
        public TipoAtendimento Tipo { get; private set; }
        public PrioridadeAtendimento Prioridade { get; private set; }
        public StatusAtendimento Status { get; private set; }
        public Atendimento(string paciente, string cpf, TipoAtendimento tipo, PrioridadeAtendimento prioridade) {
            
            if (string.IsNullOrWhiteSpace(paciente)) {

                throw new ArgumentException("Nome inválido!");
            }

            if (cpf.Length != 11 || !cpf.All(char.IsDigit)) {

                throw new ArgumentException("CPF inválido!");
            }

            if (!Enum.IsDefined(typeof(TipoAtendimento), tipo)) {

                throw new ArgumentException("Tipo de atendimento inválido!");
            }

            if (!Enum.IsDefined(typeof(PrioridadeAtendimento), prioridade)) {

                throw new ArgumentException("Prioridade inválida!");
            }

            Codigo = $"ATD-{contador++.ToString("D3")}";
            Paciente = paciente;
            Cpf = cpf;
            Tipo = tipo;
            Prioridade = prioridade;
            Status = StatusAtendimento.Agendado;
            
        }
        public void AtualizarStatus(StatusAtendimento novoStatus) {

            Status = novoStatus;
        }
        public string ExibirStatusAtendimento() => $"[{Codigo}] {Paciente} — {Tipo} | {Prioridade} | Status: {Status.ToDisplayString()}";
        protected virtual decimal TaxaAdicional() => Prioridade == PrioridadeAtendimento.Urgente ? CustoBase() * 0.50m : 0m;
        protected abstract decimal CustoBase();
        public abstract TimeSpan Duracao();
        public abstract decimal CustoTotal(); 
        public override string ToString() {
            
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Código: {Codigo}");
            sb.AppendLine($"Paciente: {Paciente}");
            sb.AppendLine($"CPF: {Cpf.Substring(0, 3)}.{Cpf.Substring(3, 3)}.{Cpf.Substring(6, 3)}-{Cpf.Substring(9, 2)}");
            sb.AppendLine($"Tipo: {Tipo} | Prioridade: {Prioridade}");
            sb.AppendLine($"Custo base: R${CustoBase().ToString("F2", CultureInfo.InvariantCulture)}");

            if (this is IInformacao info) {

                sb.AppendLine(info.LerInformacaoEspecifica());
            }

            sb.AppendLine($"Status: {Status.ToDisplayString()}");
            sb.AppendLine(new string('-', 40));

            return sb.ToString();
        }
    }
}
