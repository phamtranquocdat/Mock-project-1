using ShedCraft.Domain.Entities;

namespace ShedCraft.API.DTOs;

public class CreateQuoteRequest
{
    public Guid CustomerId { get; set; }
    public Guid ProductShedId { get; set; }
    public CustomerType CustomerType { get; set; }
    public decimal BasePrice { get; set; }
    public decimal CustomizationFee { get; set; }
}