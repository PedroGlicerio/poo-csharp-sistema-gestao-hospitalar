using GestaoHospitalar.Enums;

namespace GestaoHospitalar.Entities {
    internal class AtendimentoExame : Atendimento {
        public int Exames { get; private set; }
        public AtendimentoExame(string paciente, string cpf, PrioridadeAtendimento prioridade, int exames) : base(paciente, cpf, TipoAtendimento.Exame, prioridade) {

            Exames = exames;
        }
    }
}
