using SnapshotTestingPlayground.Models;

namespace SnapshotTestingPlayground.Services
{
    public interface IMetricheStudenteService
    {
        public Task<MetricheStudente> CalcolaMetricheStudenteAsync(Studente studente);
        
    }
}
