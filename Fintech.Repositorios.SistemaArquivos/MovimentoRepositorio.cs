using Fintech.Dominio.Entidades;
using Fintech.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;

namespace Fintech.Repositorios.SistemaArquivos
{
    public class MovimentoRepositorio : IMovimentoRepositorio
    {
        private const string DiretorioBase = "Dados";

        public void Atualizar(Movimento movimento)
        {
            throw new NotImplementedException();
        }

        public void Inserir(Movimento movimento)
        {
            var registro = $"{movimento.Guid}|{movimento.Conta.Agencia.Numero}|{movimento.Conta.Numero}" +
                $"|{movimento.DataTransacao}|{((int)movimento.Operacao)}|{movimento.Valor}";

            if (!Directory.Exists(DiretorioBase))
            {
                Directory.CreateDirectory(DiretorioBase);
            }

            File.AppendAllText(@$"{DiretorioBase}\Movimento.txt", registro + Environment.NewLine);
        }

        public Movimento Selecionar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Movimento> Selecionar(int numeroAgencia, int numeroConta)
        {
            throw new NotImplementedException();
        }
    }
}
