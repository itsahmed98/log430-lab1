using Xunit;
using client.Models;
using client.Data;
using client.Services;
using Microsoft.EntityFrameworkCore;

namespace client.Tests;

public class ProduitServiceTest
{
    [Fact]
    public void Rechercher_ProduitParNom_RetourneResultat()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<MagasinContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;

        using var context = new MagasinContext(options);
        context.Produits.Add(new Produit { Nom = "Clé USB", Categorie = "Électronique", Prix = 15.99m, QuantiteStock = 50 });
        context.SaveChanges();

        var service = new ProduitService(context);

        // Act
        var resultats = service.Rechercher("Clé", null, null);

        // Assert
        Assert.Single(resultats);
        Assert.Equal("Clé USB", resultats.First().Nom);
    }
}
