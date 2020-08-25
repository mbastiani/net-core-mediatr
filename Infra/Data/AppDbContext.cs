using Microsoft.EntityFrameworkCore;
using NetCoreMediator.Domain.Pessoa.Entity;

namespace Infra.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<PessoaEntity> Pessoas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
    }
}