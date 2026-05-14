namespace Clothing.API.Models
{
    public class ClothingItem
    {
        public int Id { get; set; }
        public string Emri { get; set; } = string.Empty;
        public string Kategoria { get; set; } = string.Empty;
        public string Madhesia { get; set; } = string.Empty;
        public decimal Cmimi { get; set; }
        public int Sasia { get; set; }
    }
}