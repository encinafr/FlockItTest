using FlockIt.Interfaces;
using FlockIt.Services;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FlockIt.Extensions
{
    public static class ApiServicesExtensions
    {
        public static void AddGeoService(this IServiceCollection services)
        {
            services.AddHttpClient<IGeoService, GeoService>(c =>
            {
                //TODO: Mover a AppSettings
                c.BaseAddress = new Uri("https://apis.datos.gob.ar/georef/api/");
            });
        }
    }
}
