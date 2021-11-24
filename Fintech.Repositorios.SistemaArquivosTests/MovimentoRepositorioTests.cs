using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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

            var movimento = new Movimento(Operacao.Deposito, 1200.50m);
            movimento.Conta = conta;

            repositorio.Inserir(movimento);
        }
        [TestMethod()]
        public void SelecionarTest()
        {
            var movimentos = repositorio.Selecionar(2, 456);

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"Data da operação: {movimento.DataTransacao}\nTipo da operação: {movimento.Operacao}\nValor da operação: {movimento.Valor:c}");
            }
        }
    }
}