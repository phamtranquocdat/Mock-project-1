using ShedCraft.Application.Pricing;
using ShedCraft.Domain.Entities;
using Xunit;

namespace ShedCraft.Tests;

public class PricingCalculatorTests
{
    [Fact]
    public void Calculate_StandardCustomer_ShouldHaveNoDiscount()
    {
        // Arrange (Chuẩn bị dữ liệu)
        var customerType = CustomerType.Standard;
        decimal basePrice = 1000m;
        decimal customizationFee = 200m;

        // Act (Thực thi logic)
        var result = PricingCalculator.Calculate(customerType, basePrice, customizationFee);

        // Assert (Kiểm tra kết quả)
        Assert.Equal(0m, result.DiscountAmount);
        Assert.Equal(1200m, result.TotalAmount);
    }

    [Fact]
    public void Calculate_VipCustomer_ShouldDiscount10PercentOfBasePrice()
    {
        // Arrange
        var customerType = CustomerType.Vip;
        decimal basePrice = 1000m;
        decimal customizationFee = 200m;

        // Act
        var result = PricingCalculator.Calculate(customerType, basePrice, customizationFee);

        // Assert
        // Giảm 10% của 1000 = 100
        Assert.Equal(100m, result.DiscountAmount);
        // Tổng tiền = (1000 + 200) - 100 = 1100
        Assert.Equal(1100m, result.TotalAmount);
    }

    [Fact]
    public void Calculate_DealerRtoCustomer_ShouldDiscount15PercentBasePriceAndFreeCustomization()
    {
        // Arrange
        var customerType = CustomerType.DealerRTO;
        decimal basePrice = 1000m;
        decimal customizationFee = 200m;

        // Act
        var result = PricingCalculator.Calculate(customerType, basePrice, customizationFee);

        // Assert
        // Giảm 15% của 1000 (150) + miễn phí customization (200) = 350
        Assert.Equal(350m, result.DiscountAmount);
        // Tổng tiền = (1000 + 200) - 350 = 850
        Assert.Equal(850m, result.TotalAmount);
    }
}