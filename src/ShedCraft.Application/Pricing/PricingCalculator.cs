using ShedCraft.Application.Pricing.Strategies;
using ShedCraft.Domain.Entities;

namespace ShedCraft.Application.Pricing;

public class PricingCalculator
{
    public static IPricingStrategy GetStrategy(CustomerType customerType)
    {
        return customerType switch
        {
            CustomerType.Vip => new VipPricingStrategy(),
            CustomerType.DealerRTO => new DealerRtoPricingStrategy(),
            _ => new StandardPricingStrategy()
        };
    }

    public static QuoteCalculateResult Calculate(CustomerType customerType, decimal basePrice, decimal customizationFee)
    {
        var strategy = GetStrategy(customerType);
        var discountAmount = strategy.CalculateDiscount(basePrice, customizationFee);
        var totalAmount = (basePrice + customizationFee) - discountAmount;

        return new QuoteCalculateResult
        {
            BasePrice = basePrice,
            CustomizationFee = customizationFee,
            DiscountAmount = discountAmount,
            TotalAmount = totalAmount < 0 ? 0 : totalAmount // Tránh số âm
        };
    }
}

public class QuoteCalculateResult
{
    public decimal BasePrice { get; set; }
    public decimal CustomizationFee { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal TotalAmount { get; set; }
}