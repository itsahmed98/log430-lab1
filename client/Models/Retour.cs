using System;

namespace client.Models;

public class Retour
{
    public int Id { get; set; }
    public DateTime DateRetour { get; set; } = DateTime.Now;
    public int ProduitId { get; set; }
    public Produit Produit { get; set; } = null!;
    public int Quantite { get; set; }
}
