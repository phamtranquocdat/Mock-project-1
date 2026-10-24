namespace ShedCraft.Domain.Entities;

public enum CustomerType
{
    Standard = 1,
    Vip = 2,
    DealerRTO = 3 // Đại lý Thuê Mua (Rent-To-Own)
}

public class Customer
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string FullName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public CustomerType Type { get; set; } = CustomerType.Standard;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}