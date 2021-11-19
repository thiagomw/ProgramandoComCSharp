using System;

namespace Fintech.Dominio.Entidades
{
    public class Movimento
    {
        public Movimento(Operacao operacao, decimal valor)
        {
            Operacao = operacao;
            Valor = valor;
        }

        public int Id { get; set; }
        public Guid Guid { get; set; }
        public DateTime DataTransacao { get; set; } = DateTime.Now;
        public Operacao Operacao { get; set; }
        public decimal Valor { get; set; }
        public Conta Conta { get; set; }
    }
}