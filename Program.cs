using Microsoft.EntityFrameworkCore;
using BeachResortAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// 🔥 DATABASE CONNECTION
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 36))
    )
);

// 🔥 CONTROLLERS
builder.Services.AddControllers();

// 🔥 CORS (IMPORTANT FOR PHP / FRONTEND)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

// 🔥 SWAGGER
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔥 ENABLE SWAGGER ONLY IN DEV
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// 🔥 ENABLE CORS
app.UseCors("AllowAll");

// OPTIONAL
app.UseHttpsRedirection();

// 🔥 MAP CONTROLLERS
app.MapControllers();

// 🔥 TEST ROUTE
app.MapGet("/", () => "🌴 Beach Resort API is running...");

app.Run();