using Microsoft.EntityFrameworkCore;
using client.Data;
using client.Models;
using client.Services;

// Connexion à la base
var optionsBuilder = new DbContextOptionsBuilder<MagasinContext>();
optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=postgres;Database=magasin");

using var context = new MagasinContext(optionsBuilder.Options);
var produitService = new ProduitService(context);
var venteService = new VenteService(context);
var retourService = new RetourService(context);


// Ajouter des produits de test si la base est vide
if (!context.Produits.Any())
{
    var produitsTest = new List<Produit>
    {
        new Produit { Id = 1, Nom = "Cahier", Categorie = "Papeterie", Prix = 3.50m, QuantiteStock = 100 },
        new Produit { Id = 2, Nom = "Stylo", Categorie = "Papeterie", Prix = 1.20m, QuantiteStock = 200 },
        new Produit { Id = 3, Nom = "Clé USB", Categorie = "Électronique", Prix = 15.99m, QuantiteStock = 50 },
        new Produit { Id = 4, Nom = "Bouteille d'eau", Categorie = "Boissons", Prix = 1.00m, QuantiteStock = 300 }
    };

    context.Produits.AddRange(produitsTest);
    context.SaveChanges();

    Console.WriteLine("📦 Produits de test ajoutés.");
}


// --- MENU CONSOLE ---
bool continuer = true;

while (continuer)
{
    Console.WriteLine("\n=== Menu principal ===");
    Console.WriteLine("1. Rechercher un produit");
    Console.WriteLine("2. Enregistrer une vente");
    Console.WriteLine("3. Gérer un retour");
    Console.WriteLine("4. Consulter le stock");
    Console.WriteLine("0. Quitter");
    Console.Write("Choix : ");
    var choix = Console.ReadLine();

    switch (choix)
    {
        case "1":
            RechercherProduit(produitService);
            break;
        case "2":
            EnregistrerVente(venteService);
            break;
        case "3":
            GererRetour(retourService);
            break;
        case "4":
            ConsulterStock(produitService);
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

// --- FONCTION : CU02 - Enregistrer une vente ---
static void EnregistrerVente(VenteService service)
{
    Console.WriteLine("\n--- Enregistrer une vente ---");
    var listeProduits = new List<(int, int)>();

    while (true)
    {
        Console.Write("ID produit (vide pour terminer) : ");
        var idStr = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(idStr)) break;

        Console.Write("Quantité : ");
        var qteStr = Console.ReadLine();
        if (!int.TryParse(idStr, out var id) || !int.TryParse(qteStr, out var qte))
        {
            Console.WriteLine("Entrée invalide.");
            continue;
        }

        listeProduits.Add((id, qte));
    }

    service.EnregistrerVente(listeProduits);
}

// --- Fonction : CU03 - Gérer un retour ---
static void GererRetour(RetourService service)
{
    Console.WriteLine("\n--- Retour produit ---");
    Console.Write("ID du produit à retourner : ");
    var idStr = Console.ReadLine();
    Console.Write("Quantité retournée : ");
    var qteStr = Console.ReadLine();

    if (int.TryParse(idStr, out var id) && int.TryParse(qteStr, out var qte))
    {
        service.EnregistrerRetour(id, qte);
    }
    else
    {
        Console.WriteLine("Entrée invalide.");
    }
}

// --- Fonction : CU04 - Consulter le stock ---
static void ConsulterStock(ProduitService service)
{
    Console.WriteLine("\n--- Stock actuel ---");
    var produits = service.ObtenirTousLesProduits();

    foreach (var p in produits)
    {
        Console.WriteLine($"[{p.Id}] {p.Nom} - {p.Categorie} - {p.Prix}€ - Stock: {p.QuantiteStock}");
    }

    if (produits.Count == 0)
        Console.WriteLine("Aucun produit en stock.");
}


