using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSharp.Capitulo08.VetoresColecoes.Testes
{
    [TestClass]
    public class VetoresTeste
    {
        [TestMethod]
        public void InicializacaoTeste()
        {
            var inteiros = new int[5];

            inteiros[0] = 42;
            inteiros[1] = -5;

            var decimais = new decimal[] {0.4m, -3.8m, 4, 7.6m};

            string[] nomes = { "Thiago", "Ribeiro" };

            var chars = new[] {'a','b','c'};

            foreach (var @decimal in decimais)
            {
                Console.WriteLine(@decimal);
            }

            Console.WriteLine($"Tamanho do vetor {nameof(decimais)}: {decimais.Length}");
        }

        [TestMethod]
        public void RedimencionamentoTeste()
        {
            var decimais = new decimal[] { 0.4m, -3.8m, 4, 7.6m };

            Array.Resize(ref decimais, 5);

            decimais[4] = 2.3m;
        }

        [TestMethod]
        public void OrdenacaoTeste()
        {
            var decimais = new decimal[] { 0.4m, -3.8m, 4, 7.6m };

            Array.Sort(decimais);

            Assert.AreEqual(decimais[0], -3.8m);
        }

        private decimal CalcularMedia(decimal a, decimal b)
        {
            return (a + b) / 2;
        }

        private decimal CalcularMedia(params decimal[] valores)
        {
            decimal soma = 0;

            foreach (var valor in valores)
            {
                soma = soma + valor;
            }

            return soma / valores.Length;
        }

        [TestMethod]
        public void ParamsTeste()
        {
            var decimais = new decimal[] { 0.4m, -3.8m, 4, 7.6m };

            Console.WriteLine(CalcularMedia(decimais));
            Console.WriteLine(CalcularMedia(2,-1.8m, 4.5m, 9.15m));
        }

        [TestMethod]
        public void TodaStringEhUmVetorTeste()
        {
            var nome = "Thiago";

            Assert.AreEqual(nome[0], 'T');

            foreach (var @char in nome)
            {
                Console.Write(@char);
            }
        }
    }
}
