using CacheTestes.Caches.TesteIMemoryCache;
using CacheTestes.Caching.TesteIMemoryCache;
using CacheTestes.Caching.TesteRedis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Memory Cache
builder.Services.AddMemoryCache();

//Redis
builder.Services.AddStackExchangeRedisCache(x => {
    x.InstanceName = "instance";
    x.Configuration = "localhost";
});

//Inje��o de dep�ndencia
builder.Services.AddScoped<EntityIMemoryCache>();
builder.Services.AddScoped<EntityRedisCache>();

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
