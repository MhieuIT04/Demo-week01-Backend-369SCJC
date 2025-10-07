using MediatR;
using Microsoft.EntityFrameworkCore;
// SỬA LẠI CHO ĐÚNG: ApplicationDbContext của bạn nằm trong project HelloWorld
using HelloWorld.Data;
using MyAPI_DotNet.Application.Interfaces;
// Dùng một class bất kỳ trong project Application để làm mốc cho MediatR
using MyAPI_DotNet.Application.Features.Menus.Queries.GetAllMenus;


var builder = WebApplication.CreateBuilder(args);

// 1. Đăng ký các services vào container
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Đăng ký DbContext và Interface của nó
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

// Đăng ký MediatR, chỉ nó quét assembly chứa class GetAllMenusQuery (tức là project Application)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetAllMenusQuery).Assembly));


var app = builder.Build();

// 2. Cấu hình HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Kích hoạt authorization (sẽ cần cho các bài sau)
app.UseAuthorization();

// Map các request tới Controller
app.MapControllers();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

