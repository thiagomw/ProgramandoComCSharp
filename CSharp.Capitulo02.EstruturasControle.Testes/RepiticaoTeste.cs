using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CSharp.Capitulo02.EstruturasControle.Testes
{
    [TestClass]
    public class RepiticaoTeste
    {
        [TestMethod]
        public void TabuladaTeste()
        {
            for (int i = 1; i <= 10; i++)
            {  
                for (int j = 1; j <= 10; j++)
                {
                    Console.WriteLine($"{i} * {j} = {i * j}");
                }

                Console.WriteLine(new string ('-', 65));
            }
        }

        [TestMethod]
        public void EstruturaForTeste()
        {
            var i = 1;

            for (Console.WriteLine("Iniciou"); i <= 3; Console.WriteLine(i))
            {
                i++;
            }

            /*
            for(1.Inicialização(void), 2.Condição (booleano), 4.Pós-execução(void))
            {
                3.Execução
            }
             */
        }

        [TestMethod]
        public void ForApenasComCondição()
        {
            var i = 1;

            for (;i <= 3;)
            {
                Console.WriteLine(i++);
            }
        }

        [TestMethod]
        public void ContinueTeste()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i <= 5)
                {
                    continue;
                }
                
                Console.WriteLine(i);
            }
        }

        [TestMethod]
        public void BreakTeste()
        {
            for (int i = 1; i <= 10; i++)
            {
                if (i > 5)
                {
                    break;
                }

                Console.WriteLine(i);
            }
        }
    }
}