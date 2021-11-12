using System;

namespace CSharp.Capitulo02.GeradorSenha
{
    class Program
    {
        static void Main(string[] args)
        {
            //var qtdDigitos = Convert.ToInt32(Console.ReadLine());

            //if (qtdDigitos < 4 || qtdDigitos > 10 || qtdDigitos % 2 != 0)
            //{
            //    Console.WriteLine($"O valor {qtdDigitos} é inválido de acordo com as regras.");
            //    Console.ReadKey();
            //    return;
            //}

            int qtdDigitos;

            do
            {
                Console.Write("Informe a quantidade de dígitos entre 4 e 10: ");
                qtdDigitos = ObterQuantidadeDigitos();
            
            } while (qtdDigitos == 0);

            var senha = string.Empty;
            var randomico = new Random();

            for (int i = 0; i < qtdDigitos; i++)
            {
                var digito = randomico.Next(10);
                senha += digito;
            }

            Console.WriteLine($"Senha gerada: {senha}");
        }
        private static int ObterQuantidadeDigitos()
        {
            int.TryParse(Console.ReadLine(),out int qtdDigitos);

            //if (qtdDigitos < 4 || qtdDigitos > 10 || qtdDigitos % 2 != 0)
            if (qtdDigitos is < 4 or > 10 || qtdDigitos % 2 != 0)
            {
                Console.WriteLine($"O valor {qtdDigitos} é inválido de acordo com as regras.\n");
                qtdDigitos = 0;
            }

            return qtdDigitos;
        }
    }
}
