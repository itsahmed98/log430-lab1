using client.Data;
using client.Models;

namespace client.Services;

public class RetourService
{
    private readonly MagasinContext _context;

    public RetourService(MagasinContext context)
    {
        _context = context;
    }

    public void EnregistrerRetour(int produitId, int quantite)
    {
        var produit = _context.Produits.FirstOrDefault(p => p.Id == produitId);

        if (produit == null)
        {
            Console.WriteLine("Produit introuvable.");
            return;
        }

        produit.QuantiteStock += quantite;

        var retour = new Retour
        {
            ProduitId = produitId,
            Quantite = quantite
        };

        _context.Retours.Add(retour);
        _context.SaveChanges();

        Console.WriteLine($"Retour enregistré. Nouveau stock : {produit.QuantiteStock}");
    }
}
