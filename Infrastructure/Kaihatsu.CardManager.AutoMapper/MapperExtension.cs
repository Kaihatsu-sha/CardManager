using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Kaihatsu.CardManager.AutoMapper;

public static class MapperExtension
{
    public static IServiceCollection AddCardMapper(this IServiceCollection collection)
    {
        MapperConfiguration mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new Profiles()));
        IMapper mapper = mapperConfiguration.CreateMapper();

        return collection.AddSingleton(mapper);
    }
}