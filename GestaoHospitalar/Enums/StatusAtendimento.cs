namespace GestaoHospitalar.Enums {
    enum StatusAtendimento : int {

        Agendado = 0, 
        EmAtendimento = 1,
        Finalizado = 2
    }

    static class StatusAtendimentoExtensions {
        public static string ToDisplayString(this StatusAtendimento status) => status switch {StatusAtendimento.EmAtendimento => "Em Atendimento",_ => status.ToString()};
    }
}
