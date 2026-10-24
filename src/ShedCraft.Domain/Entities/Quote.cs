namespace ShedCraft.Domain.Entities;

public enum QuoteStatus
{
    Draft,
    Approved,
    ConvertedToOrder,
    Expired
}

public class Quote
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }

    public Guid ProductShedId { get; set; }
    public ProductShed? ProductShed { get; set; }

    public decimal BasePrice { get; set; }
    public decimal CustomizationFee { get; set; } // Tùy chỉnh thêm cửa, sơn
    public decimal DiscountAmount { get; set; }  // Mức giảm giá (tính qua Strategy)
    public decimal TotalAmount { get; set; }     // Tổng tiền cuối cùng

    public QuoteStatus Status { get; set; } = QuoteStatus.Draft;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}