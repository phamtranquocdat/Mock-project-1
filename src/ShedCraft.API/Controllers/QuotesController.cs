using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShedCraft.API.DTOs;
using ShedCraft.Application.Pricing;
using ShedCraft.Domain.Entities;
using ShedCraft.Infrastructure.Data;

namespace ShedCraft.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class QuotesController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<QuotesController> _logger;

    // Tiêm ApplicationDbContext thông qua Dependency Injection (Scoped)
    public QuotesController(ApplicationDbContext context, ILogger<QuotesController> logger)
    {
        _context = context;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> CreateQuote([FromBody] CreateQuoteRequest request)
    {
        // 1. Áp dụng Strategy Pattern thông qua PricingCalculator để tính tiền
        var calculationResult = PricingCalculator.Calculate(
            request.CustomerType, 
            request.BasePrice, 
            request.CustomizationFee
        );

        // 2. Khởi tạo thực thể Quote
        var quote = new Quote
        {
            CustomerId = request.CustomerId,
            ProductShedId = request.ProductShedId,
            BasePrice = calculationResult.BasePrice,
            CustomizationFee = calculationResult.CustomizationFee,
            DiscountAmount = calculationResult.DiscountAmount,
            TotalAmount = calculationResult.TotalAmount,
            Status = QuoteStatus.Draft,
            CreatedAt = DateTime.UtcNow
        };

        // 3. Lưu vào Database thông qua EF Core (Async/Await)
        _context.Quotes.Add(quote);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Đã tạo thành công báo giá với ID: {QuoteId}", quote.Id);

        // 4. Trả về kết quả cho Client
        return CreatedAtAction(nameof(GetQuoteById), new { id = quote.Id }, new
        {
            Message = "Tạo báo giá thành công!",
            QuoteId = quote.Id,
            Calculation = calculationResult
        });
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetQuoteById(Guid id)
    {
        var quote = await _context.Quotes.FindAsync(id);
        if (quote == null)
        {
            return NotFound(new { Message = $"Không tìm thấy báo giá với ID: {id}" });
        }

        return Ok(quote);
    }
}