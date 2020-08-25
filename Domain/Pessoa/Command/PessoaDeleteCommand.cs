using Domain;
using MediatR;
using NetCoreMediator.Domain.Pessoa.Entity;

namespace NetCoreMediator.Domain.Pessoa.Command
{
    public class PessoaDeleteCommand : IRequest<OperationResult<PessoaEntity>>
    {
        public long Id { get; set; }
    }
}