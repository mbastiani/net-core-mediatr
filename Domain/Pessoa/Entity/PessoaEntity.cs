namespace NetCoreMediator.Domain.Pessoa.Entity
{
    public class PessoaEntity
    {
        public PessoaEntity(string nome, string email)
        {
            Nome = nome;
            Email = email;
        }

        public long Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}