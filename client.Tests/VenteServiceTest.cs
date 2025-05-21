using Xunit;
using client.Data;
using client.Models;
using client.Services;
using Microsoft.EntityFrameworkCore;

namespace client.Tests;

public class VenteServiceTest
{
    private MagasinContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<MagasinContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString()) // base isolée à chaque test
            .Options;
        return new MagasinContext(options);
    }

    [Fact]
    public void EnregistrerVente_ProduitValide_StockDiminueEtTotalCorrect()
    {
        // Arrange
        using var context = GetDbContext();
        context.Produits.Add(new Produit { Id = 1, Nom = "Stylo", Categorie = "Papeterie", Prix = 2.0m, QuantiteStock = 100 });
        context.SaveChanges();

        var service = new VenteService(context);

        // Act
        service.EnregistrerVente(new List<(int produitId, int quantite)> { (1, 3) });

        // Assert
        var vente = context.Ventes.Include(v => v.Lignes).FirstOrDefault();
        var produit = context.Produits.First(p => p.Id == 1);

        Assert.NotNull(vente);
        Assert.Single(vente!.Lignes);
        Assert.Equal(6.0m, vente.Total); // 3 x 2.0
        Assert.Equal(97, produit.QuantiteStock); // 100 - 3
    }

    [Fact]
    public void EnregistrerVente_ProduitInexistant_AucuneVente()
    {
        // Arrange
        using var context = GetDbContext();
        var service = new VenteService(context);

        // Act
        service.EnregistrerVente(new List<(int produitId, int quantite)> { (42, 1) });

        // Assert
        Assert.Empty(context.Ventes);
        Assert.Empty(context.LignesVente);
    }

    [Fact]
    public void EnregistrerVente_StockInsuffisant_VenteAnnulee()
    {
        // Arrange
        using var context = GetDbContext();
        context.Produits.Add(new Produit { Id = 1, Nom = "Clé USB", Categorie = "Électronique", Prix = 10.0m, QuantiteStock = 2 });
        context.SaveChanges();

        var service = new VenteService(context);

        // Act
        service.EnregistrerVente(new List<(int produitId, int quantite)> { (1, 5) }); // demande > stock

        // Assert
        Assert.Empty(context.Ventes);
        Assert.Equal(2, context.Produits.First().QuantiteStock); // stock inchangé
    }
}
