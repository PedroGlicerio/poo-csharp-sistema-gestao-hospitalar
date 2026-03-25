using GestaoHospitalar.Enums;

namespace GestaoHospitalar.Entities {
    internal class AtendimentoInternacao : Atendimento {
        public int Diarias { get; private set; }
        public AtendimentoInternacao(string paciente, string cpf, PrioridadeAtendimento prioridade, int diarias) : base(paciente, cpf, TipoAtendimento.Internacao, prioridade) {

            Diarias = diarias;
        }
    }
}
