using OpdrachtApiOntwikkelingDeel1.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IBossService, BossService>();
builder.Services.AddSingleton<ILocationService, LocationService>();
builder.Services.AddSingleton<IUniqueItemService, UniqueItemService>();

builder.Services.AddRouting(options => options.LowercaseUrls = true); //Lowercase routing

var app = builder.Build();

//testing

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
