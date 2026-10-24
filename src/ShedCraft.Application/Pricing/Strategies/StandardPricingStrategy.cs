namespace ShedCraft.Application.Pricing.Strategies;

public class StandardPricingStrategy : IPricingStrategy
{
    public decimal CalculateDiscount(decimal basePrice, decimal customizationFee)
    {
        return 0m; // Không giảm giá
    }
}