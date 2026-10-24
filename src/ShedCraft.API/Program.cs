using Microsoft.EntityFrameworkCore;
using ShedCraft.API.Middlewares;
using ShedCraft.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Thêm Controllers & Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 2. Cấu hình DbContext (In-Memory Database để test nhanh hoặc SQL Server)
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseInMemoryDatabase("ShedCraftDb")); 
    // Mẹo: Dùng UseInMemoryDatabase giúp bạn test API trực tiếp ngay lập tức mà chưa cần cài SQL Server!

var app = builder.Build();

// 3. Sử dụng Global Exception Middleware
app.UseMiddleware<GlobalExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();