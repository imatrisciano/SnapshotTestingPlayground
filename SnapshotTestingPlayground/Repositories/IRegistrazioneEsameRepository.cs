using SnapshotTestingPlayground.Models;

namespace SnapshotTestingPlayground.Repositories
{
    public interface IRegistrazioneEsameRepository
    {
        public Task<List<RegistrazioneEsame>> GetEsamiStudenteAsync(Studente studente);
    }
}
