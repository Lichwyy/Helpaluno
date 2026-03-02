namespace Helpaluno.Bussiness.Entities
{
    public class Aluno : EntidadeBase
    {
        public string PrimeiroNome { get; set; }
        public string? Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }

    }
}
