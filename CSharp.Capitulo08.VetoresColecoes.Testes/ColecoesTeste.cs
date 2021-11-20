using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.Capitulo08.VetoresColecoes.Testes
{
    [TestClass]
    public class ColecoesTeste
    {
        [TestMethod]
        public void ListTeste()
        {
            var inteiros = new List<int> {12, -8, 76, 15};

            inteiros.Add(17);
            inteiros[0] = 20;
            inteiros.Add(100);

            var maisInteiros = new List<int> {16,38,-7, -8};

            inteiros.AddRange(maisInteiros);

            inteiros.Insert(2, 42);

            inteiros.Remove(42);

            inteiros.RemoveAt(5);

            inteiros.Sort();

            var primeiro = inteiros[0];
            primeiro = inteiros.First();

            var ultimo = inteiros[inteiros.Count - 1];
            ultimo = inteiros.Last();

            foreach (var inteiro in inteiros)
            {
                Console.WriteLine($"{inteiros.IndexOf(inteiro)}: {inteiro}");
            }
        }

        [TestMethod]
        public void DictionaryTeste()
        {
            var feriados = new Dictionary<DateTime, string>();

            feriados.Add(new DateTime(2021, 12, 25), "Natal");
            feriados.Add(new DateTime(2022, 1, 1), "Ano Novo");
            feriados.Add(new DateTime(2021, 11, 20), "Consciência Negra");

            var natal = feriados[new DateTime(2021, 12, 25)];

            foreach (var feriado in feriados.OrderBy(f => f.Key))
            {
                Console.WriteLine($"{feriado.Key:d}: {feriado.Value}");
            }
        }
    }
}