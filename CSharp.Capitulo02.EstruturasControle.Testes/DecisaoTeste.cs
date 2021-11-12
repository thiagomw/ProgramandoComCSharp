using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSharp.Capitulo02.EstruturasControle.Testes
{
    [TestClass]
    public class DecisaoTeste
    {
        [TestMethod]
        public void AvaliacaoFinalReprovadoTeste()
        {
            var notaFinal = 2.9;
            var resultadoFinal = string.Empty;

            if (notaFinal < 3)
            {
                resultadoFinal = "Reprovado";
            }
            else if (notaFinal is >=3 and < 5)
            {
                resultadoFinal = "Recuperação";
            }
            else
            {
                resultadoFinal = "Aprovado";
            }

            Assert.AreEqual("Reprovado", resultadoFinal);
        }

        [TestMethod]
        public void AvaliacaoFinalRecuperacao3Teste()
        {
            var notaFinal = 3;
            var resultadoFinal = String.Empty;

            switch (notaFinal)
            {
                /*case 0:
                case -1:
                    resultadoFinal = "Teste";
                    break;*/
                case < 3:
                    resultadoFinal = "Reprovado";
                    break;
                case >= 3 and < 5:
                    resultadoFinal = "Recuperação";
                    break;
                default:
                    resultadoFinal = "Aprovado";
                    break;
            }

            Assert.AreEqual("Recuperação", resultadoFinal);
        }

        [TestMethod]
        public void AvaliacaoFinalRecuperacao49Teste()
        {
            var notaFinal = 4.9;
            //var resultadoFinal = String.Empty;


            // Switch Expression
            var resultadoFinal = notaFinal switch
            {
                < 3 => "Reprovado",
                >= 3 and < 5 => "Recuperação",
                _ => "Aprovado"
            };

            Assert.AreEqual("Recuperação", resultadoFinal);
        }

        [TestMethod]
        [DataRow(2.9, "Reprovado")]
        [DataRow(3, "Recuperação")]
        [DataRow(4.9, "Recuperação")]
        [DataRow(5, "Aprovado")]
        public void AvaliacaoFinalTeste(double notaFinal, string resultadoEsperado)
        {
            var resultadoFinal = notaFinal switch
            {
                < 3 => "Reprovado",
                >= 3 and < 5 => "Recuperação",
                _ => "Aprovado"
            };

            Assert.AreEqual(resultadoEsperado, resultadoFinal);
        }
    }
}
