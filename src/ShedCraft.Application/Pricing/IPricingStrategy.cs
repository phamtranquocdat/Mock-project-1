namespace ShedCraft.Application.Pricing;

public interface IPricingStrategy
{
    // Trả về số tiền giảm giá (Discount Amount)
    decimal CalculateDiscount(decimal basePrice, decimal customizationFee);
}