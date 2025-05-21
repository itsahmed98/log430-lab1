using Microsoft.EntityFrameworkCore;
using client.Data;
using client.Models;
using client.Services;

// Connexion à la base
var optionsBuilder = new DbContextOptionsBuilder<MagasinContext>();
optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=magasin");

using var context = new MagasinContext(optionsBuilder.Options);
var produitService = new ProduitService(context);

// --- MENU CONSOLE ---
bool continuer = true;

while (continuer)
{
    Console.WriteLine("\n=== Menu principal ===");
    Console.WriteLine("1. Rechercher un produit");
    Console.WriteLine("0. Quitter");
    Console.Write("Choix : ");
    var choix = Console.ReadLine();

    switch (choix)
    {
        case "1":
            RechercherProduit(produitService);
            break;
        case "0":
            continuer = false;
            break;
        default:
            Console.WriteLine("Choix invalide.");
            break;
    }
}

// --- FONCTION : CU01 - Rechercher un produit ---
static void RechercherProduit(ProduitService service)
{
    Console.WriteLine("\n--- Rechercher un produit ---");
    Console.Write("ID (laisser vide si inconnu) : ");
    var idStr = Console.ReadLine();
    int? id = string.IsNullOrWhiteSpace(idStr) ? null : int.Parse(idStr!);

    Console.Write("Nom (optionnel) : ");
    var nom = Console.ReadLine();

    Console.Write("Catégorie (optionnel) : ");
    var cat = Console.ReadLine();

    var resultats = service.Rechercher(nom, cat, id);

    Console.WriteLine($"\n{resultats.Count} produit(s) trouvé(s) :");
    foreach (var p in resultats)
    {
        Console.WriteLine($"[{p.Id}] {p.Nom} - {p.Categorie} - {p.Prix}€ - Stock: {p.QuantiteStock}");
    }
}
