using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Refit;
using SistemaCadastro.Domain.Ports;
using SistemaCadastro.Infrastructure.Adapters.Out.Api;
using System.Text.Json;

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
        services.AddRefitClient<IViaCepApi>(_refitSettingsWithCamelCase).ConfigureHttpClient(c =>
        {
            c.BaseAddress = new Uri(configuration.GetValue<string>("Services:Endereco:Uri"));
        });

        return services;
    }
}
