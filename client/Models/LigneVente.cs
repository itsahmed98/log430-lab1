namespace client.Models;

public class LigneVente
{
    public int Id { get; set; }
    public int Quantite { get; set; }
    public decimal PrixUnitaire { get; set; }
    public decimal MontantTotal { get; set; }
    public Produit Produit { get; set; } = null!;
    public Vente Vente { get; set; } = null!;
    public Retour? Retour { get; set; }
}