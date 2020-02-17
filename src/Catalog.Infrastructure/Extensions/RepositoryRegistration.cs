using System;
using Catalog.Domain.Repositories;
using Catalog.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.Infrastructure.Extensions
{
    public static class RepositoryRegistration
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<IItemRepository, ItemRepository>()
                .AddScoped<IArtistRepository, ArtistRepository>()
                .AddScoped<IGenreRepository, GenreRepository>()
                ;

            return services;
        }
    }
}
