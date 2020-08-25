using Domain;
using MediatR;
using NetCoreMediator.Domain.Pessoa.Entity;

namespace NetCoreMediator.Domain.Pessoa.Command
{
    public class PessoaCreateCommand : IRequest<OperationResult<PessoaEntity>>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}