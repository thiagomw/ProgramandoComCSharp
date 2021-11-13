namespace Fintech.Dominio.Entidades
{
    public class Agencia
    {
        public int Id { get; set; }
        public Banco Banco { get; set; }
        public int Numero { get; set; }
        public int DigitoVerificador { get; set; }
    }
}