using System;
using System.Collections.Generic;

namespace Fintech.Dominio.Entidades
{
    public abstract class Conta
    {
        protected Conta(Agencia agencia, int numero, string digitoVerificador)
        {
            Agencia = agencia;
            Numero = numero;
            DigitoVerificador = digitoVerificador;
        }

        public int Id { get; set; }
        public Agencia Agencia { get; set; }
        public int Numero { get; set; }
        public string DigitoVerificador { get; set; }
        public decimal Saldo { get; set; }
        public Cliente Cliente { get; set; }
        public List<Movimento> Movimentos { get; set; } = new List<Movimento>();

        public virtual Movimento EfetuarOperacao(decimal valor, Operacao operacao, decimal limite = 0)
        {
            var sucesso = true;
            Movimento movimento = null;
            
            switch (operacao)
            {
                case Operacao.Deposito:
                    Saldo += valor;
                    break;
                case Operacao.Saque:
                    if (Saldo + limite >= valor)
                    {
                        Saldo -= valor; 
                    }
                    else
                    {
                        sucesso = false;
                    }
                    break;
            }

            if (sucesso)
            {
                movimento = new Movimento(operacao, valor);
                movimento.Conta = this;

                Movimentos.Add(movimento);
            }

            return movimento;
        }

        public abstract List<string> Validar();
        
        public List<string> ValidarBase()
        {
            var erros = new List<string>();

            if (Numero <= 0)
            {
                erros.Add("O número da conta deve ser maior que zero.");
            }

            if (string.IsNullOrEmpty(DigitoVerificador))
            {
                erros.Add("O dígito verificador da conta é obrigatório.");
            }

            return erros;
        }
    }
}
