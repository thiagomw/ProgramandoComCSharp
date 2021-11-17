using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSharp.Capitulo02.GeradorSenha;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp.Capitulo02.GeradorSenha.Tests
{
    [TestClass()]
    public class SenhaTests
    {
        //[TestMethod()]
        //public void GerarSenhaSemParametroDeveRetornarSenhaPadrao()
        //{
        //    //senha.Tamanho = 6;

        //    var senha = new Senha();

        //    var valorSenha = senha.Gerar();

        //    Assert.IsTrue(valorSenha.Length == Senha.TamanhoMinimo);

        //    Console.WriteLine(valorSenha);
        //}

        [TestMethod]
        public void ConstrutorPadraoDeveRetornarSenhaPadrao()
        {
            var senha = new Senha(4);

            //senha.Tamanho = 6;

            Assert.IsTrue(senha.Valor.Length == Senha.TamanhoMinimo);
            Console.WriteLine(senha.Valor);
        }

        [TestMethod]
        [DataRow(6)]
        [DataRow(8)]
        [DataRow(10)]
        public void ConstrutorParametrizadoDeveRetornarSenhaDeTamanhoEspecifico(int tamanho)
        {
            var senha = new Senha(tamanho);

            //senha.Valor = "asdfasdf";

            Assert.IsTrue(senha.Valor.Length == senha.Tamanho);
            
            Console.WriteLine(senha.Valor);
        }
    }
}