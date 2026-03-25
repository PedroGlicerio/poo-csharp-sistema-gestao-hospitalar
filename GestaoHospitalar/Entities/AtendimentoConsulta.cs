using GestaoHospitalar.Enums;

namespace GestaoHospitalar.Entities {
    internal class AtendimentoConsulta : Atendimento {
        public AtendimentoConsulta(string paciente, string cpf, PrioridadeAtendimento prioridade) : base(paciente, cpf, TipoAtendimento.Consulta, prioridade) {
        }
    }
}
