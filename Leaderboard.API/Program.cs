using Leaderboard.API;
using Leaderboard.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.AddConfig();

builder.Services.AddCaching(builder.Configuration);
builder.Services.AddApp();
builder.Services.AddDb(builder.Configuration);

var app = builder.Build();

await app.Services.InitializeDb(); 
await app.Services.EnsureDatabaseIsUpToDateAsync(); 

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

await app.RunAsync();