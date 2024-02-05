using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infrastructure.Context;

public class LivrariaContext : DbContext
{
    public LivrariaContext(DbContextOptions<LivrariaContext> options) : base(options)
    {
    }

    public DbSet<Livro>? Livros { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(LivrariaContext).Assembly);
    }
}