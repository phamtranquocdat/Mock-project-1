namespace ShedCraft.Application.Pricing.Strategies;

public class VipPricingStrategy : IPricingStrategy
{
    public decimal CalculateDiscount(decimal basePrice, decimal customizationFee)
    {
        // Giảm 10% trên tổng giá gốc
        return basePrice * 0.10m;
    }
}