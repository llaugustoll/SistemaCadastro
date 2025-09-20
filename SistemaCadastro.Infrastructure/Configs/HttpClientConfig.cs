using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using System.Text.Json;
using SistemaCadastro.Domain.Ports;

namespace SistemaCadastro.Infrastructure.Configs;

public static class HttpClientConfig
{
    private static readonly RefitSettings _refitSettingsWithCamelCase = new()
    {
        ContentSerializer = new SystemTextJsonContentSerializer(new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        })
    };

    public static IServiceCollection AddHttpClientConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRefitClient<IEndereco>(_refitSettingsWithCamelCase).ConfigureHttpClient(c =>
        {
            c.BaseAddress = new Uri(configuration.GetValue<string>("Services:Endereco:Uri"));
        });

        return services;
    }
}
