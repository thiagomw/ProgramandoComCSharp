using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Fintech.Repositorios.SistemaArquivos;
using Fintech.Dominio.Entidades;

namespace Fintech.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {
        private readonly MovimentoRepositorio repositorio = new MovimentoRepositorio(@"Dados\Movimento.txt");

        [TestMethod()]
        public void InserirTest()
        {
            var agencia = new Agencia();
            agencia.Numero = 2;

            var conta = new ContaCorrente(agencia, 456, "1");

            var movimento = new Movimento(Operacao.Deposito, 50);
            movimento.Conta = conta;

            repositorio.Inserir(movimento);
        }
        [TestMethod()]
        public void SelecionarTest()
        {
            var movimentos = repositorio.Selecionar(2, 456);

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"Data da operação: {movimento.Data}\nTipo da operação: {movimento.Operacao}\nValor da operação: {movimento.Valor:c}\n");
            }
        }
        [TestMethod]
        public void OrderByTest()
        {
            var movimentos = repositorio.Selecionar(2, 456)
                .OrderBy(m => m.Valor)
                .ThenBy(m => m.Operacao)
                .ThenByDescending(m => m.Data);
            
            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"Data da operação: {movimento.Data}\nTipo da operação: {movimento.Operacao}\nValor da operação: {movimento.Valor:c}\n");
            }
        }
        [TestMethod]
        public void CountTest()
        {
            var qtdDepositos = repositorio.Selecionar(2, 456)
                .Count(m => m.Operacao == Operacao.Deposito);

            Assert.AreEqual(qtdDepositos, 2);
        }
        [TestMethod]
        public void LikeTest()
        {
            var movimentos = repositorio.Selecionar(2, 456)
                .Where(m => m.Data.ToString().Contains("11/29/2021"));

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Data}: {movimento.Operacao} {movimento.Valor:c}");
            }
        }
        [TestMethod]
        public void MinTest()
        {
            var menorDepostio = repositorio.Selecionar(2,456)
                .Where(m => m.Operacao == Operacao.Deposito)
                .Min(m => m.Valor);

            Assert.IsTrue(menorDepostio == 50);
        }
        [TestMethod]
        public void SkipTakeTeste()
        {
            var movimentos = repositorio.Selecionar(2, 456)
                .Skip(1)
                .Take(5)
                .ToList();

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"{movimento.Data}: {movimento.Operacao} {movimento.Valor:c}");
            }
        }
        [TestMethod]
        public void GroupByTest()
        {
            var agrupamento = repositorio.Selecionar(2, 456)
                .GroupBy(m => m.Operacao)
                .Select(g => new { Operacao = g.Key, Total = g.Sum(m => m.Valor) });

            foreach (var item in agrupamento)
            {
                Console.WriteLine($"{item.Operacao}: {item.Total}");
            }
        }
    }
}