using SnapshotTestingPlayground.Models;
using SnapshotTestingPlayground.Services;
using FluentAssertions;
using NSubstitute;
using SnapshotTestingPlayground.Repositories;

namespace SnapshotTestingPlayground.Tests
{
    public class MetricheStudenteServiceTests
    {
        [Fact]
        public async Task CalcolaMetricheStudente_DovrebbeRestituireRisultatiCorretti()
        {
            // Arrange
            var studente = new Studente("Mario", "Rossi", "N97000123");

            var corso1 = new Corso("Corso 1", Cfu: 9);
            var corso2 = new Corso("Corso 2", Cfu: 6);

            List<RegistrazioneEsame> esami = [
                new RegistrazioneEsame(studente, corso1, 30, Lode: true),
                new RegistrazioneEsame(studente, corso2, 20, Lode: false),
            ];

            var repositoryEsami = Substitute.For<IRegistrazioneEsameRepository>();
            repositoryEsami.GetEsamiStudenteAsync(studente).Returns(esami);

            var metricheStudenteService = new MetricheStudenteService(repositoryEsami);

            var expected = new MetricheStudente(
                Studente: studente, 
                MediaAritmetica: 25, 
                MediaPonderata: 26.6, 
                NumeroDiLodi: 1
                );

            // Act
            var actual = await metricheStudenteService.CalcolaMetricheStudenteAsync(studente);

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
        
        [Fact]
        public async Task CalcolaMetricheStudente_DovrebbeRestituireRisultatiCorretti_SnapshotTesting()
        {
            // Arrange
            var studente = new Studente("Mario", "Rossi", "N97000123");

            var corso1 = new Corso("Corso 1", Cfu: 9);
            var corso2 = new Corso("Corso 2", Cfu: 6);

            List<RegistrazioneEsame> esami = [
                new RegistrazioneEsame(studente, corso1, 30, Lode: true),
                new RegistrazioneEsame(studente, corso2, 20, Lode: false),
            ];

            var repositoryEsami = Substitute.For<IRegistrazioneEsameRepository>();
            repositoryEsami.GetEsamiStudenteAsync(studente).Returns(esami);

            var metricheStudenteService = new MetricheStudenteService(repositoryEsami);

            // Act
            var result = await metricheStudenteService.CalcolaMetricheStudenteAsync(studente);

            // Verifica snapshot
            await Verify(result);
        }

        [Fact]
        public async Task CalcolaMetricheStudente_ShouldThrow_IfStudentIsNull()
        {
            // Arrange
            var repositoryEsami = Substitute.For<IRegistrazioneEsameRepository>();

            var metricheStudenteService = new MetricheStudenteService(repositoryEsami);

            // Act
            Task<MetricheStudente> action() => 
                metricheStudenteService.CalcolaMetricheStudenteAsync(null!);

            // Verifica snapshot
            await ThrowsTask(action);
            
        }


    }
}
