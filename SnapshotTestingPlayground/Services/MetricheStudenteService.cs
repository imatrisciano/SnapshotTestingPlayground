using SnapshotTestingPlayground.Models;
using SnapshotTestingPlayground.Repositories;

namespace SnapshotTestingPlayground.Services
{
    public class MetricheStudenteService(IRegistrazioneEsameRepository registrazioneEsameRepository) : IMetricheStudenteService
    {
        public async Task<MetricheStudente> CalcolaMetricheStudenteAsync(Studente studente)
        {
            ArgumentNullException.ThrowIfNull(studente, nameof(studente));

            var esamiSostenuti = await registrazioneEsameRepository.GetEsamiStudenteAsync(studente);

            double mediaAritmetica = esamiSostenuti.Average(esame => esame.Voto);
            double mediaPonderata = CalcolaMediaPonderata(esamiSostenuti);
            int numeroDiLodi = esamiSostenuti.Count(esame => esame.Lode);

            return new MetricheStudente(studente, mediaAritmetica, mediaPonderata, numeroDiLodi);
        }

        private double CalcolaMediaPonderata(IEnumerable<RegistrazioneEsame> esamiSostenuti)
        {
            int totaleCfu = esamiSostenuti.Sum(esame => esame.Corso.Cfu);
            if (totaleCfu == 0)
                return 0;

            double sommaPesata = esamiSostenuti.Sum(esame => (double) esame.Corso.Cfu * esame.VotoConBonusLode);
            return sommaPesata / totaleCfu;
        }
    }
}
