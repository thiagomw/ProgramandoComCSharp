using System.Collections.Generic;

namespace Fintech.Dominio.Entidades
{
    public class Poupanca : Conta
    {
        public decimal TaxaRendimento { get; set; }

        public override List<string> Validar()
        {
            var erros = ValidarBase();
            
            if (TaxaRendimento <= 0)
            {
                erros.Add("A taxa de rendimento deve ser maior que zero.");
            }

            return erros;
        }
    }
}