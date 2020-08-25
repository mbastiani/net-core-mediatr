using Infra.Data;
using MediatR;
using NetCoreMediator.Domain.Pessoa.Command;
using NetCoreMediator.Domain.Pessoa.Entity;
using System.Threading;
using System.Threading.Tasks;


namespace Domain.Pessoa.Handler
{
    public class PessoaCommandHandler :
        IRequestHandler<PessoaCreateCommand, OperationResult<PessoaEntity>>,
        IRequestHandler<PessoaUpdateCommand, OperationResult<PessoaEntity>>,
        IRequestHandler<PessoaDeleteCommand, OperationResult<PessoaEntity>>
    {
        private readonly AppDbContext _appDbContext;

        public PessoaCommandHandler(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<OperationResult<PessoaEntity>> Handle(PessoaCreateCommand request, CancellationToken cancellationToken)
        {
            var pessoa = new PessoaEntity(request.Nome, request.Email);
            await _appDbContext.Pessoas.AddAsync(pessoa);
            await _appDbContext.SaveChangesAsync();

            return OperationResult<PessoaEntity>.CreateSuccessResult(pessoa);
        }

        public async Task<OperationResult<PessoaEntity>> Handle(PessoaUpdateCommand request, CancellationToken cancellationToken)
        {
            var pessoa = await _appDbContext.Pessoas.FindAsync(request.Id);
            if (pessoa is null)
                return OperationResult<PessoaEntity>.CreateFailure("Pessoa não encontrada");

            pessoa.Email = request.Email;
            await _appDbContext.SaveChangesAsync();

            return OperationResult<PessoaEntity>.CreateSuccessResult(pessoa); ;
        }

        public async Task<OperationResult<PessoaEntity>> Handle(PessoaDeleteCommand request, CancellationToken cancellationToken)
        {
            var pessoa = await _appDbContext.Pessoas.FindAsync(request.Id);
            if (pessoa is null)
                return OperationResult<PessoaEntity>.CreateFailure("Pessoa não encontrada");

            _appDbContext.Pessoas.Remove(pessoa);
            await _appDbContext.SaveChangesAsync();

            return OperationResult<PessoaEntity>.CreateSuccessResult(pessoa);
        }
    }
}