using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Repositorios.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fintech.Dominio.Entidades;

namespace Fintech.Repositorios.SqlServer.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {
        private readonly MovimentoRepositorio repositorio = new(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Fintech;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        [TestMethod()]
        public void InserirTest()
        {
            var agencia = new Agencia();
            agencia.Numero = 2;

            var conta = new ContaCorrente(agencia, 456, "1");

            var movimento = new Movimento(Operacao.Deposito, 10);
            movimento.Conta = conta;

            repositorio.Inserir(movimento);
        }
        [TestMethod()]
        public void SelecionarTest()
        {
            var movimentos = repositorio.SelecionarAsync(2, 456).Result;

            foreach (var movimento in movimentos)
            {
                Console.WriteLine($"Data da operação: {movimento.Data}\nTipo da operação: {movimento.Operacao}\nValor da operação: {movimento.Valor:c}");
            }
        }
    }
}