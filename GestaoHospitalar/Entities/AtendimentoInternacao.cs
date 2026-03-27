using System.Globalization;
using System.Text;
using GestaoHospitalar.Enums;
using GestaoHospitalar.Services;

namespace GestaoHospitalar.Entities {

    internal class AtendimentoInternacao : Atendimento, IInformacao {

        public int Diarias { get; private set; }

        public AtendimentoInternacao(string paciente, string cpf, PrioridadeAtendimento prioridade, int diarias) : base(paciente, cpf, TipoAtendimento.Internacao, prioridade) {

            if (diarias < 1 || diarias > 30) {

                throw new ArgumentException("Quantidade inválida!");
            }

            Diarias = diarias;
        }

        protected override decimal CustoBase() => 800m * Diarias;

        private decimal TaxaMonitoramento() => 200m * Diarias;

        protected override decimal TaxaAdicional() => Prioridade == PrioridadeAtendimento.Urgente ? CustoBase() * 0.30m : 0m;

        public override TimeSpan Duracao() => Diarias * TimeSpan.FromHours(24);

        public override decimal CustoTotal() => CustoBase() + TaxaAdicional() + TaxaMonitoramento();

        public string LerInformacaoEspecifica() {

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Diárias: {Diarias}");

            if (Prioridade == PrioridadeAtendimento.Urgente) {

                sb.AppendLine($"Adicional urgente (30%): R${TaxaAdicional().ToString("F2", CultureInfo.InvariantCulture)}");
            }

            sb.AppendLine($"Taxa de monitoramento: R${TaxaMonitoramento().ToString("F2", CultureInfo.InvariantCulture)}");
            sb.AppendLine($"Custo total: R${CustoTotal().ToString("F2", CultureInfo.InvariantCulture)}");
            sb.Append($"Duração estimada: {(int)Duracao().TotalHours} hora(s)");

            return sb.ToString();
        }
    }
}
