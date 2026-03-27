using System.Globalization;
using System.Text;
using GestaoHospitalar.Enums;
using GestaoHospitalar.Services;

namespace GestaoHospitalar.Entities {
    internal class AtendimentoExame : Atendimento, IInformacao {
        public int Exames { get; private set; }
        public AtendimentoExame(string paciente, string cpf, PrioridadeAtendimento prioridade, int exames) : base(paciente, cpf, TipoAtendimento.Exame, prioridade) {

            if (exames < 1 || exames > 10) {

                throw new ArgumentException("Quantidade inválida!");
            }

            Exames = exames;
        }

        protected override decimal CustoBase() => 150m * Exames;
        private decimal CalcularDesconto() => Exames > 3 ? CustoBase() * 0.10m : 0m;
        public override TimeSpan Duracao() => Exames * TimeSpan.FromMinutes(30);
        public override decimal CustoTotal() {

            return CustoBase() - CalcularDesconto();
        }
        public string LerInformacaoEspecifica() {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Quantidade de exames: {Exames}");

            if (Exames > 3) {

                sb.AppendLine($"Desconto (10%): R${CalcularDesconto().ToString("F2", CultureInfo.InvariantCulture)}");

            }

            sb.AppendLine($"Custo total: R${CustoTotal().ToString("F2", CultureInfo.InvariantCulture)}");
            sb.Append($"Duração estimada: {(int)Duracao().TotalMinutes} minuto(s)");

            return sb.ToString();
        }
    }
}
