using GestaoHospitalar.Enums;

namespace GestaoHospitalar.Entities {
    internal class AtendimentoInternacao : Atendimento {
        public int Diarias { get; private set; }
        public AtendimentoInternacao(string paciente, string cpf, PrioridadeAtendimento prioridade, int diarias) : base(paciente, cpf, TipoAtendimento.Internacao, prioridade) {

            Diarias = diarias;
        }
        protected override decimal CustoBase() => Diarias;
        public override decimal CustoTotal() {
            throw new NotImplementedException();
        }
        public override TimeSpan Duracao() {
            throw new NotImplementedException();
        }
    }
}
