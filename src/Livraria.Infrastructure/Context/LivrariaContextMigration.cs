using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Livraria.Infrastructure.Context;

public class LivrariaContextMigration : IDesignTimeDbContextFactory<LivrariaContext>
{
    public LivrariaContext CreateDbContext(string[] args)
    {
        #region Localizar o arquivo appsettings.json

        var configurationBuilder = new ConfigurationBuilder();
        var path = Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json");
        configurationBuilder.AddJsonFile(path, optional: false, reloadOnChange: true);


        #endregion

        #region Capturar a connectionstring do arquivo appsettings.json

        var root = configurationBuilder.Build();
        var connectionString = root.GetSection("ConnectionStrings").GetSection("LivrariaContext").Value;


        #endregion

        #region Fazer a injeção de dependência na classe SqlServerContext

        var builder = new DbContextOptionsBuilder<LivrariaContext>();
        builder.UseSqlServer(connectionString);

        return new LivrariaContext(builder.Options);

        #endregion
    }
}