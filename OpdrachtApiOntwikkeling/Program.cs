using Microsoft.EntityFrameworkCore;
using OpdrachtApiOntwikkeling.Data;
using OpdrachtApiOntwikkeling.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRouting(options => options.LowercaseUrls = true);

var InMemoryDatabase = builder.Configuration.GetValue<bool>("InMemoryDatabase");
if (InMemoryDatabase)
{
    builder.Services.AddSingleton<IBossService, BossService>();
    builder.Services.AddSingleton<ILocationService, LocationService>();
    builder.Services.AddSingleton<IUniqueItemService, UniqueItemService>();
}
else
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
    builder.Services.AddScoped<IBossService, BossServiceDb>();
    builder.Services.AddScoped<ILocationService, LocationServiceDb>();
    builder.Services.AddScoped<IUniqueItemService, UniqueItemServiceDb>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

var logger = app.Services.GetRequiredService<ILogger<Program>>();
if (InMemoryDatabase)
{
    logger.LogInformation("Using InMemory database.");
}
else
{
    logger.LogInformation("Using SQL database.");
}

app.Run();
