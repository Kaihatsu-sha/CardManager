using FluentValidation;
using Kaihatsu.CardManager.Request;
using Microsoft.Extensions.DependencyInjection;

namespace Kaihatsu.CardManager.FluentValidation;

public static class ValidationExtension
{
    public static IServiceCollection AddValidation(this IServiceCollection collection)
    {
        return collection.AddScoped<IValidator<AuthorizationRequest>, AuthorizationRequestValidator>();
    }
}
