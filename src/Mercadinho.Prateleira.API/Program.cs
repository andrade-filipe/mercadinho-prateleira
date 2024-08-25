using Mercadinho.Prateleira.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Services.AddDbContext<PrateleiraDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers().AddNewtonsoftJson(opt =>
    opt.SerializerSettings.ReferenceLoopHandling =
        Newtonsoft.Json.ReferenceLoopHandling.Ignore);

// builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Mercadinho.Prateleira.API",
        Description = "API CRUD para gestão de Prateleira",
        TermsOfService = new Uri("https://example.com/whatever"),
        Contact = new OpenApiContact
        {
            Name = "Filipe Andrade",
            Email = "filipeandrade.work@gmail.com",
            Url = new Uri("https://github.com/andrade-filipe")
        },
        License = new OpenApiLicense
        {
            Name = "Use under LICX",
            Url = new Uri("https://example.com/whatever"),
        }
    });
});

var app = builder.Build();

app.UseRouting();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Prateleira API");
    c.RoutePrefix = string.Empty;
});

app.MapControllers();

app.Run();