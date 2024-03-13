namespace Models.Dto
{
    public class MouvementStockMediumDto
    {
        public int Id { get; set; }

        public string NumeroMouvement { get; set; } = string.Empty;

        public string Date { get; set; } = string.Empty;

        public ProduitMediumDto? Produit { get; set; }
    }
}
