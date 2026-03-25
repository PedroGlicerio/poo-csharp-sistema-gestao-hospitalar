using System.Globalization;
using GestaoHospitalar.Entities;
class Program {
    public static void Main(string[] args) {

        List<Atendimento> atendimentos = new List<Atendimento>();

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

        static int LerNumeroInteiro(string mensagem, string mensagemValidacao) {

            int numero;
            bool valido;

            do {

                Console.Write(mensagem);
                valido = int.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out numero);

                if (!valido || numero <= 0) {

                    Console.WriteLine(mensagemValidacao);
                    valido = false;
                }

            } while (!valido);

            return numero;
        }
    }
}