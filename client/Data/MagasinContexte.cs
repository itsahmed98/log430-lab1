using Microsoft.EntityFrameworkCore;
using client.Models;
namespace client.Data;

public class MagasinContext : DbContext
{
    public MagasinContext(DbContextOptions<MagasinContext> options) : base(options) { }

    public DbSet<Produit> Produits { get; set; }
    public DbSet<Employe> Employes { get; set; }
    public DbSet<LigneVente> LignesVente { get; set; }
    public DbSet<Retour> Retours { get; set; }
    public DbSet<Vente> Ventes { get; set; }
}
