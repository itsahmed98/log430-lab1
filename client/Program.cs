using Microsoft.EntityFrameworkCore;
using client.Data;
using client.Models;

var optionsBuilder = new DbContextOptionsBuilder<MagasinContext>();
optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=magasin");

using var context = new MagasinContext(optionsBuilder.Options);

// Un test pour vérifier la connexion à la base de données
Console.WriteLine("Produits existants dans la base :");
foreach (var produit in context.Produits.ToList())
{
    Console.WriteLine($"{produit.Nom} - {produit.Prix}€");
}

