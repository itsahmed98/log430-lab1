using Xunit;
using client.Data;
using client.Models;
using client.Services;
using Microsoft.EntityFrameworkCore;

namespace client.Tests;

public class RetourServiceTests
{
    private MagasinContext GetDbContext()
    {
        var options = new DbContextOptionsBuilder<MagasinContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        return new MagasinContext(options);
    }

    [Fact]
    public void EnregistrerRetour_ProduitExistant_StockAugmenteEtRetourCree()
    {
        // Arrange
        using var context = GetDbContext();
        context.Produits.Add(new Produit
        {
            Id = 1,
            Nom = "Stylo",
            Categorie = "Papeterie",
            Prix = 1.5m,
            QuantiteStock = 10
        });
        context.SaveChanges();

        var service = new RetourService(context);

        // Act
        service.EnregistrerRetour(1, 3); // retour de 3 stylos

        // Assert
        var produit = context.Produits.First(p => p.Id == 1);
        var retour = context.Retours.FirstOrDefault();

        Assert.Equal(13, produit.QuantiteStock); // stock augmenté
        Assert.NotNull(retour);
        Assert.Equal(3, retour!.Quantite);
        Assert.Equal(1, retour.ProduitId);
    }

    [Fact]
    public void EnregistrerRetour_ProduitInexistant_RetourNonCree()
    {
        // Arrange
        using var context = GetDbContext();
        var service = new RetourService(context);

        // Act
        service.EnregistrerRetour(999, 2); // produit inexistant

        // Assert
        Assert.Empty(context.Retours);
    }
}
