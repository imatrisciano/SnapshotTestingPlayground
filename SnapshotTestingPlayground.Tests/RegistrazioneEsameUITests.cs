using SnapshotTestingPlayground.Models;
using SnapshotTestingPlayground.Components.Pages;
using SnapshotTestingPlayground.Services;
using Microsoft.Extensions.DependencyInjection;
using NSubstitute;
using VerifyTests.Blazor;
using SnapshotTestingPlayground.Repositories;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Components;

namespace SnapshotTestingPlayground.Tests
{
    public class RegistrazioneEsameUITests
    {
        [Fact]
        public async Task PaginaRiepilogoCarriera_HaIlLayoutCorretto()
        {
            //Arrange
            var template = new RiepilogoCarriera() // Il componente sotto test
            {
                Matricola = "123456", //I parametri in ingresso nel componente
            };

            //Setup del mock
            var studente = new Studente("Mario", "Rossi", "123456");
            var corso1 = new Corso("Corso 1", Cfu: 9);
            var corso2 = new Corso("Corso 2", Cfu: 6);

            List<RegistrazioneEsame> esami = [
                new RegistrazioneEsame(studente, corso1, 30, Lode: true),
                new RegistrazioneEsame(studente, corso2, 20, Lode: false),
            ];

            var repositoryEsami = Substitute.For<IRegistrazioneEsameRepository>();
            repositoryEsami.GetEsamiStudenteAsync(studente).Returns(esami);

            var metricheStudenteService = new MetricheStudenteService(repositoryEsami);

            //Setup del DI
            ServiceProvider serviceProvider = new ServiceCollection()
                .AddScoped<IStudenteRepository, StudenteRepositoryFinta>()
                .AddScoped<IRegistrazioneEsameRepository>( _ => repositoryEsami)
                .AddScoped<IMetricheStudenteService>(_ => metricheStudenteService)
                .AddLogger<RiepilogoCarriera>()
                .BuildServiceProvider();

            //Render del componente
            var target = Render.Component(serviceProvider, template: template);

            //Verifica
            await Verify(target);
        }
    }
}
