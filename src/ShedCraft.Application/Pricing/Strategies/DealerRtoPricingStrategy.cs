namespace ShedCraft.Application.Pricing.Strategies;

public class DealerRtoPricingStrategy : IPricingStrategy
{
    public decimal CalculateDiscount(decimal basePrice, decimal customizationFee)
    {
        // Giảm 15% giá gốc + miễn phí phí tùy chỉnh
        var baseDiscount = basePrice * 0.15m;
        return baseDiscount + customizationFee;
    }
}