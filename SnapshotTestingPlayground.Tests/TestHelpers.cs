using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SnapshotTestingPlayground.Components.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SnapshotTestingPlayground.Tests
{
    internal static class TestHelpers
    {
        private static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder => {
                builder.AddConsole();
            });

        /// <summary>
        /// Crea e aggiunge un ILogger<T> al DI container
        /// </summary>
        /// <typeparam name="T">Il tipo per cui generare il logger</typeparam>
        /// <param name="services">La collezione di servizi a cui aggiungere il logger</param>
        /// <returns>La collezione di servizi con il logger aggiunto</returns>
        public static IServiceCollection AddLogger<T>(this IServiceCollection services)
        {
            var logger = loggerFactory.CreateLogger<T>();
            services.AddSingleton<ILogger<T>>((IServiceProvider sp) => logger);
            return services;
        }
    }
}
