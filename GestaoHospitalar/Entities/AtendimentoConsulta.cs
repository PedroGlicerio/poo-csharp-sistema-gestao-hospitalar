using System.Globalization;
using System.Text;
using GestaoHospitalar.Enums;
using GestaoHospitalar.Services;

namespace GestaoHospitalar.Entities {

    internal class AtendimentoConsulta : Atendimento, IInformacao {

        public AtendimentoConsulta(string paciente, string cpf, PrioridadeAtendimento prioridade) : base(paciente, cpf, TipoAtendimento.Consulta, prioridade) {
        }

        protected override decimal CustoBase() => 200m;

        public override TimeSpan Duracao() => TimeSpan.FromHours(1);

        public override decimal CustoTotal() => CustoBase() + TaxaAdicional();

        public string LerInformacaoEspecifica() {

            StringBuilder sb = new StringBuilder();

            if (Prioridade == PrioridadeAtendimento.Urgente) {

                sb.AppendLine($"Adicional urgente (50%): R${TaxaAdicional().ToString("F2", CultureInfo.InvariantCulture)}");
            }

            sb.AppendLine($"Custo total: R${CustoTotal().ToString("F2", CultureInfo.InvariantCulture)}");
            sb.Append($"Duração estimada: {(int)Duracao().TotalHours} hora(s)");

            return sb.ToString();
        }
    }
}
