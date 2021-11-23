using Fintech.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace Fintech.Dominio.Interfaces
{
    public interface IMovimentoRepositorio
    {
        void Inserir(Movimento movimento);
        Movimento Selecionar(int id);
        List<Movimento> Selecionar(int numeroAgencia, int numeroConta);
        void Atualizar(Movimento movimento);
        void Excluir(int id) 
        {
            throw new InvalidOperationException();
        }
    }
}
