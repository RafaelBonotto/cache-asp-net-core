using CacheTestes.Caches.TesteIMemoryCache;

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

//Injeção de depêndencia
builder.Services.AddScoped<EntityIMemoryCache>();

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
