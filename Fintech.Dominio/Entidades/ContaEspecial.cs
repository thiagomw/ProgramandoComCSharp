namespace Fintech.Dominio.Entidades
{
    public class ContaEspecial : ContaCorrente
    {
        public decimal Limite { get; set; }

        public override void EfetuarOperacao(decimal valor, Operacao operacao)
        {
            switch (operacao)
            {
                case Operacao.Deposito:
                    Saldo += valor;
                    break;
                case Operacao.Saque:
                    if (Saldo + Limite >= valor)
                    {
                        Saldo -= valor;
                    }
                    break;
            }
        }
    }


}