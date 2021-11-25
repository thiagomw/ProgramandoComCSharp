using System;
using System.Runtime.Serialization;

namespace Fintech.Dominio.Entidades
{
    [Serializable]
    public class SaldoInsuficienteExecption : Exception
    {
        public SaldoInsuficienteExecption() : base("Saldo insuficiente")
        {
            //base.Message = "Saldo insuficiente";
        }

        public SaldoInsuficienteExecption(string message) : base(message)
        {
        }

        public SaldoInsuficienteExecption(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected SaldoInsuficienteExecption(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}