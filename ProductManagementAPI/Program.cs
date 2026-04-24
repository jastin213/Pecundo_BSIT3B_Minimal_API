using Microsoft.EntityFrameworkCore;
using ProductManagementAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// =====================
// SERVICES
// =====================

// Controllers
builder.Services.AddControllers();

// Swagger (API documentation)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQL Server Database Connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// =====================
// MIDDLEWARE PIPELINE
// =====================

// Enable Swagger only in Development mode
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Map API controllers
app.MapControllers();

app.Run();