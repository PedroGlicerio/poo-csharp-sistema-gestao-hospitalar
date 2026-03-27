using System.Globalization;
using GestaoHospitalar.Entities;
using GestaoHospitalar.Enums;

class Program {

    public static void Main(string[] args) {

        List<Atendimento> atendimentos = new List<Atendimento>();

        Console.WriteLine("=== SISTEMA DE GESTÃO HOSPITALAR ===");

        Console.WriteLine();

        int quantidadeAtendimentos = LerNumeroInteiro("Quantos atendimentos serão cadastrados: ", "Quantidade inválida! Por favor, digite um número maior que zero.",  0, int.MaxValue);

        for (int i = 0; i < quantidadeAtendimentos; i++) {

            Console.WriteLine();

            Console.WriteLine($"Atendimento #{i + 1}:");
            Atendimento atendimento = LerDadosPaciente();
            atendimentos.Add(atendimento);
        }

        Console.WriteLine();
        Console.WriteLine("=== ATUALIZAÇÃO DE STATUS ===");
        
        foreach (var atendimento in atendimentos) {

            Console.WriteLine();

            Console.WriteLine($"{atendimento.ExibirStatusAtendimento()}");
            StatusAtendimento novoStatus = LerEnum<StatusAtendimento>("Novo status [0 - Agendado | 1 - Em Atendimento | 2 - Finalizado]: ", "Status inválido! Por favor, digite novamente.");
            atendimento.AtualizarStatus(novoStatus);
        }

        Console.WriteLine();
        Console.WriteLine("=== RELATÓRIO DE ATENDIMENTOS ===");
        Console.WriteLine();

        foreach (var atendimento in atendimentos.OrderByDescending(x => x.Prioridade == PrioridadeAtendimento.Urgente).ThenByDescending(x => x.CustoTotal())) {

            Console.WriteLine($"{atendimento}");
        }

        Console.WriteLine($"Total de atendimentos: {atendimentos.Count}");
        Console.WriteLine($"Consultas: R${atendimentos.Where(x => x.Tipo == TipoAtendimento.Consulta).Sum(x => x.CustoTotal()).ToString("F2", CultureInfo.InvariantCulture)}");
        Console.WriteLine($"Exames: R${atendimentos.Where(x => x.Tipo == TipoAtendimento.Exame).Sum(x => x.CustoTotal()).ToString("F2", CultureInfo.InvariantCulture)}");
        Console.WriteLine($"Internações: R${atendimentos.Where(x => x.Tipo == TipoAtendimento.Internacao).Sum(x => x.CustoTotal()).ToString("F2", CultureInfo.InvariantCulture)}");
        Console.WriteLine($"Total geral: R${atendimentos.Sum(x => x.CustoTotal()).ToString("F2", CultureInfo.InvariantCulture)}");

        static string LerNome(string mensagem, string mensagemValidacao) {

            string nome;
            bool valido;

            do {

                Console.Write(mensagem);
                nome = Console.ReadLine();

                valido = !string.IsNullOrEmpty(nome) && nome.All(x => char.IsLetter(x) || char.IsWhiteSpace(x));

                if (!valido) {

                    Console.WriteLine(mensagemValidacao);
                }

            } while (!valido);

            return nome;
        }

        static string LerCpf(string mensagem, string mensagemValidacao) {

            string cpf;
            bool valido;

            do {

                Console.Write(mensagem);
                cpf = Console.ReadLine();

                valido = !string.IsNullOrEmpty(cpf) && cpf.Length == 11 && cpf.All(char.IsDigit);

                if (!valido) {

                    Console.WriteLine(mensagemValidacao);
                }

            } while (!valido);

            return cpf;
        }

        static TEnum LerEnum<TEnum>(string mensagem, string mensagemValidacao) where TEnum : struct, Enum {

            TEnum valor;
            bool valido;

            do {

                Console.Write(mensagem);
                valido = Enum.TryParse(Console.ReadLine(), true, out valor) && Enum.IsDefined(typeof(TEnum), valor);

                if (!valido) {

                    Console.WriteLine(mensagemValidacao);
                }

            } while (!valido);

            return valor;
        }

        static int LerNumeroInteiro(string mensagem, string mensagemValidacao, int min, int max) {

            int numero;
            bool valido;

            do {

                Console.Write(mensagem);
                valido = int.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out numero);

                if (!valido || numero <= min || numero > max) {

                    Console.WriteLine(mensagemValidacao);
                    valido = false;
                }

            } while (!valido);

            return numero;
        }

        static Atendimento LerDadosPaciente() {

            string paciente = LerNome("Paciente: ", "Nome inválido! Por favor, digite novamente.");
            string cpf = LerCpf("CPF: ", "CPF inválido! O CPF deve conter 11 dígitos, por favor, digite novamente.");
            TipoAtendimento tipo = LerEnum<TipoAtendimento>("Tipo [0 - Consulta | 1 - Exame | 2 - Internação]: ", "Tipo inválido! Por favor, digite novamente.");
            PrioridadeAtendimento prioridade = LerEnum<PrioridadeAtendimento>("Prioridade [0 - Normal | 1 - Urgente]: ", "Prioridade inválida! Por favor, digite novamente.");

            switch (tipo) {

                case TipoAtendimento.Consulta:

                    return new AtendimentoConsulta(paciente, cpf, prioridade);

                case TipoAtendimento.Exame:

                    int exames = LerNumeroInteiro("Quantidade de exames: ", "Quantidade inválida! Por favor, digite novamente [entre 1 e 10].", 0, 10);
                    return new AtendimentoExame(paciente, cpf, prioridade, exames);

                case TipoAtendimento.Internacao:

                    int diarias = LerNumeroInteiro("Diárias: ", "Quantidade inválida! Por favor, digite novamente [entre 1 e 30].", 0, 30);
                    return new AtendimentoInternacao(paciente, cpf, prioridade, diarias);

                default:

                    throw new ArgumentException("Tipo inválido!");
            }
        }
    }
}