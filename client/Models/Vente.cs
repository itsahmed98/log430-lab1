namespace client.Models;

public class Vente
{
    public int Id { get; set; }
    public DateTime DateVente { get; set; }
    public decimal Total { get; set; }

    public List<LigneVente> Lignes { get; set; } = new();
}