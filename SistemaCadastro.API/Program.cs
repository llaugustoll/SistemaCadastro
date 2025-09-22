using Asp.Versioning;
using Asp.Versioning.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SistemaCadastro.Domain.Ports;
using SistemaCadastro.Infrastructure.Adapters.Out.Api;
using SistemaCadastro.Infrastructure.Adapters.Out.Databases;
using SistemaCadastro.Infrastructure.Adapters.Out.MongoDB;
using SistemaCadastro.Infrastructure.Configs;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
}).AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddScoped<IPessoaRepository, PostgresPessoaRepository>();
builder.Services.AddScoped<IEnderecoApi, EnderecoViaCep>();

builder.Services.AddSwaggerGen();

builder.Services.AddHttpClientConfig(builder.Configuration);


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    Assembly.Load("SistemaCadastro.Application")
));

builder.Services.AddHealthChecks();

var connectionString = builder.Configuration.GetConnectionString("Postgres");

builder.Services.AddPostgresInfrastructure(connectionString);

builder.Services.AddMongoDb(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var provider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();
        foreach (var description in provider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
                $"/swagger/{description.GroupName}/swagger.json",
                description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHealthChecks("/health");

app.Run();