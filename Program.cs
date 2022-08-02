
using System.Text.Json.Serialization;
using IrishJobs.Data;
using IrishJobs.Data.Repositories;
using IrishJobs.Models;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddControllers()
    .ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    }).AddJsonOptions(x=> x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve);
builder.Services.AddDbContext<DataContext>();

builder.Services.AddScoped<IRepositoryAd, RepositoryAd>();
builder.Services.AddScoped<IRepositoryCompany, RepositoryCompany>();
builder.Services.AddScoped<IRepositoryCandidate, RepositoryCandidate>();

var app = builder.Build();
app.MapControllers();

app.Run();

