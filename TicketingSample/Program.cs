using TicketingSample.Data;
using TicketingSample.Repositories;
using TicketingSample.Routes;
using TicketingSample.Services;

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//Data Connection
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register Ticket Services
builder.Services.AddSingleton(new DbConnectionFactory(connectionString));
builder.Services.AddScoped<TicketRepository>();
builder.Services.AddScoped<TicketService>();


var app = builder.Build();

// Initialize the database with seed data
using (var dbConnection = new DbConnectionFactory(connectionString).CreateConnection())
{
    dbConnection.Open();
    SeedData.Initialize(dbConnection);
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Example minimal API endpoint
app.MapTicketEndpoints();





app.Run();
