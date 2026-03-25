using GestaoHospitalar.Enums;

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
    }
}
