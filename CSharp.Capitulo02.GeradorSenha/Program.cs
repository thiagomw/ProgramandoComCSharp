using System;

namespace CSharp.Capitulo02.GeradorSenha
{
    class Program
    {
        static void Main(string[] args)
        {

            int qtdDigitos;

            do
            {
                Console.Write("Informe a quantidade de dígitos entre 4 e 10: ");
                qtdDigitos = ObterQuantidadeDigitos();
            
            } while (qtdDigitos == 0);

            Console.WriteLine($"Senha gerada: {new Senha(qtdDigitos).Valor}");
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
