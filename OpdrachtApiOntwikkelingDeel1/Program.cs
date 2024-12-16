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
    builder.Services.AddDbContext<InMemoryDbContext>(options =>
        options.UseInMemoryDatabase("InMemoryDb"));
    //builder.Services.AddScoped<IBossService, BossService>();
    //builder.Services.AddScoped<ILocationService, LocationService>();
    //builder.Services.AddScoped<IUniqueItemService, UniqueItemService>();
}
else
{
    builder.Services.AddDbContext<AppDbContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    });
    //builder.Services.AddScoped<IBossService, BossService>();
    //builder.Services.AddScoped<ILocationService, LocationService>();
    //builder.Services.AddScoped<IUniqueItemService, UniqueItemService>();
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

app.Run();
