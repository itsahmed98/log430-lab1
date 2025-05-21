using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using client.Data;

// Cette classe permet d'instancier le contexte de la base de données pour faire la migration
namespace client.Data;

public class MagasinContextFactory : IDesignTimeDbContextFactory<MagasinContext>
{
    public MagasinContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<MagasinContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=magasin");

        return new MagasinContext(optionsBuilder.Options);
    }
}
