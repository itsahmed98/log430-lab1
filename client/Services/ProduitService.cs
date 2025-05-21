using client.Models;
using client.Data;

namespace client.Services;

public class ProduitService
{
    private readonly MagasinContext _context;

    public ProduitService(MagasinContext context)
    {
        _context = context;
    }

    public List<Produit> Rechercher(string? nom, string? categorie, int? id)
    {
        var query = _context.Produits.AsQueryable();

        if (!string.IsNullOrWhiteSpace(nom))
            query = query.Where(p => p.Nom.Contains(nom));

        if (!string.IsNullOrWhiteSpace(categorie))
            query = query.Where(p => p.Categorie.Contains(categorie));

        if (id.HasValue)
            query = query.Where(p => p.Id == id);

        return query.ToList();
    }

    public List<Produit> ObtenirTousLesProduits()
    {
        return _context.Produits
            .OrderBy(p => p.Nom) // Trier par nom
            .ToList();
    }

}


