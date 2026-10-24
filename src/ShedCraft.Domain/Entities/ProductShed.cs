namespace ShedCraft.Domain.Entities;

public class ProductShed
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; } = string.Empty; // VD: "Deluxe Wood Shed 10x12"
    public string Material { get; set; } = string.Empty; // Wood, Metal, Vinyl
    public decimal BasePrice { get; set; } // Giá gốc
    public double WidthFeet { get; set; }
    public double LengthFeet { get; set; }
}