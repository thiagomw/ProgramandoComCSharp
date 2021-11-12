using System;
using System.Globalization;

namespace CSharp.Capitulo01.ValeTransporte
{
    class Program
    {
        static void Main(string[] args)
        {
        Inicio:

            Console.Write("Funcionário: ");
            var nome = Console.ReadLine();

            Console.Write("Salário: ");
            var salario = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Transporte: ");
            var gastoComTransporte = Convert.ToDecimal(Console.ReadLine());

            var descontoMaximo = salario * 0.06m;

            var descontoVT = gastoComTransporte > descontoMaximo ? descontoMaximo : gastoComTransporte;

            var resultado = $"\nFuncionário: {nome}\n" +
                            $"Salário: {salario.ToString("C", new CultureInfo("pt-BR"))}\n" +
                            $"Desconto VT: {descontoVT:c2}"; //:c2 formato de moeda com duas casas decimais

            Console.WriteLine(resultado);

            Console.WriteLine("\nPressione ENTER para novo cálculo ou ESC para sair.");

            var comando = Console.ReadKey();

            if (comando.Key == ConsoleKey.Escape)
            {
                Environment.Exit(0);
            }

            Console.Clear();

            goto Inicio;
        }

        private static CultureInfo NewMethod()
        {
            return new System.Globalization.CultureInfo("pt-BR");
        }
    }
}
