using System.Collections.Generic;

namespace Fintech.Dominio.Entidades
{
    public class ContaCorrente : Conta
    {
        public bool EmissaoChequeHabilitada { get; set; }

        public override List<string> Validar()
        {
            throw new System.NotImplementedException();
        }
    }
}