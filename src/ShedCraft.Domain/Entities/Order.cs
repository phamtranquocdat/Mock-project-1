namespace ShedCraft.Domain.Entities;

public enum OrderStatus
{
    Pending,
    InProduction,  // Đang sản xuất
    ReadyForDelivery,
    Delivered,     // Đã giao
    Cancelled
}

public class Order
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid QuoteId { get; set; }
    public Quote? Quote { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Pending;
    public string? RtoContractUrl { get; set; } // Link file hợp đồng lưu trên AWS S3
    public DateTime OrderDate { get; set; } = DateTime.UtcNow;
    public DateTime? EstimatedDeliveryDate { get; set; }
}