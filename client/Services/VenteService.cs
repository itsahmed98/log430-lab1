using client.Data;
using client.Models;

namespace client.Services;

public class VenteService
{
    private readonly MagasinContext _context;

    public VenteService(MagasinContext context)
    {
        _context = context;
    }

    public void EnregistrerVente(List<(int produitId, int quantite)> produitsDemandes)
    {
        var vente = new Vente();

        foreach (var (produitId, quantite) in produitsDemandes)
        {
            var produit = _context.Produits.FirstOrDefault(p => p.Id == produitId);
            if (produit == null || produit.QuantiteStock < quantite)
            {
                Console.WriteLine($"Produit {produitId} indisponible ou stock insuffisant.");
                return;
            }

            var ligne = new LigneVente
            {
                ProduitId = produit.Id,
                Quantite = quantite,
                PrixUnitaire = produit.Prix
            };

            produit.QuantiteStock -= quantite;
            vente.Lignes.Add(ligne);
            vente.Total += quantite * produit.Prix;
        }

        _context.Ventes.Add(vente);
        _context.SaveChanges();

        Console.WriteLine($"\nVente enregistrée ! Total = {vente.Total} $");
    }
}
