using LivePolling_SignalR_Demo.Hubs;
using LivePolling_SignalR_Demo.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR(); // Enables SignalR
builder.Services.AddSingleton<IPollService, PollService>(); // Keeps votes in memory


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapHub<PollHub>("/pollHub");

app.MapControllers();

app.Run();
