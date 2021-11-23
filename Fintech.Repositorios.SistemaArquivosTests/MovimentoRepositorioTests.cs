using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fintech.Repositorios.SistemaArquivos;
using Fintech.Dominio.Entidades;

namespace Fintech.Repositorios.SistemaArquivos.Tests
{
    [TestClass()]
    public class MovimentoRepositorioTests
    {
        [TestMethod()]
        public void InserirTest()
        {
            var agencia = new Agencia();
            agencia.Numero = 2;
            
            var conta = new ContaCorrente(agencia, 456, "1");

            var movimento = new Movimento(Operacao.Deposito, 1200.50m);
            movimento.Conta = conta;

            var repositorio = new MovimentoRepositorio();
            repositorio.Inserir(movimento);
        }
    }
}